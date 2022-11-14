using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework2
{
    public partial class FillPatientsDiagnosis : Form
    {
        public FillPatientsDiagnosis()
        {
            InitializeComponent();
        }

        private void FillPatientsDiagnosis_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" )
            {
                MessageBox.Show("Enter symptoms and diagnosis!");
            }
        }
    }
}
