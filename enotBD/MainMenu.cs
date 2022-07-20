using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace enotBD
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fr14 = new Rules();
            fr14.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr9 = new DBMenu();
            fr9.Show();
            this.Hide();
        }

        private  void MainMenu_Load(object sender, EventArgs e)
        {
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
