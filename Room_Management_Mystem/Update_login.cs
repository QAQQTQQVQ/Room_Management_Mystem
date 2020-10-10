using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;



namespace Room_Management_Mystem
{
    public partial class Update_login : Form
    {
        public Update_login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                string com = string.Format("update {0} set User_Name='{1}',UID='{2}',PWD='{3}' where User_Name= '{4}'", "Login", textBox4.Text, textBox1.Text, textBox2.Text, DBHelper.sql_User_Name);
                string con = "server=" + DBHelper.Server_Name + "; Database= " + DBHelper.Database_Name + "; Uid= " + DBHelper.User_Name + "; pwd=" + DBHelper.Password + "; ";
                SqlConnection mydb = new SqlConnection(con);
                SqlCommand mycom = new SqlCommand(com, mydb);
                mydb.Open();
                mycom.ExecuteNonQuery();
                mydb.Close();
                DBHelper.sql_User_Name = textBox4.Text;
                MessageBox.Show("修改成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("两次输入的密码不匹配，请重修输入！");
                textBox2.Text = "";
                textBox3.Text = "";

            }
        }

        private void pictureBox12_MouseEnter(object sender, EventArgs e)
        {
            pictureBox12.Image = Properties.Resources.tuichu;
        }

        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            pictureBox12.Image = Properties.Resources.tuichu__1_;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.SkyBlue;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Update_login_Load(object sender, EventArgs e)
        {
            string con = "server=" + DBHelper.Server_Name + ";Database=" + DBHelper.Database_Name + ";Uid=" + DBHelper.User_Name + ";pwd=" + DBHelper.Password + ";";
            SqlConnection mydb = new SqlConnection(con);
            mydb.Open();
            string com =string.Format( "select * from Login where User_Name='{0}'",DBHelper.sql_User_Name);
            SqlCommand mycom = new SqlCommand(com, mydb);
            SqlDataReader sql_read = mycom.ExecuteReader();
            while (sql_read.Read())
            {
               string sql_UID = sql_read["UID"].ToString().Trim();
               string sql_PWD = sql_read["PWD"].ToString().Trim();
                textBox1.Text = sql_UID;
                textBox4.Text = DBHelper.sql_User_Name;
            }
        }

    }
}
