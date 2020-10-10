using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Room_Management_Mystem
{

    public partial class Function : Form
    {
        protected override CreateParams CreateParams//非常厉害的一段代码
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;////用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }

        int time = 0;
        public Function()
        {
            InitializeComponent();
        }
        public void Centered_show(Control o, int x, int y)
        {
            o.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - o.Size.Width) / 2 + x, (Screen.PrimaryScreen.WorkingArea.Height - o.Size.Height) / 2 + y);
        }
        private void Login_Load(object sender, EventArgs e)
        {
            label13.Text = DBHelper.sql_User_Name;
            label8.Text = "欢迎 " + DBHelper.sql_User_Name + " 进入系统";
            Centered_show(label8, 0, 0);
            Centered_show(panel3, Screen.PrimaryScreen.WorkingArea.Width / 2-180 , -Screen.PrimaryScreen.WorkingArea.Height / 2+70);
            Centered_show(panel1, 0, -50);
            Centered_show(label9, 0, 80);
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {    
            Label o = sender as Label;
            o.ForeColor = Color.Red;
 
        }

        private void pictureBox15_MouseEnter(object sender, EventArgs e)
        {
            pictureBox15.Image = Properties.Resources.tuichu;
           
        }

        private void pictureBox15_MouseLeave(object sender, EventArgs e)
        {
            pictureBox15.Image = Properties.Resources.tuichu__1_;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            Label o = sender as Label;
            o.ForeColor = Color.Black;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = label9.Text + "。";
            time++;
            if (time == 6 || DBHelper.Variable)
            {
                timer1.Enabled = false;
                DBHelper.Variable = false;
                panel2.Hide();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DBHelper.target = "student";
            Form p = new Main_interface();
            p.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DBHelper.target = "teacher";
            Form p = new Main_interface();
            p.Show();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DBHelper.target = "room";
            Form p = new Main_interface();
            p.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form p = new Feedback();
            p.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form p = new Update_login();
            p.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form p = new Login();
            p.Show();
            MessageBox.Show("注销成功！");
            this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label12.Text = DateTime.Now.ToLocalTime().ToString();
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            BackgroundImage = Properties.Resources.b1;
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            BackgroundImage = Properties.Resources.b2;
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            BackgroundImage = Properties.Resources.b3;
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            BackgroundImage = Properties.Resources.b4;
        }

        private void label6_MouseMove(object sender, MouseEventArgs e)
        {
            BackgroundImage = Properties.Resources.b5;
        }

        private void label7_MouseMove(object sender, MouseEventArgs e)
        {
            BackgroundImage = Properties.Resources.b6;
        }
    }

}
