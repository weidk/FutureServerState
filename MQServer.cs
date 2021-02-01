using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FutureServerState
{
    public class MQServer
    {
        #region 定义变量
        public static BlockingCollection<RequestClass> AlivedOrder = new BlockingCollection<RequestClass>();
        public static ConcurrentDictionary<String, RequestClass> OrderDicts = new ConcurrentDictionary<String, RequestClass>();
        public static ConcurrentBag<FuturepositionQry_Output> positionsQueues = new ConcurrentBag<FuturepositionQry_Output>();
        public static ConcurrentDictionary<String, FuturepositionQry_Output> positionsDict = new ConcurrentDictionary<String, FuturepositionQry_Output>();
        private readonly IConnection connection;
        private readonly IModel channel;
        private readonly IModel channel2;
        List<string> FinishedState = new List<string>{ "5", "7", "8", "9", "F", "E" };

        object _lock = new object();
        object _lockPos = new object();

        // 撤销订单队列
        public static BlockingCollection<RequestClass> ToCancleOrders = new BlockingCollection<RequestClass>();


        //string positionStrRedisKey = ConfigurationManager.AppSettings["positionStr"];
        //string orderKey = ConfigurationManager.AppSettings["orderKey"];
        //  废单
        #endregion
        public MQServer()
        {
            var factory = new ConnectionFactory();
            factory.UserName = Funs.CONFIG.UserName;
            factory.Password = Funs.CONFIG.Password;
            factory.HostName = Funs.CONFIG.HostName;
            factory.AutomaticRecoveryEnabled = true;
            //factory.RequestedHeartbeat = 0;

            connection = factory.CreateConnection();
          
            channel = connection.CreateModel();
            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            channel2 = connection.CreateModel();
            channel2.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

        }

        

        public void Close()
        {
            connection.Close();
        }





        #region 恢复数据


        public void Recover(Initials Init)
        {
            // 恢复未完成委托流水
            RecoverData(Init);
        }
        #endregion


        #region 维护订单状态
        public async Task MaintainOrders(Initials Init)
        {

            #region 方式一
            // 接收新进来的订单
            NewOrderRequestHandle(Init);


            FutureOrderUpdate(Init);


            PositionUpdate(Init);
            #endregion

            #region 方式二

            //// 接收新订单
            //NewOrderRequestHandle2(Init);

            //// 处理成交
            // CheckIsDeal(Init);

            //// 处理撤销
            // ToCancleOrderUpdate(Init);

            //// 处理废单
            // CheckIsNullOrder(Init);

            #endregion

        }


        #endregion



        #region 通过检查委托状态来更新订单状态

      
        // 更新持仓变化
        public async Task PositionUpdate(Initials Init)
        {
            int interval = int.Parse(Funs.CONFIG.interval);
            void LongTask()
            {
                while (true)
                {
                    try
                    {
                        foreach (KeyValuePair<string, UserInfo> kv in Initials.UserDicts2)
                        {
                            //if (kv.Value.token != null)
                            //{
                                FuturepositionQry_Input objFuturepositionQry_Input = new FuturepositionQry_Input();
                                objFuturepositionQry_Input.in_user_token = Funs.CONFIG.token;
                                //objFuturepositionQry_Input.in_market_no = "7";
                                //objFuturepositionQry_Input.in_asset_no = kv.Value.asset_no;
                                objFuturepositionQry_Input.in_combi_no = kv.Value.combi_no;
                                //objFuturepositionQry_Input.in_account_code = kv.Value.account_code;

                                var pos = Init.hsPack2.Fun31003_FuturepositionQry(objFuturepositionQry_Input);
                                if (pos.Count > 0)
                                {
                                    if (pos[0].out_stock_code != null)
                                    {
                                        Init.rClient.StringSet(kv.Key, Newtonsoft.Json.JsonConvert.SerializeObject(pos));
                                    }
                                }
                            //}
                        }
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    finally
                    {
                        Thread.Sleep(interval);
                    }

                }

            }
            await Task.Factory.StartNew(() => LongTask(), TaskCreationOptions.LongRunning);
        }



 

        // 发布订单更新
        public static void PublishMsg(RequestClass request, IModel channel, Initials Init)
        {
            try
            {
                string responsestring = Newtonsoft.Json.JsonConvert.SerializeObject(request);
                var responseBytes = Encoding.UTF8.GetBytes(responsestring);
                channel.BasicPublish(exchange: "", routingKey: request.queue_name, basicProperties: null, body: responseBytes);
                Init.db.Insertable(request).ExecuteCommand();
                Console.WriteLine($"状态更新 ：{responsestring}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }


        // 初始化 恢复数据
        public void RecoverData(Initials Init)
        {
            List<RequestClass> dt = Init.db.Ado.SqlQuery<RequestClass>("select a.* from requestclass a inner join (select entrust_no,MAX(id) maxid from OrderFlowVty    where  entrust_no!='0'   group by entrust_no) b on a.id = b.maxid where orderState not in('5','7', '8', '9', 'F', 'E')  or (orderState is null  AND error_info is null)");
            foreach (var request in dt)
            {
                MQServer.AlivedOrder.Add(request);
            }
        }

        
        //更新订单状态
        public async Task FutureOrderUpdate(Initials Init)
        {
            int interval = int.Parse(Funs.CONFIG.interval);
            void LongTask()
            {
                FutureentrustQry_Input objFutureentrustQry_Input;
                foreach (RequestClass order in MQServer.AlivedOrder.GetConsumingEnumerable())
                {
                    try
                    {
                        
                        string userKey = order.queue_name.Replace(Funs.CONFIG.ReplyName, "");
                        //if (Initials.UserDicts[userKey].token != null)
                        //{
                            if (order.entrust_no != "0")
                            {
                                objFutureentrustQry_Input = new FutureentrustQry_Input();
                                objFutureentrustQry_Input.in_user_token = Funs.CONFIG.token;
                                objFutureentrustQry_Input.in_asset_no = Initials.UserDicts[userKey].asset_no;
                                objFutureentrustQry_Input.in_account_code = Initials.UserDicts[userKey].account_code;
                                objFutureentrustQry_Input.in_combi_no = Initials.UserDicts[userKey].combi_no;
                                objFutureentrustQry_Input.in_entrust_no = order.entrust_no;

                                List<FutureentrustQry_Output> ordersQueues = Init.hsPack.Fun32003_FutureentrustQry(objFutureentrustQry_Input);
                                FutureentrustQry_Output orderTemp = ordersQueues[0];
                                if (orderTemp.out_stock_code != null)
                                {
                                    // 状态发生变化
                                    if (orderTemp.out_entrust_state != order.orderState)
                                    {
                                        order.error_info = orderTemp.out_error_info + orderTemp.out_withdraw_cause;
                                        order.entrust_no = orderTemp.out_entrust_no;
                                        order.orderState = orderTemp.out_entrust_state;
                                        order.deal_amount = orderTemp.out_deal_amount;
                                        order.deal_balance = orderTemp.out_deal_balance;
                                        order.deal_price = orderTemp.out_deal_price;

                                        // 发布变化状态
                                        PublishMsg(order, channel, Init);
                                    }
                                    else if (orderTemp.out_entrust_state == "6" && orderTemp.out_deal_amount != order.deal_amount)
                                    {
                                        // 部分成交
                                        order.error_info = orderTemp.out_error_info + orderTemp.out_withdraw_cause;
                                        order.entrust_no = orderTemp.out_entrust_no;
                                        order.orderState = orderTemp.out_entrust_state;
                                        order.deal_amount = orderTemp.out_deal_amount;
                                        order.deal_balance = orderTemp.out_deal_balance;
                                        order.deal_price = orderTemp.out_deal_price;

                                        // 发布变化状态
                                        PublishMsg(order, channel, Init);
                                    }


                                    bool IsFinished = FinishedState.Contains(orderTemp.out_entrust_state);

                                    // 订单生命周期未结束，添加回队列
                                    if (!IsFinished)
                                    {
                                        MQServer.AlivedOrder.Add(order);
                                    }
                                }
                                else
                                {
                                    // 没查询到数据，将该条数据添加回队列
                                    MQServer.AlivedOrder.Add(order);
                                }
                            }
                            
                        //}
                        //else
                        //{
                        //    order.error_info = "O32密码错误";
                        //    MQServer.AlivedOrder.Add(order);
                        //    //PublishMsg(order, channel, Init);
                        //}
                        
                        Thread.Sleep(100);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        Thread.Sleep(interval);
                    }
                }
            }

            await Task.Factory.StartNew(() => LongTask(), TaskCreationOptions.LongRunning);
        }


        /// 接收新增订单
        public void NewOrderRequestHandle(Initials Init)
        {
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel2);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                try
                {
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(message);
                    RequestClass request = Newtonsoft.Json.JsonConvert.DeserializeObject<RequestClass>(message);
                    //OrderChangePosition(Init, request.businessType, request.entrust_direction, request.futures_direction, request.entrust_no, request.code, request.entrust_amount);
                    if (request.businessType == "0")
                    {
                        var pl = MQServer.AlivedOrder.Where(o => o.entrust_no == request.entrust_no).FirstOrDefault();
                        MQServer.AlivedOrder.Where(o => o.entrust_no == request.entrust_no).Take(1);
                        pl.businessType = "0";
                        pl.clordId = request.clordId;
                        MQServer.AlivedOrder.Add(pl);
                    }
                    else
                    {
                        MQServer.AlivedOrder.Add(request);
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    AckMsg();

                }

                void AckMsg()
                {
                    try
                    {
                        channel2.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                    }
                    catch (System.IO.IOException ioex)
                    {
                        AckMsg();
                    }
                }
            };
            channel2.BasicConsume(queue: Funs.CONFIG.OrderStateQueueName, autoAck: false, consumer: consumer);


        }



        #endregion



    }
}
