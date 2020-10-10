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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (DBHelper.target)
            {
                case "student":
                    Student stu = new Student();
                    stu.add(textBox1.Text, textBox2.Text, textBox1.Text, textBox4.Text, textBox5.Text);
                    break;
                case "teacher":
                    Teacher tea = new Teacher();
                    tea.add(textBox1.Text, textBox2.Text, textBox1.Text, textBox4.Text, textBox5.Text);
                    label1.Text = "教师编号";
                    label2.Text = "教师名称";
                    label3.Text = "教师性别";
                    label4.Text = "教师单位";
                    label5.Text = "教师生日";
                    break;
                case "room":
                    Room rom = new Room();
                    rom.add(textBox1.Text, textBox2.Text, textBox1.Text, textBox4.Text, textBox5.Text);
                    label1.Text = "房间编号";
                    label2.Text = "房间类型";
                    label3.Text = "房间位置";
                    label4.Text = "房间情况";
                    label5.Text = "是否居住";
                    break;
                default:
                    break;
            }

            DBHelper.Refresh = true;
            MessageBox.Show("增加成功");
            this.Close();
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

        private void Add_Load(object sender, EventArgs e)
        {
            switch (DBHelper.target)
            {
                case "student":
       
                    break;
                case "teacher":
                 
                    label1.Text = "教师编号";
                    label2.Text = "教师名称";
                    label3.Text = "教师性别";
                    label4.Text = "教师单位";
                    label5.Text = "教师生日";
                    break;
                case "room":
         
                    label1.Text = "房间编号";
                    label2.Text = "房间类型";
                    label3.Text = "房间位置";
                    label4.Text = "房间情况";
                    label5.Text = "是否居住";
                    break;
                default:
                    break;
            }
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            monthCalendar1.Enabled = true;
            monthCalendar1.Visible = true;
            qd.Enabled = true;
            qd.Visible = true;
            textBox5.Enabled = false;
        }

        private void qd_Click(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
            string starttime = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
            textBox5.Text = starttime;
            monthCalendar1.Enabled = false;
            monthCalendar1.Visible = false;
            qd.Enabled = false;
            qd.Visible = false;
        }
    }
}
