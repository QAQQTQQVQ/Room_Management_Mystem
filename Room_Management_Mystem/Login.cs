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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public void Centered_show(Control o, int x, int y)
        {
            o.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - o.Size.Width) / 2 + x, (Screen.PrimaryScreen.WorkingArea.Height - o.Size.Height) / 2 + y);
        }
        private void Login_Load(object sender, EventArgs e)
        {

            Centered_show(pictureBox1, 0, -100);
            Centered_show(pictureBox3, Screen.PrimaryScreen.WorkingArea.Width / 2 - 50, -Screen.PrimaryScreen.WorkingArea.Height / 2 + 50);
            Centered_show(tb_UID, 0, 60);
            Centered_show(tb_PWD, 0, 93);
            Centered_show(label1, 0, 0);
            Centered_show(label2, -75, 60);
            Centered_show(label3, -95, 90);
            Centered_show(btn_login, 0, 160);
            Centered_show(checkBox1, -85, 130);
            Centered_show(checkBox2, 90, 130);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            label2.Location = new Point(10000, 10000);
            label3.Location = new Point(10000, 10000);

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            label2.Location = new Point(10000, 10000);
            label3.Location = new Point(10000, 10000);
       
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.tuichu;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.tuichu__1_;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btn_login.BackColor = Color.Red;
        }

        private void btn_login_MouseLeave(object sender, EventArgs e)
        {
            btn_login.BackColor = Color.DeepSkyBlue;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string sql_UID = "";
            string sql_PWD = "";
          
            string con = "server=" + DBHelper.Server_Name + ";Database=" + DBHelper.Database_Name + ";Uid=" + DBHelper.User_Name + ";pwd=" + DBHelper.Password + ";";
            SqlConnection mydb = new SqlConnection(con);
            mydb.Open();
            string com = "select * from Login";
            SqlCommand mycom = new SqlCommand(com, mydb);
            SqlDataReader sql_read = mycom.ExecuteReader();
            while (sql_read.Read())
            {
                sql_UID = sql_read["UID"].ToString().Trim();
                sql_PWD = sql_read["PWD"].ToString().Trim();
                DBHelper.sql_User_Name = sql_read["User_Name"].ToString().Trim();
                if (tb_UID.Text == sql_UID && tb_PWD.Text == sql_PWD)
                {
                    Form p = new Function();
                    p.Show();
                    this.Hide();
                    goto end;
                }
            }
            MessageBox.Show("登入失败！你输入的密码或者账号有误！");
            tb_PWD.Text = "";
            tb_PWD.Focus();
        end:;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            tb_UID.Focus();
            label2.Location = new Point(10000, 10000);
            label3.Location = new Point(10000, 10000);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            tb_PWD.Focus();
            label2.Location = new Point(10000, 10000);
            label3.Location = new Point(10000, 10000);
        }
    }
}

