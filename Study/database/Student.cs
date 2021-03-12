using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data;
using Study.database.table;
using System.Drawing;

namespace Study.database
{
    class Student
    {
        DatabaseDataContext db = new DatabaseDataContext();

        public bool NewStudent(int _01id, string _02fname, string _03lname, DateTime _04bday, bool _05gender, string _06phone, string _07address, Binary _08image)
        {
            bool rt = true;
            student st = new student
            {
                C01_id = _01id,
                C02_firtsname = _02fname,
                C03_lastname = _03lname,
                C04_birthday = _04bday,
                C05_gender = _05gender,
                C06_phonenumber = _06phone,
                C07_address = _07address,
                C08_avatar = _08image
            };

            try
            {
                db.students.InsertOnSubmit(st);
                db.SubmitChanges();
                rt = true;
            }
            catch
            {
                rt = false;
            }
            return rt;
        }
    }
}
