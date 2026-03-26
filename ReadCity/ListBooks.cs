using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ReadCity
{
    public partial class ListBooks : Form
    {
        public ListBooks(string fullName)
        {
            InitializeComponent();
            labelFullName.Text = fullName;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Authorization authForm = new Authorization();

            authForm.Show();

            this.Close();
        }
    }
}
