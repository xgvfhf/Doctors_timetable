using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace homework2
{
    public partial class AddAdditionalPatient : Form
    {
        public Interval CurrentDay { get; set; }
        
        public AddAdditionalPatient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            Form1 f1 = (Form1)this.Owner;
            CurrentDay = f1.CurrentDay;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Enter all values!");
            }
            else if (!textBox3.Text.StartsWith("P") || textBox3.Text.Length != 6)//checking first letter and length
            {
                MessageBox.Show("Id must start with P and have length whuch equal 6!");
            }
            else
            {
                var temp = CurrentDay;
                bool IsAdded = false;

                for (int i = 0; i < 3; i++)
                {
                    foreach (var item in temp.pt)
                    {
                        if (item.TypeOfPatient.Equals("Unplanned") && item.FirstName.Equals("-") )
                        {
                            item.FirstName = textBox1.Text;
                            item.LastName = textBox2.Text;
                            item.Id = textBox3.Text;
                            IsAdded = true;
                            break;
                        }                        
                    }
                    if (IsAdded)
                    {
                        break;
                    }
                }
                MessageBox.Show("Additional patient added!");               
                f1.CurrentDay = CurrentDay;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'A' || l > 'z') && l != '\b' )// only latin letters
            {
                e.Handled = true;
            }
        }

        private void AddAdditionalPatient_Load(object sender, EventArgs e)
        {
            
        }
    }
}
