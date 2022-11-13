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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = WhatDay;
            //var con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Проекти VS\homework2\homework2\PatientList.accdb");
            
            
            //string query = "SELECT * FROM PatientList";
            //con.Open();
            
            //OleDbCommand command = new OleDbCommand(query,con);
            //var reader = command.ExecuteReader();
            //var intr = new Interval();
            //var cur = intr;
            //int Counter = 0;
            //int p = 0;
            //while (reader.Read())
            //{
            //    if (p>=0 && p<4)
            //    {
            //        intr.pt.Enqueue(new Patient { FirstName = reader[1].ToString(), LastName = reader[2].ToString(), TypeOfPatient = "Planned" });
            //        p++;
            //    }
            //    // скорее всего нужно реализовать класс типо линкт лист
            //    else
            //    {
                  
            //        if (Counter==4)
            //        {
            //            cur.Next = new Interval();
            //            cur = cur.Next;
            //        }
            //        cur.pt.Enqueue(new Patient { FirstName = reader[1].ToString(), LastName = reader[2].ToString(), TypeOfPatient = "Planned" });
                    
            //    }

            //    Counter++;

            //} 
        
            

            
           
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
