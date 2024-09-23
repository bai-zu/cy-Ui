using cy_DLL;
using cy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cy_BLL
{
    public class CategoryBLL
    {
        CategoryDAL categoryDAL = new CategoryDAL();
        public bool InsertCategorys(Category category)
        {
            return categoryDAL.InsertCategory(category)>0;
        }


        public List<Category> LogOnCategorys()
        {
            
            return categoryDAL.LogOnCategory();
        }
        public Category GetNameCategorys(int sort) 
        {
            return categoryDAL.GetSortCategory(sort);
        }
        public bool ModifyCategorys(Category category)
        {
            return categoryDAL.ModifyCategory(category)>0;
        }
        public bool DeleteSortCategorys(int sort)
        {
            return categoryDAL.DeleteSortCategory(sort) > 0;
        }
        public long GetNameCategorys(string name)
        {
            return categoryDAL.GetNameCategory(name);
        }
    }
}
