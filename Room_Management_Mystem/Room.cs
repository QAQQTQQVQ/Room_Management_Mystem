using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Forms;
using System.Data;


namespace Room_Management_Mystem
{
    class Room
    {
        public void Together(string com)
        {
            string con = "server=" + DBHelper.Server_Name + "; Database= " + DBHelper.Database_Name + "; Uid= " + DBHelper.User_Name + "; pwd=" + DBHelper.Password + "; ";
            SqlConnection mydb = new SqlConnection(con);
            SqlCommand mycom = new SqlCommand(com, mydb);
            mydb.Open();
            mycom.ExecuteNonQuery();
            mydb.Close();
        }
        public DataSet query()//查询
        {
            string con = "server=" + DBHelper.Server_Name+"; Database= "+DBHelper.Database_Name+"; Uid= "+DBHelper.User_Name+"; pwd="+DBHelper.Password+"; ";
            string com = "select Room_ID,Room_Type,Room_Location,Room_Entry,Room_Existence from Room_information";
            SqlConnection mydb = new SqlConnection(con);
            SqlCommand mycom = new SqlCommand(com, mydb);
            mydb.Open();
            SqlDataAdapter da = new SqlDataAdapter(mycom);
            DataSet ds = new DataSet();
            da.Fill(ds);
            mydb.Close();
            return ds;
        }
        public void add(string a, string b, string c, string d, string e)//增加
        {
            string com = string.Format("insert into Room_information(Room_ID,Room_Type,Room_Location,Room_Entry,Room_Existence) values('{0}','{1}','{2}','{3}','{4}')", a,b,c,d,e);
            Together(com);
        }
        public void remove(string NUM)//删除
        {
            string com = "delete from  Room_information  where Room_ID = '" + NUM+"'";
            Together(com);
        }
        public void update(string NUM,string a, string b, string c, string d, string e)//修改
        {
            string  com = string.Format("update {0} set Room_ID='{1}',Room_Type='{2}',Room_Location='{3}',Room_Entry='{4}',Room_Existence='{5}' where Room_ID = '{6}'", "room_information", a, b, c, d,e,NUM);
            Together(com);
        }
    }
}
