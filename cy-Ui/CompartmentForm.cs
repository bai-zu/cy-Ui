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
    public partial class CompartmentForm : Form
    {
        public CompartmentForm()
        {
            InitializeComponent();
        }
        public Compartment compartment = new Compartment();
        public Tabs table = new Tabs();
        List<Compartment> compartments= new List<Compartment>();
        private void CompartmentForm_Load(object sender, EventArgs e)
        {
            CompartmentBLL compartmentBLL = new CompartmentBLL();
            TableBLL tableBLL = new TableBLL();
            compartments = compartmentBLL.LogOnNoStateCompartments();
            List<Tabs> tabs = tableBLL.GetTables();
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            for (int i = 0; i < compartments.Count; i++)
            {
                //dgv.Rows.Add();
                this.dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = compartments[i].Id;
                dataGridView1.Rows[i].Cells[1].Value = compartments[i].Name;
                if (compartments[i].State==1)
                {
                    dataGridView1.Rows[i].Cells[2].Value = "空闲";
                }
                else
                {
                    dataGridView1.Rows[i].Cells[2].Value = "已满";
                }
            }
            for (int i = 0; i < tabs.Count; i++)
            {
                //dgv.Rows.Add();
                this.dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = tabs[i].Id;
                dataGridView2.Rows[i].Cells[1].Value = tabs[i].Name;
                if (tabs[i].State == 1)
                {
                    dataGridView2.Rows[i].Cells[2].Value = "空闲";
                }
                else
                {
                    dataGridView2.Rows[i].Cells[2].Value = "已满";
                }
                for (int j = 0; j < compartments.Count; j++)
                {
                    if (tabs[i].CompartmentId== compartments[j].Id)
                    {
                        dataGridView2.Rows[i].Cells[3].Value = compartments[j].Name;
                        break;
                    }
                    
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CompartmentIncrease compartmentIncrease = new CompartmentIncrease(compartment);
            //隐藏
            this.Hide();
            //模态显示窗口
            compartmentIncrease.ShowDialog();
            //退出当前窗口
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int Index = this.dataGridView1.CurrentRow.Index;//获取当前选中行的索引
            compartment.Id = int.Parse(dataGridView1.Rows[Index].Cells[0].Value.ToString());
            compartment.Name = dataGridView1.Rows[Index].Cells[1].Value.ToString();
            if (dataGridView1.Rows[Index].Cells[2].Value.ToString()=="空闲")
            {
                compartment.State = 1;
            }
            else
            {
                compartment.State = 0;
            }
            CompartmentIncrease compartmentIncrease = new CompartmentIncrease(compartment);
            //sort = int.Parse(dataGridView1.Rows[Index].Cells[1].Value.ToString());
            //隐藏
            this.Hide();
            //模态显示窗口
            compartmentIncrease.ShowDialog();
            //退出当前窗口
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TabIncrease tabIncrease = new TabIncrease(table);
            //隐藏
            this.Hide();
            //模态显示窗口
            tabIncrease.ShowDialog();
            //退出当前窗口
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Index = this.dataGridView1.CurrentRow.Index;//获取当前选中行的索引
            int id = int.Parse(dataGridView1.Rows[Index].Cells[0].Value.ToString());
            CompartmentBLL compartmentBLL = new CompartmentBLL();
            if (compartmentBLL.DeleteIdCompartment(id))
            {
                MessageBox.Show("删除成功");
                CompartmentForm_Load(sender, e);
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int Index = this.dataGridView2.CurrentRow.Index;//获取当前选中行的索引
            table.Id = int.Parse(dataGridView2.Rows[Index].Cells[0].Value.ToString());
            table.Name = dataGridView2.Rows[Index].Cells[1].Value.ToString();
            if (dataGridView2.Rows[Index].Cells[2].Value.ToString() == "空闲")
            {
                table.State = 1;
            }
            else
            {
                table.State = 0;
            }
            foreach (var item in compartments)
            {
                if (item.Name== dataGridView2.Rows[Index].Cells[3].Value.ToString())
                {
                    table.CompartmentId = item.Id;
                }
            }
            TabIncrease tabIncrease = new TabIncrease(table);
            //隐藏
            this.Hide();
            //模态显示窗口
            tabIncrease.ShowDialog();
            //退出当前窗口
            this.Dispose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int Index = this.dataGridView2.CurrentRow.Index;//获取当前选中行的索引
            int id = int.Parse(dataGridView2.Rows[Index].Cells[0].Value.ToString());
            TableBLL tableBLL =new TableBLL();
            if (tableBLL.DeleteIdTabs(id))
            {
                MessageBox.Show("删除成功");
                CompartmentForm_Load(sender, e);
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }
    }
}
