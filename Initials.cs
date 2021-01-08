using SqlSugar;
using StackExchange.Redis;
using System.Collections.Generic;

namespace FutureServerState
{
    public class Initials
    {
        public Login_Output_O32 logOut = null;
        public SqlSugarClient db;
        public HSPack_Syn hsPack;
        public HSPack_Syn hsPack2;
        public IDatabase rClient;
        public static Dictionary<string, UserInfo> UserDicts = new Dictionary<string, UserInfo>();
        public static Dictionary<string, UserInfo> UserDicts2 = new Dictionary<string, UserInfo>();
    }
}
