using cy_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cy_DLL
{
    public class CategoryDAL
    {
        //查询全部（未被删除数据）
        public List<Category> LogOnCategory()
        {
            string sql = "SELECT * FROM category WHERE create_user=1";
            List<Category> categorys = new List<Category>();
            MySqlDataReader mySqlDataReader = SqlHelper.Query(sql);
            while (mySqlDataReader.Read())
            {
                categorys.Add(
                    new Category()
                    {
                        Id = mySqlDataReader.GetInt64(0),
                        Type = mySqlDataReader.GetInt32(1),
                        Name = mySqlDataReader.GetString(2),
                        Sort = mySqlDataReader.GetInt32(3),
                        CreateUser = mySqlDataReader.GetInt32(4),
                        Description = mySqlDataReader.GetString(5),
                    });
            }
            return categorys;
        }
        //根据sort查询
        public Category GetSortCategory(int sort)
        {
            string sql = "SELECT * FROM category WHERE create_user=1 And sort=" + sort ;
            Category category = new Category();
            MySqlDataReader mySqlDataReader = SqlHelper.Query(sql);
            while (mySqlDataReader.Read())
            {
                category = new Category()
                {
                    Id = mySqlDataReader.GetInt64(0),
                    Type = mySqlDataReader.GetInt32(1),
                    Name = mySqlDataReader.GetString(2),
                    Sort = mySqlDataReader.GetInt32(3),
                    CreateUser = mySqlDataReader.GetInt32(4),
                    Description = mySqlDataReader.GetString(5),
                };
            }
            return category;
        }
        //根据name查询
        public long GetNameCategory(string name)
        {
            string sql = "SELECT * FROM category WHERE  name='" + name+"'";
            long id = 0;
            MySqlDataReader mySqlDataReader = SqlHelper.Query(sql);
            while (mySqlDataReader.Read())
            {
               id= mySqlDataReader.GetInt64(0);
            }
            return id;
        }
        //添加一个类别
        public int InsertCategory(Category category)
        {
            int r = 0;
            Random rd = new Random();
            int id = rd.Next();
            string sql = "insert into category(id,type,name,sort,create_user,description) value("+ id + ","+ category.Type+ ",'"+ category.Name+ "',"+ category.Sort+ ",1,'"+ category.Description+ "')";
            r = SqlHelper.AddDeleteAndModify(sql);
            return r;
        }
        //修改
        public int ModifyCategory(Category category)
        {
            int r = 0;
            string sql = "UPDATE category SET name='" + category.Name + "',sort=" + category.Sort + ",description='" + category.Description + "',type='" + category.Type + "' WHERE id =" + category.Id + ";";
            r = SqlHelper.AddDeleteAndModify(sql);
            return r;
        }
        //删除
        public int DeleteSortCategory(int sort)
        {
            int r = 0;
            string sql = "DELETE FROM category WHERE sort=" + sort;
            r = SqlHelper.AddDeleteAndModify(sql);
            return r;
        }
    }
}
