using SqlSugar;
using System;
using System.Configuration;
using StackExchange.Redis;
using System.Collections.Generic;

namespace FutureServerState
{
    public class Funs
    {
        public static ConfigPars CONFIG;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public static Initials Init()
        {
            #region 初始化：连接及登录
            Login_Output_O32 logOut = null;
            SqlSugarClient db = SugarTools.GetInstance();

            CONFIG = db.Queryable<ConfigPars>().First();

            //db.DbFirst.Where("UserInfo").CreateClassFile(@"D:\workspace\交易接口\总线", "FutureServerState");

            var UserList = db.Queryable<UserInfo>().ToList();
            foreach (UserInfo user in UserList)
            {
                Initials.UserDicts.Add(user.combi_no, user);
            }

            foreach (UserInfo user in UserList)
            {
                Initials.UserDicts2.Add(user.combi_no, user);
            }

            HSPack_Syn hsPack = new HSPack_Syn();
            // 连接
            if (hsPack.InitT2())
            {
                Console.WriteLine("连接成功");

                Login(hsPack);
            }
            else
            {
                Console.WriteLine("连接失败");
            }


            HSPack_Syn hsPack2 = new HSPack_Syn();
            // 连接
            if (hsPack2.InitT2())
            {
                Console.WriteLine("hs2连接成功");
                Login(hsPack2);
            }
            else
            {
                Console.WriteLine("hs2连接失败");
            }


            #endregion

            #region redis
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(Funs.CONFIG.redis);
            IDatabase rClient = redis.GetDatabase();


            #endregion


            Initials Init = new Initials()
            {
                logOut = logOut,
                db = db,
                hsPack = hsPack,
                hsPack2 = hsPack2,
                rClient = rClient,
            };
            return Init;

            void Login(HSPack_Syn hs)
            {

                Login_Input_O32 objLogin_Input = new Login_Input_O32
                {
                    in_operator_no = Funs.CONFIG.operator_no,
                    in_password = Funs.CONFIG.O32Psw,
                    in_station_add = Funs.CONFIG.station_add,
                    in_ip_address = Funs.CONFIG.ip_address,
                    in_mac_address = hsPack.GetMac(true),
                    authorization_id = Funs.CONFIG.authorization_id,
                    app_id = Funs.CONFIG.app_id,
                    authorize_code = Funs.CONFIG.authorize_code,
                    port_id = Funs.CONFIG.port_id,
                };
                logOut = hs.Fun10001_Login_S(objLogin_Input);
                if (logOut.out_error_no == "0")
                {
                    Funs.CONFIG.token = logOut.out_user_token;
                    Console.WriteLine($"{Funs.CONFIG.operator_no} 登录成功");
                }
                else
                {
                    Console.WriteLine($"{Funs.CONFIG.operator_no}  {logOut.out_error_info}");
                }


                //foreach (KeyValuePair<string, UserInfo> kv in Initials.UserDicts2)
                //{
                //    Login_Input_O32 objLogin_Input = new Login_Input_O32
                //    {
                //        in_operator_no = kv.Key,
                //        in_password = kv.Value.PASSWORD,
                //        in_station_add = ConfigurationManager.AppSettings["station_add"],
                //        in_ip_address = ConfigurationManager.AppSettings["ip_address"],
                //        in_mac_address = hsPack.GetMac(true),
                //        authorization_id = ConfigurationManager.AppSettings["authorization_id"],
                //        app_id = ConfigurationManager.AppSettings["app_id"],
                //        authorize_code = ConfigurationManager.AppSettings["authorize_code"],
                //        port_id = ConfigurationManager.AppSettings["port_id"],
                //    };
                //    logOut = hs.Fun10001_Login_S(objLogin_Input);
                //    if (logOut.out_error_no == "0")
                //    {
                //        kv.Value.token = logOut.out_user_token;
                //        Console.WriteLine($"{kv.Key} 登录成功");
                //    }
                //    else
                //    {
                //        Console.WriteLine($"{kv.Key}  {logOut.out_error_info}");
                //    }
                //}

            }

        }


    }
}
