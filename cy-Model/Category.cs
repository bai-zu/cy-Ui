using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cy_Model
{
    public class Category
    {
        public long Id { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public int CreateUser { get; set; }
        public string Description { get; set; }
    }
}
