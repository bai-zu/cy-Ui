using cy_Model;
using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cy_DLL
{
    public class DishDAL
    {
        public List<Dish> LogOnDish()
        {
            string sql = "SELECT * FROM dish WHERE is_deleted=0";
            List<Dish> dishs = new List<Dish>();
            MySqlDataReader mySqlDataReader = SqlHelper.Query(sql);
            while (mySqlDataReader.Read())
            {
                dishs.Add(
                    new Dish()
                    {
                        Id = mySqlDataReader.GetInt64(0),
                        Name = mySqlDataReader.GetString(1),
                        CategoryId = mySqlDataReader.GetInt64(2),
                        Price = mySqlDataReader.GetDouble(3),
                        Description = mySqlDataReader.GetString(4),
                        IsDescription = mySqlDataReader.GetInt32(5),
                    });
            }
            return dishs;
        }
        public Dish GetNameDish(string name)
        {
            string sql = "SELECT * FROM dish WHERE is_deleted=0 And name='" + name + "'";
            Dish dishs = new Dish();
            MySqlDataReader mySqlDataReader = SqlHelper.Query(sql);
            while (mySqlDataReader.Read())
            {
                dishs = new Dish()
                {
                    Id = mySqlDataReader.GetInt64(0),
                    Name = mySqlDataReader.GetString(1),
                    CategoryId = mySqlDataReader.GetInt64(2),
                    Price = mySqlDataReader.GetDouble(3),
                    
                    Description = mySqlDataReader.GetString(5),
                    IsDescription = mySqlDataReader.GetInt32(6),
                };
            }
            return dishs;
        }
        public int InsertDish(Dish dish)
        {
            int r = 0;
            Random rd = new Random();
            int id = rd.Next();
            string sql = "insert into dish(id,name,category_id,price,description,is_deleted) value(" + id + ",'" + dish.Name + "'," + dish.CategoryId + "," + dish.Price + ",'" + dish.Description + "',0)";
            r = SqlHelper.AddDeleteAndModify(sql);
            return r;
        }
        public int ModifyDish(Dish dish)
        {
            int r = 0;
            string sql = "UPDATE dish SET name='" + dish.Name + "',category_id=" + dish.CategoryId + ",price=" + dish.Price + ",description='" + dish.Description + "' WHERE id =" + dish.Id + ";";
            r = SqlHelper.AddDeleteAndModify(sql);
            return r;
        }
        public int DeleteDish(long id)
        {

            int r = 0;
            string sql = "UPDATE dish SET is_deleted=1 WHERE id ='" + id + "';";
            r = SqlHelper.AddDeleteAndModify(sql);
            return r;
        }
    }
}
