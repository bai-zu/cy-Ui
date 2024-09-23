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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace cy_Ui
{
    public partial class CompartmentIncrease : Form
    {
        Compartment compartment=new Compartment();
        CompartmentBLL compartmentBLL = new CompartmentBLL();
        public CompartmentIncrease(Compartment compartment)
        {
            InitializeComponent();
            this.compartment = compartment;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (compartment==null)
            {
                compartment.Name = textBox1.Text;
                if (compartmentBLL.InsertCompartments(compartment))
                {
                    MessageBox.Show("添加成功");
                    CompartmentForm compartmentForm = new CompartmentForm();
                    //隐藏
                    this.Hide();
                    //模态显示窗口
                    compartmentForm.ShowDialog();
                    //退出当前窗口
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            else
            {
                compartment.Name = textBox1.Text;
                if (comboBox1.Text == "空闲")
                {
                    compartment.State = 1;
                }
                else
                {
                    compartment.State = 0;
                }
                if (compartmentBLL.ModifyCompartments(compartment))
                {
                    MessageBox.Show("修改成功");
                    CompartmentForm compartmentForm = new CompartmentForm();
                    //隐藏
                    this.Hide();
                    //模态显示窗口
                    compartmentForm.ShowDialog();
                    //退出当前窗口
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }

        }

        private void CompartmentIncrease_Load(object sender, EventArgs e)
        {
            if (compartment != null)
            {
                textBox1.Text = compartment.Name;
                comboBox1.Visible = true;
                label3.Visible = false;
                if (compartment.State == 1)
                {
                    comboBox1.Text = "空闲";
                }
                else
                {
                    comboBox1.Text = "已满";
                }
            }
        }
    }
}
