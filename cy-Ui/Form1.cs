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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           /* UserBLL userBLL = new UserBLL();
            List<User> users= userBLL.GetUsers();
            foreach (var item in users)
            {
                //MessageBox.Show(item.userId.ToString());
            }*/

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string paw = textBox2.Text.Trim();
            User user = new User();
            user.userName = name;
            user.passWord = paw;
            if (name ==null|| name =="")
            {
                MessageBox.Show("账号不能为空");
                return;
            }
            else if (paw == null || paw== "")
            {
                MessageBox.Show("密码不能为空");
                return;
            }
            else
            {
                UserBLL userBLL = new UserBLL();
                List<User> users = userBLL.LogOnUsers(user);
                if (users.Count > 0)
                {
                    MessageBox.Show("登录成功");
                    Member member = new Member();
                    //member.Show();
                    //隐藏
                    this.Hide();
                    //模态显示窗口
                    member.ShowDialog();
                    //退出当前窗口
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("账号或密码错误");
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            //隐藏
            this.Hide();
            //模态显示窗口
            register.ShowDialog();
            //退出当前窗口
            this.Dispose();
        }
    }
}
