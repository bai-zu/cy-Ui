using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cy_Model
{
    public class Order
    {
        public double Id { get; set; }
        public string Name{ get; set; }
        public double Monovalent { get; set; }
        public int Number { get; set; }
        public double Total { get; set; }
        public long BillId { get; set; }
    }
}
