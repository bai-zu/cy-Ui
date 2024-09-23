using cy_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cy_DLL
{
    public class StudentDAL
    {
        //查询全部（未被删除数据）
        public List<Student> LogOnStudent()
        {
            string sql = "SELECT * FROM student WHERE mark=0";
            List<Student> students = new List<Student>();
            MySqlDataReader mySqlDataReader = SqlHelper.Query(sql);
            while (mySqlDataReader.Read())
            {
                students.Add(
                    new Student()
                    {
                        Sno = mySqlDataReader.GetString(0),
                        Sname = mySqlDataReader.GetString(1),
                        Ssex = mySqlDataReader.GetString(2),
                        Sage = mySqlDataReader.GetInt32(3),
                        Sdept = mySqlDataReader.GetString(4),
                    }) ;
            }
            return students;
        }
        //查询全部（已被删除数据）
        public List<Student> LogOnDeleteStudent()
        {
            string sql = "SELECT * FROM student WHERE mark=1";
            List<Student> students = new List<Student>();
            MySqlDataReader mySqlDataReader = SqlHelper.Query(sql);
            while (mySqlDataReader.Read())
            {
                students.Add(
                    new Student()
                    {
                        Sno = mySqlDataReader.GetString(0),
                        Sname = mySqlDataReader.GetString(1),
                        Ssex = mySqlDataReader.GetString(2),
                        Sage = mySqlDataReader.GetInt32(3),
                        Sdept = mySqlDataReader.GetString(4),
                    });
            }
            return students;
        }
        //逻辑删除
        public int DeleteStudent(string id)
        {

            int r = 0;
            string sql = "UPDATE student SET mark=1 WHERE Sno ='"+id+"';";
            r = SqlHelper.AddDeleteAndModify(sql);
            return r;
        }
        //逻辑恢复
        public int RestoreStudent(string id)
        {

            int r = 0;
            string sql = "UPDATE student SET mark=0 WHERE Sno ='" + id + "';";
            r = SqlHelper.AddDeleteAndModify(sql);
            return r;
        }
        //添加
        public int InsertStudent(Student student)
        {
            int r = 0;
            Random rd = new Random();
            int id = rd.Next();
            string sql = "insert into student(Sno,Sname,Ssex,Sage,Sdept,mark) value('" + id + "','" + student.Sname + "','" + student.Ssex + "','" + student.Sage + "','" + student.Sdept + "',0)";
            r = SqlHelper.AddDeleteAndModify(sql);
            return r;
        }
        //根据id查询
        public Student QueryIdStudent(string id)
        {
            string sql = "SELECT * FROM student WHERE mark= 0 And Sno = '"+id+"'";
            Student students = new Student();
            MySqlDataReader mySqlDataReader = SqlHelper.Query(sql);
            while (mySqlDataReader.Read())
            {
                students = new Student()
                {
                    Sno = mySqlDataReader.GetString(0),
                    Sname = mySqlDataReader.GetString(1),
                    Ssex = mySqlDataReader.GetString(2),
                    Sage = mySqlDataReader.GetInt32(3),
                    Sdept = mySqlDataReader.GetString(4),
                };
            }
            return students;
        }
        //修改数据
        public int ModifyStudent(Student student)
        {

            int r = 0;
            string sql = "UPDATE student SET Sname='"+student.Sname+"',Ssex='"+student.Ssex+"',Sage='"+student.Sage+"',Sdept='"+student.Sdept+"' WHERE Sno ='" + student.Sno + "';";
            r = SqlHelper.AddDeleteAndModify(sql);
            return r;
        }
    }
}
