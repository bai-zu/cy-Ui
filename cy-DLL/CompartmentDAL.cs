using cy_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cy_DLL
{
    public class CompartmentDAL
    {
        //查询所有（state=1）
        public List<Compartment> LogOnCompartment()
        {
            string sql = "SELECT * FROM compartment WHERE state=1";
            List<Compartment> compartments = new List<Compartment>();
            MySqlDataReader mySqlDataReader = SqlHelper.Query(sql);
            while (mySqlDataReader.Read())
            {
                compartments.Add(
                    new Compartment()
                    {
                        Id = mySqlDataReader.GetInt32(0),
                        Name = mySqlDataReader.GetString(1),
                        State= mySqlDataReader.GetInt32(2),
                    });
            }
            return compartments;
        }
        //查询所有(包括state！=1)
        public List<Compartment> LogOnNoStateCompartment()
        {
            string sql = "SELECT * FROM compartment";
            List<Compartment> compartments = new List<Compartment>();
            MySqlDataReader mySqlDataReader = SqlHelper.Query(sql);
            while (mySqlDataReader.Read())
            {
                compartments.Add(
                    new Compartment()
                    {
                        Id = mySqlDataReader.GetInt32(0),
                        Name = mySqlDataReader.GetString(1),
                        State = mySqlDataReader.GetInt32(2),
                    });
            }
            return compartments;
        }
        public int InsertCompartment(Compartment compartment)
        {
            int r = 0;
            Random rd = new Random();
            int id = rd.Next();
            string sql = "insert into compartment(id,name,state) value(" + id + ",'" + compartment.Name + "',1)";
            r = SqlHelper.AddDeleteAndModify(sql);
            return r;
        }
        public int ModifyCompartment(Compartment compartment)
        {
            int r = 0;
            string sql = "UPDATE compartment SET name='" + compartment.Name + "',state=" + compartment.State + " WHERE id =" + compartment.Id + ";";
            r = SqlHelper.AddDeleteAndModify(sql);
            return r;
        }
        //删除
        public int DeleteIdCompartment(int id)
        {
            int r = 0;
            string sql = "DELETE FROM compartment WHERE id=" + id;
            r = SqlHelper.AddDeleteAndModify(sql);
            return r;
        }
    }
}
