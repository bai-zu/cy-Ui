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
    public partial class CheckoutForm : Form
    {
        Bill bill=new Bill();
        OrderBLL orderBLL=new OrderBLL();
        public CheckoutForm(Bill bill)
        {
            InitializeComponent();
            this.bill = bill;
        }

        private void CheckoutForm_Load(object sender, EventArgs e)
        {
            label10.Text = bill.Id.ToString();
            label11.Text= Member.tab.Name;
            label4.Text = bill.Total.ToString();
            label7.Text= bill.Total.ToString();
            dataGridView1.Rows.Clear();
            orderBLL = new OrderBLL();
            List<Order> orders = orderBLL.LogOnBillIdOrders(bill.Id);
            for (int i = 0; i < orders.Count; i++)
            {
                //dgv.Rows.Add();
                this.dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = orders[i].Name;
                dataGridView1.Rows[i].Cells[1].Value = orders[i].Monovalent;
                dataGridView1.Rows[i].Cells[2].Value = orders[i].Number;
                dataGridView1.Rows[i].Cells[3].Value = orders[i].Total;

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label9.Text= (int.Parse(textBox1.Text)- int.Parse(label7.Text)).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(label9.Text) >= 0)
            {
                BillBLL billBLL = new BillBLL();
                if (billBLL.CheckoutBills(bill.Id))
                {
                    MessageBox.Show("结账成功,找零:"+ label9.Text);
                    Member member = new Member();
                    //隐藏
                    this.Hide();
                    //模态显示窗口
                    member.ShowDialog();
                    //退出当前窗口
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("结账失败");
                }
            }
            else
            {
                MessageBox.Show("请确认付钱金额大于消费金额");
            }
        }
    }
}
