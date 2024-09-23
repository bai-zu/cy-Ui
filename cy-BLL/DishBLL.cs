using cy_DLL;
using cy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace cy_BLL
{
    public class DishBLL
    {
        DishDAL dishDAL = new DishDAL();
       /* public bool InsertCategorys(Category category)
        {
            return categoryDAL.InsertCategory(category) > 0;
        }*/

        public List<Dish> LogOnDishs()
        {

            return dishDAL.LogOnDish();
        }
        public Dish GetNameDishs(string name)
        {
            return dishDAL.GetNameDish(name);
        }
        public bool InsertDishs(Dish dish)
        {
            return dishDAL.InsertDish(dish)>0;
        }
        public bool ModifyDishs(Dish dish)
        {
            return dishDAL.ModifyDish(dish) > 0;
        }
        public bool DeleteDishs(long id)
        {
            return dishDAL.DeleteDish(id) > 0;
        }
    
    }
}
