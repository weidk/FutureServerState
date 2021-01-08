using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FutureServerState
{
    class Program
    {
        static void Main(string[] args)
        {

            // 初始化
            Initials Init = Funs.Init();

            MQServer mq = new MQServer();


            // 恢复数据
            mq.Recover(Init);

            // 维护订单状态
            mq.MaintainOrders(Init);


            DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 00, 00);
            while (true)
            {
                if (DateTime.Now > endTime)
                {
                    Environment.Exit(0);
                }
                try
                {
                    Init.hsPack.Fun10000_heartBeat(Funs.CONFIG.token);

                    //foreach (KeyValuePair<string, UserInfo> kv in Initials.UserDicts)
                    //{
                    //    if(kv.Value.token != null)
                    //    {
                    //        // 发送心跳
                    //        Init.hsPack.Fun10000_heartBeat(kv.Value.token);
                    //    }
                        
                    //}

                    //foreach (KeyValuePair<string, UserInfo> kv in Initials.UserDicts2)
                    //{
                    //    if (kv.Value.token != null)
                    //    {
                    //        // 发送心跳
                    //        Init.hsPack2.Fun10000_heartBeat(kv.Value.token);
                    //    }
                            
                    //}
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());

                }
                finally
                {
                    Thread.Sleep(10000);
                }

            }

            //Console.WriteLine(" Press [enter] to exit.");
            //Console.ReadLine();
        }
    }
}
