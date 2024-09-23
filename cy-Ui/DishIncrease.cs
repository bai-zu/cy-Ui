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
    public partial class DishIncrease : Form
    {
        public DishIncrease()
        {
            InitializeComponent();
        }
        Dish dish = new Dish();
        //CategoryBLL categoryBLL = new CategoryBLL();
        DishBLL dishBLL = new DishBLL();
        private void DishIncrease_Load(object sender, EventArgs e)
        {
            button1.Text = DishForm.name;
            //DishForm.list
            //comboBox1.Items.Add(DishForm.list);
            for (int i = 0; i < DishForm.list.Count; i++)
            {
                comboBox1.Items.Add(DishForm.list[i].Name);
                if (DishForm.dish.CategoryId== DishForm.list[i].Id)
                {
                    comboBox1.Text = DishForm.list[i].Name;
                }
            }
            textBox1.Text = DishForm.dish.Name;
            textBox1.Text = DishForm.dish.Name;
            numericUpDown1.Value= (decimal)DishForm.dish.Price;
            richTextBox1.Text = DishForm.dish.Description;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //comboBox1.Text;
            dish.Name = textBox1.Text;
            dish.Price = (double)numericUpDown1.Value;
            dish.Description= richTextBox1.Text;
            if (comboBox1.Text != "请选择")
            {
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    if (DishForm.list[i].Name == comboBox1.Text)
                    {
                        dish.CategoryId = DishForm.list[i].Id;
                        break;
                    }
                }
                //MessageBox.Show(textBox1.Text);
                if (button1.Text == "修改")
                {
                    dish.Id = DishForm.dish.Id;
                    MessageBox.Show(DishForm.dish.Id.ToString());
                    try
                    {
                        if (dishBLL.ModifyDishs(dish))
                        {
                            MessageBox.Show(button1.Text + "成功");
                        }
                        else
                        {
                            MessageBox.Show(button1.Text + "失败");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("名字需要是唯一的");
                    }
                    
                }
                else
                {
                    //dish.CategoryId = categoryBLL.GetNameCategorys(comboBox1.Text);
                    if (dishBLL.InsertDishs(dish))
                    {
                        MessageBox.Show(button1.Text + "成功");
                    }
                    else
                    {
                        MessageBox.Show(button1.Text + "失败");
                    }
                }

            }
            else
            {
                MessageBox.Show("请选择类别");
            }
        }
    }
}
