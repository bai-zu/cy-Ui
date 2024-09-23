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
    public partial class StudentIncrease : Form
    {
        public StudentIncrease()
        {
            InitializeComponent();
        }
        StudentBLL studentBLL = new StudentBLL();
        private void button1_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Sname=textBox1.Text;
            student.Sage = int.Parse(numericUpDown1.Value.ToString());
            student.Sdept=textBox2.Text;
            if (radioButton2.Checked)
            {
                student.Ssex = "女";
            }
            else
            {
                student.Ssex = "男";
            }
            if (button1.Text == "添加")
            {
                if (studentBLL.InsertStudents(student))
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
                student.Sno = BasicInformation.r;
                if (studentBLL.ModifyStudents(student))
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

        private void StudentIncrease_Load(object sender, EventArgs e)
        {
            if (BasicInformation.r!="")
            {
                string id = BasicInformation.r;
                Student student = studentBLL.QueryIdStudents(id);
                textBox1.Text = student.Sname;
                numericUpDown1.Value= student.Sage;
                textBox2.Text = student.Sdept;
                if (student.Ssex=="男")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                button1.Text = "修改";
            }
        }
    }
}
