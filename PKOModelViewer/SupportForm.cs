﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PKOModelViewer
{
    public partial class SupportForm : Form
    {
        public SupportForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://war.ukraine.ua/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
