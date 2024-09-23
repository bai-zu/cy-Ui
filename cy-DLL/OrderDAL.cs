using cy_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cy_DLL
{
    public class OrderDAL
    {
        public bool InsertOrder(Order order)
        {
            int r = 0;
            int r1 = 0;
            bool a=false;
            long id = SqlHelper.GetNumberOID();
            string sql = "insert into orde(id,name,monovalent,number,total,bill_id) value(" + id + ",'" + order.Name + "'," + order.Monovalent + "," + order.Number + "," + order.Total +"," +order.BillId+")";
            r = SqlHelper.AddDeleteAndModify(sql);
            BillDAL billDAL = new BillDAL();
            Bill bill = new Bill();
            bill.Id = (int)order.BillId;
            bill.Total = order.Total;
            r1=billDAL.InsertTotalBill(bill);
            if (r1>0&&r>0)
            {
                a = true;
            }
            return a;
        }
        public List<Order> LogOnBillIdOrder(int id)
        {
            string sql = "SELECT * FROM orde WHERE bill_id="+id;
            List<Order> orders = new List<Order>();
            MySqlDataReader mySqlDataReader = SqlHelper.Query(sql);
            while (mySqlDataReader.Read())
            {
                orders.Add(
                    new Order()
                    {
                        Id = mySqlDataReader.GetInt64(0),
                        Name = mySqlDataReader.GetString(1),
                        Monovalent = mySqlDataReader.GetInt64(2),
                        Number= mySqlDataReader.GetInt32(3),
                        Total  =  mySqlDataReader.GetInt64(4),
                        BillId= mySqlDataReader.GetInt32(5),
                    });
            }
            return orders;
        }
    }
}
