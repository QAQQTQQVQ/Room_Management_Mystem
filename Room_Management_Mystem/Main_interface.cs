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
    public partial class Main_interface : Form
    {
        public Main_interface()
        {
            InitializeComponent();
        }
        public void Centered_show(Control o, int x, int y)
        {
            o.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - o.Size.Width) / 2 + x, (Screen.PrimaryScreen.WorkingArea.Height - o.Size.Height) / 2 + y);
        }
        private void Login_Load(object sender, EventArgs e)
        {
            label1.Text = DBHelper.sql_User_Name;
            label2.Text= DateTime.Now.ToLocalTime().ToString();
            pictureBox1.Width = Screen.PrimaryScreen.WorkingArea.Width - 60;
            pictureBox7.Width = Screen.PrimaryScreen.WorkingArea.Width - 60;
            pictureBox19.Width = Screen.PrimaryScreen.WorkingArea.Width - 60;
            pictureBox20.Width = Screen.PrimaryScreen.WorkingArea.Width - 60;
            dataGridView1.Width = Screen.PrimaryScreen.WorkingArea.Width - 420;
            Centered_show(panel2, Screen.PrimaryScreen.WorkingArea.Width / 2 - 250, -Screen.PrimaryScreen.WorkingArea.Height / 2 + 75);
            switch (DBHelper.target)
            {
                case "student":

                    Student stu = new Student();
                    dataGridView1.DataSource = stu.query().Tables[0];
                    break;
                case "teacher":

                    Teacher tea = new Teacher();
                    dataGridView1.DataSource = tea.query().Tables[0];
                    button2.Text = "增加教师信息";
                    button3.Text = "删除教师信息";
                    button4.Text = "更改教师信息";
                    break;
                case "room":

                    Room rom = new Room();
                    dataGridView1.DataSource = rom.query().Tables[0];
                    button2.Text = "增加房间信息";
                    button3.Text = "删除房间信息";
                    button4.Text = "更改房间信息";
                    break;
                default:
                    break;
            }
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

        private void btn_login_Click(object sender, EventArgs e)
        {
            Form p = new Function();
            p.Show();
            this.Hide();
        }

        private void pictureBox13_MouseEnter(object sender, EventArgs e)
        {
            pictureBox13.Image = Properties.Resources.fanhui__1_;
        }

        private void pictureBox13_MouseLeave(object sender, EventArgs e)
        {
            pictureBox13.Image = Properties.Resources.fanhui;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (DBHelper.target)
            {
                case "student":
                    Student stu = new Student();
                    dataGridView1.DataSource = stu.query().Tables[0];

                    break;
                case "teacher":
                    Teacher tea = new Teacher();
                    dataGridView1.DataSource = tea.query().Tables[0];

                    break;
                case "room":
                    Room rom = new Room();
                    dataGridView1.DataSource = rom.query().Tables[0];
                    break;
                default:
                    break;
            }
            MessageBox.Show("刷新成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form p = new Add();
            p.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string NUM = "";
            if (dataGridView1.SelectedRows.Count == 1)
            {
                NUM = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                switch (DBHelper.target)
                {
                    case "student":

                        Student stu = new Student();
                        stu.remove(NUM);
                        dataGridView1.DataSource = stu.query().Tables[0];
                        MessageBox.Show("删除成功");
                        break;
                    case "teacher":

                        Teacher tea = new Teacher();
                        tea.remove(NUM);
                        dataGridView1.DataSource = tea.query().Tables[0];
                        MessageBox.Show("删除成功");
                        break;
                    case "room":

                        Room rom = new Room();
                        rom.remove(NUM);
                        dataGridView1.DataSource = rom.query().Tables[0];
                        MessageBox.Show("删除成功");
                        break;
                    default:
                        break;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DBHelper.NUM = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                Form p = new Update();
                p.ShowDialog();
            }
        }

        private void cheak_Tick(object sender, EventArgs e)
        {
            if (DBHelper.Refresh)
            {
                DBHelper.Refresh = false;
                switch (DBHelper.target)
                {
                    case "student":
                        Student stu = new Student();
                        dataGridView1.DataSource = stu.query().Tables[0];
                        break;
                    case "teacher":
                        Teacher tea = new Teacher();
                        dataGridView1.DataSource = tea.query().Tables[0];
                        break;
                    case "room":
                        Room rom = new Room();
                        dataGridView1.DataSource = rom.query().Tables[0];
                        break;
                    default:
                        break;
                }
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            DBHelper.Variable = true;
            Form p = new Function();
            p.Show();
            this.Close();
        }



        private void Main_interface_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                this.Opacity = 0;
            }
            else
            {
                notifyIcon1.Visible = false;
                this.Opacity = 1;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLocalTime().ToString();
        }
    }
}
