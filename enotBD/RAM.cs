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
    public partial class RAM : Form
    {
        SqlConnection sqlConnection;
        public RAM()
        {
            InitializeComponent();
        }

        private async void Form5_Load(object sender, EventArgs e)
        {

            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Enot_base.mdf;Integrated Security=True;";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;
            var command = new SqlCommand("SELECT * FROM [Memory]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["MemoryId"]) + "      " +
                        Convert.ToString(sqlReader["Memoryname"]) + "      " + Convert.ToString(sqlReader["memory_type"]) + "     " +
                        Convert.ToString(sqlReader["memory_size"]) + "       " + Convert.ToString(sqlReader["Frequency"]) + "       " + Convert.ToString(sqlReader["Timing"]));
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
            if(sqlConnection != null && sqlConnection.State != ConnectionState.Closed) sqlConnection.Close();
            this.Hide();
            var fr2 = new ChooseMenu();
            fr2.Show();
            this.Hide();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (label7.Visible) label7.Visible = false;
            if (!string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text)
                && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
               && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
                && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text)
                 && !string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text))
            {
                var command = new SqlCommand("INSERT INTO [Memory] (Memoryname, memory_type, memory_size, Frequency, Timing) VALUES(@Memoryname, @memory_type, @memory_size, @Frequency, @Timing)", sqlConnection);
                command.Parameters.AddWithValue("Memoryname", textBox9.Text);
                command.Parameters.AddWithValue("memory_type", textBox1.Text);
                command.Parameters.AddWithValue("memory_size", textBox3.Text);
                command.Parameters.AddWithValue("Frequency", textBox2.Text);
                command.Parameters.AddWithValue("Timing", textBox11.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label7.Visible = true;
                label7.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу.";
            }

            SqlDataReader sqlReader = null;
            var command2 = new SqlCommand("SELECT * FROM [Memory]", sqlConnection);
            try
            {
                listBox1.Items.Clear();
                sqlReader = await command2.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["MemoryId"]) + "      " +
                        Convert.ToString(sqlReader["Memoryname"]) + "      " + Convert.ToString(sqlReader["memory_type"]) + "     " +
                        Convert.ToString(sqlReader["memory_size"]) + "       " + Convert.ToString(sqlReader["Frequency"]) + "       " +  Convert.ToString(sqlReader["Timing"]));
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

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label17.Visible) label17.Visible = false;
            if (!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text)
                && !string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text)
               && !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text)
                && !string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text)
                 && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text)
                 && !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text))
            {
                var command = new SqlCommand("UPDATE [Memory] SET [Memoryname] = @Memoryname, [memory_type] = @memory_type, " +
                    "[memory_size] = @memory_size, [Frequency] = @Frequency, [Timing] = @Timing  WHERE [MemoryId] = @MemoryId", sqlConnection);
                command.Parameters.AddWithValue("MemoryId", textBox7.Text);
                command.Parameters.AddWithValue("Memoryname", textBox5.Text);
                command.Parameters.AddWithValue("memory_type", textBox12.Text);
                command.Parameters.AddWithValue("memory_size", textBox6.Text);
                command.Parameters.AddWithValue("Frequency", textBox10.Text);
                command.Parameters.AddWithValue("Timing", textBox4.Text);
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
            var command2 = new SqlCommand("SELECT * FROM [Memory]", sqlConnection);
            try
            {
                listBox1.Items.Clear();
                sqlReader = await command2.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["MemoryId"]) + "      " +
                        Convert.ToString(sqlReader["Memoryname"]) + "      " + Convert.ToString(sqlReader["memory_type"]) + "     " +
                        Convert.ToString(sqlReader["memory_size"]) + "       " + Convert.ToString(sqlReader["Frequency"])
                        + "       " + Convert.ToString(sqlReader["Timing"]));
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

            textBox7.Clear(); textBox5.Clear(); textBox12.Clear(); textBox6.Clear(); textBox10.Clear(); textBox4.Clear();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (label13.Visible) label13.Visible = false;
            if (!string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text))
            {
                var command = new SqlCommand("DELETE FROM [Memory] WHERE [MemoryId] = @MemoryId", sqlConnection);
                command.Parameters.AddWithValue("MemoryId", textBox8.Text);
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label13.Visible = true;
                label13.Text = "Полe ID не должно быть пустым.";
            }


            SqlDataReader sqlReader = null;
           var command2 = new SqlCommand("SELECT * FROM [Memory]", sqlConnection);
            try
            {
                listBox1.Items.Clear();
                sqlReader = await command2.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["MemoryId"]) + "      " +
                        Convert.ToString(sqlReader["Memoryname"]) + "      " + Convert.ToString(sqlReader["memory_type"]) + "     " +
                        Convert.ToString(sqlReader["memory_size"]) + "       " + Convert.ToString(sqlReader["Frequency"]) + "       " +  Convert.ToString(sqlReader["Timing"]));
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void RAM_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed) sqlConnection.Close();
        }
    }
}
