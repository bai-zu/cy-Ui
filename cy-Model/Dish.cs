using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cy_Model
{
    public class Dish
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CategoryId { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int IsDescription { get; set; }
    }
}
