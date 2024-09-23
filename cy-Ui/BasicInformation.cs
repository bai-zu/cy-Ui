using cy_BLL;
using cy_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cy_Ui
{
    public partial class BasicInformation : Form
    {
        public BasicInformation()
        {
            InitializeComponent();
        }
        StudentBLL studentBLL = new StudentBLL();
        StudentIncrease studentIncrease = new StudentIncrease();
        public static string r = "";
        private void BasicInformation_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<Student> students = studentBLL.LogOnStudents();
            for (int i = 0; i < students.Count; i++)
            {
                //dgv.Rows.Add();
                this.dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = students[i].Sno;
                dataGridView1.Rows[i].Cells[1].Value = students[i].Sname;
                dataGridView1.Rows[i].Cells[2].Value = students[i].Ssex;
                dataGridView1.Rows[i].Cells[3].Value = students[i].Sage;
                dataGridView1.Rows[i].Cells[4].Value = students[i].Sdept;
                dataGridView1.Rows[i].Cells[5].Value = "删除";
                dataGridView1.Rows[i].Cells[6].Value = "修改";

            }
            comboBox1.Text = "请选择";
            /* DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "btnModify";
            btn.HeaderText = "操作";
            btn.DefaultCellStyle.NullValue = "删除";
            dataGridView1.Columns.Add(btn);*/
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                int Index = this.dataGridView1.CurrentRow.Index;//获取当前选中行的索引
                string id = dataGridView1.Rows[Index].Cells[0].Value.ToString();
                if (Index < this.dataGridView1.Rows.Count - 1 && this.dataGridView1.CurrentCell.Value.ToString() == "删除")//"点击这里是之前设置按钮列的文本",
                {
                    //this.dataGridView1.CurrentCell.Value.ToString()== "点击这里";的用意是判断选中单元格是不是按钮单元格
                    if (studentBLL.DeleteStudents(id))
                    {
                        MessageBox.Show("删除成功");
                        //this.Invalidate();
                        BasicInformation_Load(sender,e);
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                    //MessageBox.Show(dataGridView1.Rows[Index].Cells[0].Value.ToString());
                }
                else if (Index < this.dataGridView1.Rows.Count - 1 && this.dataGridView1.CurrentCell.Value.ToString() == "修改")
                {
                    //studentIncrease
                    r = id;
                    studentIncrease.ShowDialog();
                }
                else if (Index < this.dataGridView1.Rows.Count - 1 && this.dataGridView1.CurrentCell.Value.ToString() == "恢复")
                {
                    if (studentBLL.RestoreStudents(id))
                    {
                        MessageBox.Show("恢复成功");
                        //this.Invalidate();
                        BasicInformation_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("恢复失败");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //隐藏
            //this.Hide();
            //模态显示窗口
            studentIncrease.ShowDialog();
            //退出当前窗口
            //this.Dispose();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text=="回收站")
            {
                dataGridView1.Rows.Clear();
                List<Student> students = studentBLL.LogOnDeleteStudents();
                for (int i = 0; i < students.Count; i++)
                {
                    //dgv.Rows.Add();
                    this.dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = students[i].Sno;
                    dataGridView1.Rows[i].Cells[1].Value = students[i].Sname;
                    dataGridView1.Rows[i].Cells[2].Value = students[i].Ssex;
                    dataGridView1.Rows[i].Cells[3].Value = students[i].Sage;
                    dataGridView1.Rows[i].Cells[4].Value = students[i].Sdept;
                    dataGridView1.Rows[i].Cells[5].Value = "恢复";
                    dataGridView1.Rows[i].Cells[6].Value = "修改";

                }
            }
            else
            {
                BasicInformation_Load(sender,e);
            }
            //MessageBox.Show(comboBox1.Text);
        }
    }
}
