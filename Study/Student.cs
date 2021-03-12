using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Study
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                database.Student std = new database.Student();
                int _01id = int.Parse(txtID.Text);
                string _02fname = txtFirstName.Text;
                string _03lname = txtLastName.Text;
                DateTime _04bday = timeBirthday.Value;
                bool _05gender = radMale.Checked;
                string _06phone = txtPhone.Text;
                string _07address = txtAddress.Text;
                Binary _08image = null;

                if(std.NewStudent(_01id, _02fname, _03lname, _04bday, _05gender, _06phone, _07address, _08image))
                {
                    MessageBox.Show("Added", "Add student", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Added fails", "Add student", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("Added fails", "Add student", MessageBoxButtons.OK);
            }
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdAvatar.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Gán ....
                Image image = Image.FromFile(ofdAvatar.FileName);

                // Xử lý... 
                picAvatar.Image = image;
            }
        }
    }
}
