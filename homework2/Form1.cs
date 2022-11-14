using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace homework2
{
    public partial class Form1 : Form
    {
        public string WhatDay { get; set; }
        public Interval CurrentDay { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = WhatDay;
            var day = new Day();
            CurrentDay = day.FillTheQueue();//если че удалим

        }




        private void button1_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            string choice = btn.Text;
            
            switch (choice)
            {
                case "Fill diagnosis":
                    new FillPatientsDiagnosis().Show();
                    break;
                case "Add additional":
                    new AddAdditionalPatient().Show();
                    break;
                case "Show results":
                    new Results().Show();
                    break;
            }

        }

    }
}
