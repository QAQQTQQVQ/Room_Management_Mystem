using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;


namespace Room_Management_Mystem
{
    static class DBHelper
    {
        public static string Server_Name = "DESKTOP-44MURPB";
        public static string Database_Name = "Room_Management_System";
        public static string User_Name = "sa";
        public static string Password = "123456";
        public static string sql_User_Name ="";
        public static string NUM = "0";
        public static bool Refresh = false;
        public static bool Variable = false;
        public static string target = "";
    }
}
