using cy_DLL;
using cy_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cy_BLL
{
    public class UserBLL
    {
        public List<User> LogOnUsers(User user)
        {
            UserDAL userDAL = new UserDAL();
            return userDAL.LogOnUser(user);
        }
        public bool GetUsers(string userName)
        {
            bool a = false;
            UserDAL userDAL = new UserDAL();
            if (userDAL.GetUser(userName).Count>0)
            {
                a = true;
            }
            return a;
        }
        public bool InsertUsers(User user)
        {
            UserDAL userDAL = new UserDAL();
            return userDAL.InsertUser(user)>0;
        }
        public bool UpdateUsers(User user)
        {
            UserDAL userDAL = new UserDAL();
            return userDAL.UpdateUser(user) > 0;
        }
        public bool DeleteUsers(User user)
        {
            UserDAL userDAL = new UserDAL();
            return userDAL.DeleteUser(user) > 0;
        }
    }
}
