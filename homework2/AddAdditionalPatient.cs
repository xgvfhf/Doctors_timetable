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
        public AddAdditionalPatient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Enter all values!");
            }
            else if (!textBox3.Text.StartsWith("P")|| textBox3.Text.Length != 6)//checking first letter and length
            {
                MessageBox.Show("Id must start with P and have length whuch equal 6!");
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
    }
}
