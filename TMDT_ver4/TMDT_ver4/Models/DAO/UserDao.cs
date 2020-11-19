using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.DAO
{
    public class UserDao
    {
        Model1 db = null;
        public UserDao()
        {
            db = new Model1();
        }

        public int Insert(User enity)
        {
            db.Users.Add(enity);
            db.SaveChanges();
            return enity.IDuser;
        }
        public User GetByid(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public int Login(string userName, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);           
            if (result == null)
            {
                return 0;
            }
            else
            {
                var result1 = db.Users.SingleOrDefault(x => x.Password == passWord);
                if (result1 == null)
                {
                    return -1;
                }
                else
                    return 1;
            }
        }
    }
}
