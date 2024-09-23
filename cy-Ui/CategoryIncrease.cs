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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace cy_Ui
{
    public partial class CategoryIncrease : Form
    {
        public CategoryIncrease()
        {
            InitializeComponent();
        }
        CategoryBLL categoryBLL = new CategoryBLL();
        Category category = new Category();
        long id;
        //DishBLL dishBLL = new DishBLL();
        private void button1_Click(object sender, EventArgs e)
        {
            //Category category = new Category();
            category.Name = textBox1.Text;
            category.Sort = int.Parse(textBox2.Text);
            category.Description = richTextBox1.Text;
            if (radioButton1.Checked)
            {
                category.Type = 2;
            }
            else
            {
                category.Type = 1;
            }
            if (button1.Text == "添加")
            {
                if (categoryBLL.InsertCategorys(category))
                {
                    MessageBox.Show(button1.Text + "成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(button1.Text + "失败");
                }
            }
            else
            {
                if (categoryBLL.ModifyCategorys(category))
                {
                    MessageBox.Show(button1.Text + "成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(button1.Text + "失败");
                }
            }

        }

        private void DishIncrease_Load(object sender, EventArgs e)
        {
            button1.Text = DishForm.name;
            int sort = DishForm.sort;
            category = categoryBLL.GetNameCategorys(sort);
            
            if (category != null)
            {
                id = category.Id;
                textBox1.Text= category.Name;
                textBox2.Text= category.Sort.ToString();
                richTextBox1.Text= category.Description;
                if (category.Type == 2)
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
            }
            
            /*Dish dishes = dishBLL.GetNameDishs(categoryName);
            textBox1.Text=dishes.Name;
            category.Sort = int.Parse(textBox2.Text);
            category.Description = richTextBox1.Text;*/
            //MessageBox.Show(categoryName);

        }
    }
}
