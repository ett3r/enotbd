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
    public partial class Rules : Form
    {

        SqlConnection sqlConnection;

        public Rules()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var fr1 = new MainMenu();
            fr1.Show();
            this.Hide();
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            var fr2 = new ChooseMenu();
            fr2.Show();
            this.Hide();
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Enot_base.mdf;Integrated Security=True; MultipleActiveResultSets=true";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            var command = new SqlCommand("DELETE FROM [MotherBoard]", sqlConnection);
            sqlReader = await command.ExecuteReaderAsync();
            await sqlReader.ReadAsync();

            var command2 = new SqlCommand("DELETE FROM [HardDrive]", sqlConnection);
            sqlReader = await command2.ExecuteReaderAsync();
            await sqlReader.ReadAsync();

            var command3 = new SqlCommand("DELETE FROM [Memory]", sqlConnection);
            sqlReader = await command3.ExecuteReaderAsync();
            await sqlReader.ReadAsync();

            var command4 = new SqlCommand("DELETE FROM [Office]", sqlConnection);
            sqlReader = await command4.ExecuteReaderAsync();
            await sqlReader.ReadAsync();

            var command5 = new SqlCommand("DELETE FROM [PowerSupply]", sqlConnection);
            sqlReader = await command5.ExecuteReaderAsync();
            await sqlReader.ReadAsync();

            var command6 = new SqlCommand("DELETE FROM [Processor]", sqlConnection);
            sqlReader = await command6.ExecuteReaderAsync();
            await sqlReader.ReadAsync();

            var command7 = new SqlCommand("DELETE FROM [VideoCard]", sqlConnection);
            sqlReader = await command7.ExecuteReaderAsync();
            await sqlReader.ReadAsync();

            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed) sqlConnection.Close();

        }

        private void Rules_Load(object sender, EventArgs e)
        {

        }

        private void Rules_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed) sqlConnection.Close();
        }
    }
}
