using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cy_Ui.Control
{
    public partial class Member_Control01 : UserControl
    {
        public Member_Control01()
        {
            InitializeComponent();
        }
        private string label;
        public string Label
        {
            get { return label; }
            set
            {
                label = value;
                this.label1.Text = label;
            }
        }
        //定义委托
        public delegate void BtnClickHandle(object sender, EventArgs e);
        //定义事件
        public event BtnClickHandle UserControlBtnClicked;
        private void button1_Click(object sender, EventArgs e)
        {
            if (UserControlBtnClicked != null)
                UserControlBtnClicked(sender, new EventArgs());//把按钮自身作为参数传递
        }

        //private string tag;
        /*public string Tag
        {
            get { return tag; }
            set
            {
                tag = value;
                this.textBox1.Tag = tag;
            }
        }

        private string varvalue;
        public string VarValue
        {
            get { return varvalue; }
            set
            {
                varvalue = value;
                this.textBox1.Text = varvalue;
            }
        }*/

        //给textbox添加事件，使改变该控件的text值时，将该值写入到属性VarValue中
        /*private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            //VarValue = this.textBox1.Text;
        }*/
    }
}
