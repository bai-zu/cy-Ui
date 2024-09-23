using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cy_Model
{
    public class Bill
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public string Notes { get; set; }
        public double Total { get; set; }
        public int State { get; set; }
        public int TabId { get; set; }
    }
}
