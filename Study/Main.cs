﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Study
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Menu_new_student_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
