using cy_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cy_DLL
{
    public class UserDAL
    {
        //
        public List<User> LogOnUser(User user)
        {
            string sql = "SELECT * FROM user WHERE user_name= '"+user.userName+"' AND password = '"+user.passWord+"'";
            List<User> users = new List<User>();
            MySqlDataReader mySqlDataReader = SqlHelper.Query(sql);
            while (mySqlDataReader.Read())
            {
                users.Add(
                    new User()
                    {
                        userId=mySqlDataReader.GetInt32(0),
                        userGroup=mySqlDataReader.GetString(1),
                        userName=mySqlDataReader.GetString(2),
                        passWord=mySqlDataReader.GetString(3),
                    });
            }
            
            return users;
        }
        public List<User> GetUser(string userName)
        {
            string sql = "SELECT * FROM user WHERE user_name= '"+ userName + "'";
            List<User> users = new List<User>();
            MySqlDataReader mySqlDataReader = SqlHelper.Query(sql);
            while (mySqlDataReader.Read())
            {
                users.Add(
                    new User()
                    {
                        userId = mySqlDataReader.GetInt32(0),
                        userGroup = mySqlDataReader.GetString(1),
                        userName = mySqlDataReader.GetString(2),
                        passWord = mySqlDataReader.GetString(3),
                    });
            }
            return users;
        }
        public int InsertUser(User user)
        {
            int r = 0;
            string group = user.userGroup;
            string name = user.userName;
            string password = user.passWord;
            string sql = "insert into user(user_group,user_name,password) value('"+group+"', '"+name +"','"+password+"');";
            r = SqlHelper.AddDeleteAndModify(sql);
            return r;
        }
        public int UpdateUser(User user)
        {

            int r = 0;
            int id = user.userId;
            string group = user.userGroup;
            string name = user.userName;
            string password = user.passWord;
            string sql = "UPDATE user SET user_group = '"+group+"', user_name = "+name+",password='"+password+"' WHERE user_id = "+id+";";
            r = SqlHelper.AddDeleteAndModify(sql);
            return r;
        }
        public int DeleteUser(User user)
        {

            int r = 0;
            int id = user.userId;
            string sql = "DELETE FROM user WHERE user_id ="+id ;
            r = SqlHelper.AddDeleteAndModify(sql);
            return r;
        }
    }
}
