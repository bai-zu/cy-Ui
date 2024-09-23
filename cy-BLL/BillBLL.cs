using cy_DLL;
using cy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cy_BLL
{
    public class BillBLL
    {
        BillDAL billDAL = new BillDAL();
        public bool InsertBills(Bill bill)
        {
            return billDAL.InsertBill(bill)>0;
        }
        public Bill LogOnTabIdBills(int id)
        {
            return billDAL.LogOnTabIdBill(id);
        }
        public bool CheckoutBills(int id)
        {
            return billDAL.CheckoutBill(id) > 0;
        }
    }
}
