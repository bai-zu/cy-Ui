using cy_DLL;
using cy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cy_BLL
{
    public class CompartmentBLL
    {
        CompartmentDAL compartmentDAL = new CompartmentDAL();
        public List<Compartment> LogOnCompartment()
        {
            return compartmentDAL.LogOnCompartment();
        }
        public bool InsertCompartments(Compartment compartment)
        {
            return compartmentDAL.InsertCompartment(compartment) > 0;
        }
        public bool ModifyCompartments(Compartment compartment)
        {
            return compartmentDAL.ModifyCompartment(compartment)> 0;
        }

        public List<Compartment> LogOnNoStateCompartments()
        {
            return compartmentDAL.LogOnNoStateCompartment();
        }
        public bool DeleteIdCompartment(int id)
        {
            return compartmentDAL.DeleteIdCompartment(id)>0;
        }
    }
}
