using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data;
using Study.database.table;

namespace Study.database
{
    class DBaccess
    {
        public string ReturnPassword(string username)
        {
            DatabaseDataContext db = new DatabaseDataContext();
            var SqlQuery = from user in db.Logins
                           where user.username == username
                           select new
                           {
                               pass = user.password
                           };
            string temp = "";
            foreach(var item in SqlQuery)
            {
                temp += item.pass;
            }
            return temp;
        }

        public bool CorectUser(string username, string password)
        {
            DatabaseDataContext db = new DatabaseDataContext();
            var SqlQuery = from user in db.Logins
                           where user.username == username && user.password == password
                           select user;

            string temp = "";
            foreach (var item in SqlQuery)
            {
                temp += item.username;
            }
            if(temp == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
