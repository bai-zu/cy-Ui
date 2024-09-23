using cy_DLL;
using cy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cy_BLL
{
    public class OrderBLL
    {
        OrderDAL orderDAL = new OrderDAL();
        public bool InsertOrders(Order order)
        {
            return orderDAL.InsertOrder(order);
        }
        public List<Order> LogOnBillIdOrders(int id)
        {
            return orderDAL.LogOnBillIdOrder(id);
        }
    }
}
