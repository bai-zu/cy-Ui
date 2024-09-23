using cy_DLL;
using cy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cy_BLL
{
    public class TableBLL
    {
        TableDAL tableDAL = new TableDAL();
        public List<Tabs> GetCompartmentIdTables(int compartmentId)
        {
            return tableDAL.GetCompartmentIdTable(compartmentId);
        }
        public List<Tabs> GetTables()
        {
            return tableDAL.GetTable();
        }
        public bool InsertTabs(Tabs tab)
        {
            return tableDAL.InsertTab(tab) > 0;
        }
        public bool ModifyTabs(Tabs tab)
        {
            return tableDAL.ModifyTab(tab) > 0;
        }
        public bool DeleteIdTabs(int id)
        {
            return tableDAL.DeleteIdTab(id) > 0;
        }
    }
}
