using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace homework2
{
    public partial class Results : Form
    {
        public string WhatDay { get; set; }
        public Results()
        {
            InitializeComponent();
        }

        private void Results_Load(object sender, EventArgs e)
        {
            
                var con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Проекти VS\homework2\homework2\Monday.accdb");
                con.Open();
                string query2 = $"SELECT Date_Of_Visit,PatientName,PatientSurname,Type,Symptoms,Diagnosis FROM {WhatDay} ";
                OleDbCommand command1 = new OleDbCommand(query2, con);
                OleDbDataAdapter ol = new OleDbDataAdapter(command1);
                DataTable dataTable = new DataTable();
                ol.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
           
        }
    }
}
