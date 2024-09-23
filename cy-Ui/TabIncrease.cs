using cy_BLL;
using cy_Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace cy_Ui
{
    public partial class TabIncrease : Form
    {
        Tabs tab =new Tabs();
        TableBLL table = new TableBLL();
        CompartmentBLL compartment = new CompartmentBLL();
        List<Compartment> compartments=new List<Compartment>();
        public TabIncrease(Tabs tab)
        {
            InitializeComponent();
            this.tab = tab;
        }

        private void TabIncrease_Load(object sender, EventArgs e)
        {
            compartments = compartment.LogOnNoStateCompartments();
            foreach (Compartment compartment in compartments)
            {
                comboBox1.Items.Add(compartment.Name);
            }
            if (tab.Name != null)
            {
                textBox1.Text = tab.Name;
                comboBox2.Visible = true;
                label3.Visible = false;
                foreach (Compartment compartment in compartments)
                {
                    if (tab.CompartmentId==compartment.Id)
                    {
                        comboBox1.Text = compartment.Name;
                        break;
                    }
                }
                if (tab.State == 1)
                {
                    comboBox2.Text = "空闲";
                }
                else
                {
                    comboBox2.Text = "已满";
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tab.Name == null)
            {
                tab.Name = textBox1.Text;
                foreach (Compartment compartment in compartments)
                {
                    if (comboBox1.Text == compartment.Name)
                    {
                        tab.CompartmentId = compartment.Id;
                        break;
                    }
                }
                if (table.InsertTabs(tab))
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
                tab.Name = textBox1.Text;
                foreach (Compartment compartment in compartments)
                {
                    if (comboBox1.Text == compartment.Name)
                    {
                        tab.CompartmentId = compartment.Id;
                        break;
                    }
                }
                if (comboBox2.Text == "空闲")
                {
                    tab.State = 1;
                }
                else
                {
                    tab.State = 0;
                }
                if (table.ModifyTabs(tab))
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
    }
}
