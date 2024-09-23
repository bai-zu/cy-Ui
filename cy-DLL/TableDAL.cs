using cy_Model;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cy_DLL
{
    public class TableDAL
    {
        //根据compartment_id查询所有
        public List<Tabs> GetCompartmentIdTable(int compartmentId)
        {
            List<Tabs> result = new List<Tabs>();
            string sql = "SELECT * FROM tab WHERE state=1 and compartment_id=" + compartmentId;
            MySqlDataReader mySqlDataReader = SqlHelper.Query(sql);
            while (mySqlDataReader.Read())
            {
                result.Add(
                    new Tabs
                    {
                        Id = mySqlDataReader.GetInt32(0),
                        Name = mySqlDataReader.GetString(1),
                        State = mySqlDataReader.GetInt32(2),
                        CompartmentId = mySqlDataReader.GetInt32(3),
                    }
            );
                //id = mySqlDataReader.GetInt64(0);
            }
            return result;
        }
        //查询所有
        public List<Tabs> GetTable()
        {
            List<Tabs> result = new List<Tabs>();
            string sql = "SELECT * FROM tab WHERE state=1";
            MySqlDataReader mySqlDataReader = SqlHelper.Query(sql);
            while (mySqlDataReader.Read())
            {
                result.Add(
                    new Tabs
                    {
                        Id = mySqlDataReader.GetInt32(0),
                        Name = mySqlDataReader.GetString(1),
                        State = mySqlDataReader.GetInt32(2),
                        CompartmentId = mySqlDataReader.GetInt32(3),
                    }
                );
            }
            return result;
        }
        public int InsertTab(Tabs tab)
        {
            int r = 0;
            Random rd = new Random();
            int id = rd.Next();
            string sql = "insert into tab(id,name,state,compartment_id) value(" + id + ",'" + tab.Name + "',1,"+tab.CompartmentId+")";
            r = SqlHelper.AddDeleteAndModify(sql);
            return r;
        }
        public int ModifyTab(Tabs tab)
        {
            int r = 0;
            string sql = "UPDATE tab SET name='" + tab.Name + "',state=" + tab.State + ",compartment_id="+tab.CompartmentId+" WHERE id =" + tab.Id + ";";
            r = SqlHelper.AddDeleteAndModify(sql);
            return r;
        }
        //删除
        public int DeleteIdTab(int id)
        {
            int r = 0;
            string sql = "DELETE FROM tab WHERE id=" + id;
            r = SqlHelper.AddDeleteAndModify(sql);
            return r;
        }
    }
}
