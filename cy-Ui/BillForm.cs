using cy_BLL;
using cy_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cy_Ui
{
    public partial class BillForm : Form
    {
        public BillForm()
        {
            InitializeComponent();
        }

        private void BillForm_Load(object sender, EventArgs e)
        {
            label2.Text = Member.tab.Id.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bill bill = new Bill();
            bill.Type = textBox1.Text;
            bill.Number= (int)numericUpDown1.Value;
            bill.Notes = richTextBox1.Text;
            bill.TabId = int.Parse(label2.Text);
            Random rd = new Random();
            int id = rd.Next();
            bill.Id = id;
            BillBLL billBLL = new BillBLL();
            if (billBLL.InsertBills(bill))
            {
                MessageBox.Show("添加成功");
                if (checkBox1.Checked)
                {
                    //MessageBox.Show("添加消费");
                    
                    OrderForm orderForm = new OrderForm(bill);
                    orderForm.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }
    }
}
