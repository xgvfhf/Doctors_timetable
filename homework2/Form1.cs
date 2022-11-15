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
            CurrentDay = day.FillTheQueue();
            
            var con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Проекти VS\homework2\homework2\PatientList.accdb");
            con.Open();
            Clear(con);
            QueueIntoTable(CurrentDay,con);
            Reload(con);                     
        }
        void Clear( OleDbConnection con)
        {
            string query = "DELETE FROM OrderedList";
            OleDbCommand command2 = new OleDbCommand(query, con);
            command2.ExecuteNonQuery();
        }
        void QueueIntoTable(Interval i,OleDbConnection con)
        {
            var temp = i;
            while (temp.Next != null)
            {
                foreach (var patient in temp.pt)
                {
                    string query1 = $"INSERT INTO OrderedList(DateOfVisit,PatientName,PatientSurname,Type,PersonalNumber,Symptoms,Diagnosis)VALUES('{patient.Date}','{patient.FirstName}','{patient.LastName}','{patient.TypeOfPatient}','{patient.Id}','{patient.Symptom}','{patient.Diagnosises}')";
                    OleDbCommand command = new OleDbCommand(query1, con);
                    command.ExecuteNonQuery();
                }
                temp = temp.Next;

            }
        }
        void Reload(OleDbConnection con)
        {
            string query2 = "SELECT DateOfVisit,PatientName,PatientSurname,Type,Symptoms,Diagnosis FROM OrderedList ";
            OleDbCommand command1 = new OleDbCommand(query2, con);
            OleDbDataAdapter ol = new OleDbDataAdapter(command1);
            DataTable dataTable = new DataTable();
            ol.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            string choice = btn.Text;
            
            switch (choice)
            {
                case "Fill diagnosis":
                    var fill = new FillPatientsDiagnosis();
                    fill.Owner = this;
                    fill.Show();                    
                    break;
                case "Add additional":
                    var add = new AddAdditionalPatient();
                    add.Owner = this;
                    add.Show();                  
                    break;
                case "Show results":
                    var result = new Results();
                    result.Owner = this;
                    result.Show();                    
                    break;
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            var con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Проекти VS\homework2\homework2\PatientList.accdb");
            con.Open();
            Clear(con);
            QueueIntoTable(CurrentDay, con);
            Reload(con);
        }
    }
}
