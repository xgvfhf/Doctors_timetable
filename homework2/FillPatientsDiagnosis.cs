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
    public partial class FillPatientsDiagnosis : Form
    {
        public string WhatDay { get; set; }
        public Interval CurrentDay { get; set; }

        public FillPatientsDiagnosis()
        {
            InitializeComponent();

        }

        private void FillPatientsDiagnosis_Load(object sender, EventArgs e)
        {
            Form1 f1 = (Form1)this.Owner;
            CurrentDay = f1.CurrentDay;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Enter symptoms and diagnosis!");
            }
            else
            {
                Form1 f1 = (Form1)this.Owner;
                int RowNumber = f1.dataGridView1.CurrentRow.Index;
                var temp = CurrentDay;
                var con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Проекти VS\homework2\homework2\Monday.accdb");
                con.Open();
                if (RowNumber == 0)
                {
                    foreach (var ptnt in temp.pt)
                    {
                        if (ptnt != null)
                        {
                            string query1 = $"INSERT INTO {WhatDay}(Date_Of_Visit,PatientName,PatientSurname,Type,PersonalNumber,Symptoms,Diagnosis)VALUES('{ptnt.Date}','{ptnt.FirstName}','{ptnt.LastName}','{ptnt.TypeOfPatient}','{ptnt.Id}','{textBox1.Text}','{textBox2.Text}')";
                            OleDbCommand command = new OleDbCommand(query1, con);
                            command.ExecuteNonQuery();
                            temp.pt.Dequeue();
                            MessageBox.Show("Visit is ended");
                            break;
                        }
                        else
                            temp = temp.Next;
                    }
                    
                }
                else
                    MessageBox.Show("Doctor must take first patient!");

                f1.CurrentDay = CurrentDay;

            }
            
            }
               
        }
    
}
