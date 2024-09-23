using cy_BLL;
using cy_Model;
using cy_Ui.Control;
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
    public partial class Member : Form
    {
        public Member()
        {
            InitializeComponent();
        }
        List<Compartment> compartments = new List<Compartment>();
        int id = 0;
        string b = "";
        List<Tabs> tables = new List<Tabs>();
        public static Tabs tab=new Tabs();
        private void member_Control013_UserControlBtnClicked(object sender, EventArgs e)
        {
            BasicInformation basicInformation = new BasicInformation();
            //隐藏
            this.Hide();
            //模态显示窗口
            basicInformation.ShowDialog();
            //退出当前窗口
            this.Dispose();
        }

        private void member_Control014_UserControlBtnClicked(object sender, EventArgs e)
        {
            DishForm dishForm = new DishForm();
            //隐藏
            this.Hide();
            //模态显示窗口
            dishForm.ShowDialog();
            //退出当前窗口
            this.Dispose();
        }

        private void Member_Load(object sender, EventArgs e)
        {
            CompartmentBLL compartmentBLL = new CompartmentBLL();
            compartments = compartmentBLL.LogOnCompartment();
            for (int i = 1; i <= compartments.Count; i++)
            {
                //Button button = new Button();
                b="button"+i.ToString();
                if (b==button1.Text)
                {
                    button1.Text = compartments[i-1].Name;
                    button1.Visible = true;
                }
                else if(b == button2.Text)
                {
                    button2.Text = compartments[i-1].Name;
                    button2.Visible = true;
                }
                else if (b == button3.Text)
                {
                    button3.Text = compartments[i - 1].Name;
                    button3.Visible = true;
                }
                else if (b == button4.Text)
                {
                    button4.Text = compartments[i-1].Name;
                    button4.Visible = true;
                }
                else if (i==5)
                {
                    button9.Text = compartments[i - 1].Name;
                    button9.Visible = true;
                }
                else if (i == 6)
                {
                    button10.Text = compartments[i - 1].Name;
                    button10.Visible = true;
                }
                //button = (Button)b;
            }
            //panel9
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in compartments)
            {
                if (button1.Text == item.Name)
                {
                    id = item.Id;
                    break;
                }
            }
            IntegrationButton();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (var item in tables)
            {
                if (button5.Text == item.Name)
                {
                    tab=item;
                    BillBLL billBLL = new BillBLL();
                    Bill bill = billBLL.LogOnTabIdBills(tab.Id);
                    if (bill.Id!=0)
                    {
                        Checkout(bill);
                    }
                    else
                    {
                        Skip();
                    }
                    
                    //InsertBill(item);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var item in compartments)
            {
                if (button2.Text == item.Name)
                {
                    id = item.Id;
                    break;
                }
            }
            IntegrationButton();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var item in compartments)
            {
                if (button3.Text == item.Name)
                {
                    id = item.Id;
                    break;
                }
            }
            IntegrationButton();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var item in compartments)
            {
                if (button4.Text == item.Name)
                {
                    id = item.Id;
                    break;
                }
            }
            IntegrationButton();
        }
        private void IntegrationButton()
        {
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button5.Text = "button5";
            button6.Text = "button6";
            button7.Text = "button7";
            button8.Text = "button8";

            TableBLL tableBLL = new TableBLL();
            tables = tableBLL.GetCompartmentIdTables(id);
            int k = 5;
            foreach (var item in tables)
            {
                b = "button" + k.ToString();
                if (b == button5.Text)
                {
                    button5.Text = item.Name;
                    button5.Visible = true;
                }
                else if (b == button6.Text)
                {
                    button6.Text = item.Name;
                    button6.Visible = true;
                }
                else if (b == button7.Text)
                {
                    button7.Text = item.Name;
                    button7.Visible = true;
                }
                else if (b == button8.Text)
                {
                    button8.Text = item.Name;
                    button8.Visible = true;
                }
                k++;
                //Member_Control01 member_Control = new Member_Control01();

                //MessageBox.Show(item.Name);
            }
        }
        public void Skip()
        {
            BillForm billForm = new BillForm();
            billForm.Show();
        }
        private void Checkout(Bill bill)
        {
            CheckoutForm checkoutForm = new CheckoutForm(bill);
            this.Hide();
            //模态显示窗口
            checkoutForm.ShowDialog();
            //退出当前窗口
            this.Dispose();
        }

        private void member_Control015_UserControlBtnClicked(object sender, EventArgs e)
        {
            CompartmentForm compartmentForm = new CompartmentForm();
            //隐藏
            this.Hide();
            //模态显示窗口
            compartmentForm.ShowDialog();
            //退出当前窗口
            this.Dispose();
        }

        private void member_Control016_UserControlBtnClicked(object sender, EventArgs e)
        {

        }
    }
}
