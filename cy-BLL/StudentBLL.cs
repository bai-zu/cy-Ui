using cy_DLL;
using cy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cy_BLL
{
    public class StudentBLL
    {
        public List<Student> LogOnStudents()
        {
            StudentDAL studentrDAL = new StudentDAL();
            return studentrDAL.LogOnStudent();
        }
        public List<Student> LogOnDeleteStudents()
        {
            StudentDAL studentrDAL = new StudentDAL();
            return studentrDAL.LogOnDeleteStudent();
        }
        public bool DeleteStudents(string id)
        {
            StudentDAL studentrDAL = new StudentDAL();
            return studentrDAL.DeleteStudent(id)>0;
        }
        public bool RestoreStudents(string id)
        {

            StudentDAL studentrDAL = new StudentDAL();
            return studentrDAL.RestoreStudent(id) > 0;
        }
        public bool InsertStudents(Student student)
        {
            StudentDAL studentrDAL = new StudentDAL();
            return studentrDAL.InsertStudent(student) > 0;
        }
        public Student QueryIdStudents(string id)
        {
            StudentDAL studentrDAL = new StudentDAL();
            return studentrDAL.QueryIdStudent(id);
        }
        public bool ModifyStudents(Student student)
        {
            StudentDAL studentrDAL = new StudentDAL();
            return studentrDAL.ModifyStudent(student) > 0;
        }
    }
}
