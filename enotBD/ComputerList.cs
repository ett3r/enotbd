using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace enotBD
{
    public partial class ComputerList : Form
    {
        SqlConnection sqlConnection;
        public ComputerList()
        {
            InitializeComponent();
        }



        private async void Form10_Load(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Enot_base.mdf;Integrated Security=True; MultipleActiveResultSets=true";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            var command = new SqlCommand("SELECT [Office].Id, [Office].Employee, [MotherBoard].name, " +
                "[Processor].Procname, [Memory].Memoryname, [PowerSupply].PSname, [HardDrive].HDname, [VideoCard ].VCname " +
                "FROM [Office], [MotherBoard], [Processor], [Memory], [PowerSupply], [HardDrive], [VideoCard] " +
                "WHERE [Office].MBId = [MotherBoard].MBId AND [Office].ProcId = [Processor].ProcId AND [Office].MemoryId = [Memory].MemoryId AND [Office].PSId = [PowerSupply].PSId AND [Office].HDId = [HardDrive].HDId AND [Office].VCId = [VideoCard ].VCId", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "      " +
                    Convert.ToString(sqlReader["Employee"]) + "      " + Convert.ToString(sqlReader["name"]) + "      "
                    +  Convert.ToString(sqlReader["Procname"]) + "      " + Convert.ToString(sqlReader["VCname"])
                     + "      " + Convert.ToString(sqlReader["Memoryname"]) + "      " + Convert.ToString(sqlReader["PSname"])
                     + "      " + Convert.ToString(sqlReader["HDname"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null) sqlReader.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed) sqlConnection.Close();
            this.Hide();
            var fr9 = new DBMenu();
            fr9.Show();
            this.Hide();
        }

        private void ComputerList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed) sqlConnection.Close();
        }
    }
}
