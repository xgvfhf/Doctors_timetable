﻿using System;
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
    public partial class ChooseDay : Form
    {
        public ChooseDay()
        {
            InitializeComponent();
        }

        private void ChooseDay_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            Form1 frm = new Form1() {WhatDay = btn.Text };
            frm.Show();
        }
    }
}