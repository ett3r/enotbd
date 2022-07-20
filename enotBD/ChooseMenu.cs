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
    public partial class ChooseMenu : Form
    {


        public ChooseMenu()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fr3 = new MotherBoard();
            fr3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fr4 = new Processor();
            fr4.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var fr1 = new MainMenu();
            fr1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var fr5 = new RAM();
            fr5.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var fr6 = new PowerSupply();
            fr6.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var fr7 = new HardDrive();
            fr7.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var fr8 = new VideoCard();
            fr8.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr9 = new DBMenu();
            fr9.Show();
            this.Hide();
        }

        private  void ChooseMenu_Load(object sender, EventArgs e)
        {
        }

        private void ChooseMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
