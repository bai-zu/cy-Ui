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
    public partial class OrderForm : Form
    {
        public Bill bill=new Bill();
        DishBLL dishBLL = new DishBLL(); 
        int k = 0;
        double sum=0;
        OrderBLL orderBLL = new OrderBLL();
        public OrderForm(Bill bill)
        {
            this.bill = bill;
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            label4.Text=bill.TabId.ToString();
            List<Dish> dishs = dishBLL.LogOnDishs();
            for (int i = 0; i < dishs.Count; i++)
            {
                this.dataGridView1.Rows.Add();
                //dataGridView1.Rows[i].Cells[0].Value = dishs[i].Id;
                dataGridView1.Rows[i].Cells[0].Value = dishs[i].Name;
                dataGridView1.Rows[i].Cells[1].Value = dishs[i].Price;
                dataGridView1.Rows[i].Cells[2].Value = dishs[i].Description;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int Index = this.dataGridView1.CurrentRow.Index;//获取当前选中行的索引
                                                            //id = long.Parse(dataGridView2.Rows[Index].Cells[0].Value.ToString());
            bool a=true;
            for (int i = 0; i < k; i++)
            {
                if (dataGridView2.Rows[i].Cells[0].Value == dataGridView1.Rows[Index].Cells[0].Value)
                {
                    dataGridView2.Rows[i].Cells[2].Value = (int)dataGridView2.Rows[i].Cells[2].Value+1;
                    dataGridView2.Rows[i].Cells[3].Value = (double)dataGridView2.Rows[i].Cells[3].Value + (double)dataGridView1.Rows[Index].Cells[1].Value;
                    sum += (double)dataGridView1.Rows[Index].Cells[1].Value;
                    a = false;
                    break;
                }
            }
            if (a)
            {
                this.dataGridView2.Rows.Add();
                dataGridView2.Rows[k].Cells[0].Value = dataGridView1.Rows[Index].Cells[0].Value;
                dataGridView2.Rows[k].Cells[1].Value = dataGridView1.Rows[Index].Cells[1].Value;
                dataGridView2.Rows[k].Cells[2].Value = 1;
                dataGridView2.Rows[k].Cells[3].Value = dataGridView1.Rows[Index].Cells[1].Value;
                k++;
                sum += (double)dataGridView1.Rows[Index].Cells[1].Value;
            }
            label8.Text=sum.ToString();
            label9.Text = (int.Parse(label9.Text) + 1).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int Index = this.dataGridView2.CurrentRow.Index;//获取当前选中行的索引

            label9.Text = (int.Parse(label9.Text) - int.Parse(dataGridView2.Rows[Index].Cells[2].Value.ToString())).ToString();
            sum -= (double)dataGridView2.Rows[Index].Cells[3].Value;
            for (int i = Index; i <k-1; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = dataGridView2.Rows[i + 1].Cells[0].Value;
                dataGridView2.Rows[i].Cells[1].Value = dataGridView2.Rows[i + 1].Cells[1].Value;
                dataGridView2.Rows[i].Cells[2].Value = dataGridView2.Rows[i + 1].Cells[2].Value;
                dataGridView2.Rows[i].Cells[3].Value = dataGridView2.Rows[i + 1].Cells[3].Value;
            }
            //要关闭最后一行空白行
            //否则无法删除
            dataGridView2.Rows.RemoveAt(dataGridView2.Rows.Count - 1);
            k--;
            label8.Text = sum.ToString();
            //dataGridView2.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Order> orderList = new List<Order>();
            bool a=true;
            //Order order = new Order();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                Order order = new Order();
                order.Name = dataGridView2.Rows[i].Cells[0].Value.ToString();
                order.Monovalent = (double)dataGridView2.Rows[i].Cells[1].Value;
                order.Number = (int)dataGridView2.Rows[i].Cells[2].Value;
                order.Total = (double)dataGridView2.Rows[i].Cells[3].Value;
                order.BillId = bill.Id;
                orderList.Add(order);
                //MessageBox.Show(label4.Text);
            }
            foreach (var item in orderList)
            {
                //MessageBox.Show(item.Name);
                if (!orderBLL.InsertOrders(item))
                {
                    a= false;
                }
            }
            if (a)
            {
                MessageBox.Show("下单成功"); 
            }
            else
            {
                MessageBox.Show("下单失败");
            }
        }
    }
}
