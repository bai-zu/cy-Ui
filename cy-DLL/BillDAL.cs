using cy_Model;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cy_DLL
{
    public class BillDAL
    {
        public int InsertBill(Bill bill)
        {
            int r = 0;
            string sql = "insert into bill(id,type,number,notes,total,state,tab_id) value(" + bill.Id+",'"+bill.Type+"',"+bill.Number+",'"+bill.Notes+"',0,0,"+bill.TabId+")";
            r = SqlHelper.AddDeleteAndModify(sql);
            return r;
        }
        public int InsertTotalBill(Bill bill)
        {
            string sql = "UPDATE bill SET total = total+" + bill.Total+" WHERE id ="+bill.Id;
            return SqlHelper.AddDeleteAndModify(sql);
            //UPDATE bill SET total = 2024 WHERE id = 1001
        }
        public Bill LogOnTabIdBill(int id)
        {
            string sql = "SELECT * FROM bill WHERE state=0 and tab_id="+id;
            Bill bill = new Bill();
            MySqlDataReader mySqlDataReader = SqlHelper.Query(sql);
            while (mySqlDataReader.Read())
            {

                bill = new Bill()
                {
                    Id = mySqlDataReader.GetInt32(0),
                    Type = mySqlDataReader.GetString(1),
                    Number = mySqlDataReader.GetInt32(2),
                    Notes = mySqlDataReader.GetString(3),
                    Total = mySqlDataReader.GetInt64(4),
                    State = mySqlDataReader.GetInt32(5),
                    TabId = mySqlDataReader.GetInt32(6)
                };
            }
            return bill;
        }
        public int CheckoutBill(int id)
        {
            string sql = "UPDATE bill SET state = 1 WHERE id =" + id;
            return SqlHelper.AddDeleteAndModify(sql);
        }
    }
}
