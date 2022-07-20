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
    public partial class DBMenu : Form
    {


        public DBMenu()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var fr2 = new ChooseMenu();
            fr2.Show();
            this.Hide();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            var fr1 = new MainMenu();
            fr1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr10 = new ComputerList();
            fr10.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr11 = new InsertDB();
            fr11.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr12 = new UpdateDB();
            fr12.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr13 = new DeleteDB();
            fr13.Show();
            this.Hide();
        }

        private void DBMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void DBMenu_Load(object sender, EventArgs e)
        {
        }
    }
}
