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
using System.Xml.Linq;

namespace cy_Ui
{
    public partial class DishForm : Form
    {
        public DishForm()
        {
            InitializeComponent();
        }
        public static string  name = "";
        public static Dish dish = new Dish();
        public static int sort = 0;
        public static long id = 0;
        public static List<Category> list=new List<Category>();
        List<Dish> dishList = new List<Dish>();
        CategoryBLL categoryBLL = new CategoryBLL();
        DishBLL dishBLL = new DishBLL();
        private void DishForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            List<Category> categorys = categoryBLL.LogOnCategorys();
            List<Dish> dishs = dishBLL.LogOnDishs();
            for (int i = 0; i < categorys.Count; i++)
            {
                this.dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = categorys[i].Name;
                dataGridView1.Rows[i].Cells[1].Value = categorys[i].Sort;
                dataGridView1.Rows[i].Cells[2].Value = categorys[i].Description;
                list.Add(
                    new Category
                    {
                        Id = categorys[i].Id,
                        Name = categorys[i].Name,
                    });
            }
            for (int i = 0; i < dishs.Count; i++)
            {
                this.dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = dishs[i].Id;
                dataGridView2.Rows[i].Cells[1].Value = dishs[i].Name;
                dataGridView2.Rows[i].Cells[2].Value = dishs[i].Price;
                dataGridView2.Rows[i].Cells[3].Value = dishs[i].Description;
                dishList.Add(
                    new Dish
                    {
                        CategoryId = dishs[i].CategoryId,
                    });

            }
           /* MessageBox.Show(dishs[0].Price.ToString());
            MessageBox.Show(dishs[0].Code);
            MessageBox.Show(dishs[0].Description);*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = "添加";
            CategoryIncrease dishIncrease = new CategoryIncrease();
            //隐藏
            this.Hide();
            //模态显示窗口
            dishIncrease.ShowDialog();
            //退出当前窗口
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            name = "修改";
            CategoryIncrease dishIncrease = new CategoryIncrease();
            int Index = this.dataGridView1.CurrentRow.Index;//获取当前选中行的索引
            sort = int.Parse(dataGridView1.Rows[Index].Cells[1].Value.ToString());

            //隐藏
            this.Hide();
            //模态显示窗口
            dishIncrease.ShowDialog();
            //退出当前窗口
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Index = this.dataGridView1.CurrentRow.Index;//获取当前选中行的索引
            sort = int.Parse(dataGridView1.Rows[Index].Cells[1].Value.ToString());
            try
            {

                if (categoryBLL.DeleteSortCategorys(sort))
                {
                    MessageBox.Show("删除成功");
                    DishForm_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("删除失败");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            name = "添加";
            DishIncrease dishIncrease = new DishIncrease();
            this.Hide();
            //模态显示窗口
            dishIncrease.ShowDialog();
            //退出当前窗口
            this.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            name = "修改";
            int Index = this.dataGridView2.CurrentRow.Index;//获取当前选中行的索引
            //MessageBox.Show(dishList[Index].CategoryId.ToString());
            dish.CategoryId =dishList[Index].CategoryId;
            dish.Id = long.Parse(dataGridView2.Rows[Index].Cells[0].Value.ToString());
            dish.Name = dataGridView2.Rows[Index].Cells[1].Value.ToString();
            dish.Price = int.Parse(dataGridView2.Rows[Index].Cells[2].Value.ToString());
            dish.Description = dataGridView2.Rows[Index].Cells[3].Value.ToString();
            //dushId
            DishIncrease dishIncrease = new DishIncrease();
            this.Hide();
            //模态显示窗口
            dishIncrease.ShowDialog();
            //退出当前窗口
            this.Dispose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int Index = this.dataGridView2.CurrentRow.Index;//获取当前选中行的索引
            id = long.Parse(dataGridView2.Rows[Index].Cells[0].Value.ToString());
            if (dishBLL.DeleteDishs(id))
            {
                MessageBox.Show("删除成功");
                DishForm_Load(sender, e);
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }
    }
}
