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
    public partial class Processor : Form
    {
        SqlConnection sqlConnection;
        public Processor()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed) sqlConnection.Close();
            this.Hide();
            var fr2 = new ChooseMenu();
            fr2.Show();
            this.Hide();
        }


        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button3_Click_1(object sender, EventArgs e)
        {
            if (label7.Visible) label7.Visible = false;
            if (!string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text)
                && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
               && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
                && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text)
                 && !string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text))
            {
                var command = new SqlCommand("INSERT INTO [Processor] (Procname, Core, Core_Count, Frequency, Socet) VALUES(@Procname, @Core, @Core_Count, @Frequency, @Socet)", sqlConnection);
                command.Parameters.AddWithValue("Procname", textBox9.Text);
                command.Parameters.AddWithValue("Core", textBox1.Text);
                command.Parameters.AddWithValue("Core_Count", textBox3.Text);
                command.Parameters.AddWithValue("Frequency", textBox2.Text);
                command.Parameters.AddWithValue("Socet", textBox11.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label7.Visible = true;
                label7.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу.";
            }

            SqlDataReader sqlReader = null;
            var command2 = new SqlCommand("SELECT * FROM [Processor]", sqlConnection);
            try
            {
                listBox1.Items.Clear();
                sqlReader = await command2.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["ProcId"]) + "      " +
                        Convert.ToString(sqlReader["Procname"]) + "      " + Convert.ToString(sqlReader["Core"]) + "     " +
                        Convert.ToString(sqlReader["Core_Count"]) + "       " + Convert.ToString(sqlReader["Frequency"]) 
                        + "       " + Convert.ToString(sqlReader["Socet"]));
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

            textBox9.Clear(); textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox11.Clear();
        }

        private async void Form4_Load_1(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Enot_base.mdf;Integrated Security=True;";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            var command = new SqlCommand("SELECT * FROM [Processor]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["ProcId"]) + "      " +
                        Convert.ToString(sqlReader["Procname"]) + "      " + Convert.ToString(sqlReader["Core"]) + "     " +
                        Convert.ToString(sqlReader["Core_Count"]) + "       " + Convert.ToString(sqlReader["Frequency"]) + "       " + Convert.ToString(sqlReader["Socet"]));
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

        private async void button1_Click_1(object sender, EventArgs e)
        {
            if (label17.Visible) label17.Visible = false;
            if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text)
                && !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text)
               && !string.IsNullOrEmpty(textBox14.Text) && !string.IsNullOrWhiteSpace(textBox14.Text)
                && !string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text)
                 && !string.IsNullOrEmpty(textBox13.Text) && !string.IsNullOrWhiteSpace(textBox13.Text)
                 && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                var command = new SqlCommand("UPDATE [Processor] SET [Procname] = @Procname, [Core] = @Core, " +
                    "[Core_Count] = @Core_Count, [Frequency] = @Frequency, [Socet] = @Socet  WHERE [ProcId] = @ProcId", sqlConnection);
                command.Parameters.AddWithValue("ProcId", textBox7.Text);
                command.Parameters.AddWithValue("Procname", textBox6.Text);
                command.Parameters.AddWithValue("Core", textBox14.Text);
                command.Parameters.AddWithValue("Core_Count", textBox10.Text);
                command.Parameters.AddWithValue("Frequency", textBox13.Text);
                command.Parameters.AddWithValue("Socet", textBox5.Text);
                await command.ExecuteNonQueryAsync();
            }
            else if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text))
            {
                label17.Visible = true;
                label17.Text = "Полe ID не должно быть пустым.";
            }
            else
            {
                label17.Visible = true;
                label17.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу.";
            }
            SqlDataReader sqlReader = null;
            var command2 = new SqlCommand("SELECT * FROM [Processor]", sqlConnection);
            try
            {
                listBox1.Items.Clear();
                sqlReader = await command2.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["ProcId"]) + "      " +
                        Convert.ToString(sqlReader["Procname"]) + "      " + Convert.ToString(sqlReader["Core"]) + "     " +
                        Convert.ToString(sqlReader["Core_Count"]) + "       " + Convert.ToString(sqlReader["Frequency"])
                        + "       " + Convert.ToString(sqlReader["Socet"]));
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

            textBox7.Clear(); textBox6.Clear(); textBox14.Clear(); textBox10.Clear(); textBox13.Clear(); textBox5.Clear();

        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            if (label13.Visible) label13.Visible = false;
            if (!string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text))
            {
                var command = new SqlCommand("DELETE FROM [Processor] WHERE [ProcId] = @ProcId", sqlConnection);
                command.Parameters.AddWithValue("ProcId", textBox8.Text);
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label13.Visible = true;
                label13.Text = "Полe ID не должно быть пустым.";
            }


            SqlDataReader sqlReader = null;
            var command2 = new SqlCommand("SELECT * FROM [Processor]", sqlConnection);
            try
            {
                listBox1.Items.Clear();
                sqlReader = await command2.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["ProcId"]) + "      " +
                        Convert.ToString(sqlReader["Procname"]) + "      " + Convert.ToString(sqlReader["Core"]) + "     " +
                        Convert.ToString(sqlReader["Core_Count"]) + "       " + Convert.ToString(sqlReader["Frequency"])
                        + "       " + Convert.ToString(sqlReader["Socet"]));
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
            textBox8.Clear();
        }

        private void Processor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed) sqlConnection.Close();
        }
    }
}
