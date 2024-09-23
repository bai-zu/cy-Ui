using cy_BLL;
using cy_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cy_Ui
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            UserBLL userBLL = new UserBLL();
            if (textBox2.Text!=textBox3.Text)
            {
                MessageBox.Show("请确认两次密码相同");
                return;
            }
            if (userBLL.GetUsers(textBox1.Text))
            {
                MessageBox.Show("账号已存在");
                return;
            }
            User user = new User();
            user.userName = textBox1.Text;
            user.passWord = textBox2.Text;
            user.userGroup = "游客";
            if (userBLL.InsertUsers(user))
            {
                MessageBox.Show("注册成功");
                Form1 form1 = new Form1();
                //隐藏
                this.Hide();
                //模态显示窗口
                form1.ShowDialog();
                //退出当前窗口
                this.Dispose();
            }
        }
    }
}
