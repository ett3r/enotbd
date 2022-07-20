﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace enotBD
{

    public partial class MotherBoard : Form
    {
        SqlConnection sqlConnection;
        public MotherBoard()
        {
            InitializeComponent();
        }

        private async void Form3_Load(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Enot_base.mdf;Integrated Security=True;";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            var command = new SqlCommand("SELECT * FROM [MotherBoard]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["MBId"] ) + "      " + 
                        Convert.ToString(sqlReader["name"]) + "      " + Convert.ToString(sqlReader["FormFactor"]) + "     " + 
                        Convert.ToString(sqlReader["Chipset"]) + "       " + Convert.ToString(sqlReader["Socet"]));
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
            var fr2 = new ChooseMenu();
            fr2.Show();
            this.Hide();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed) sqlConnection.Close();
        }

        private async void  button3_Click(object sender, EventArgs e)
        {
            if (label7.Visible) label7.Visible = false;
            if (!string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text)
                && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
               && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
                && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                var command = new SqlCommand("INSERT INTO [MotherBoard] (name, FormFactor, Chipset, Socet) VALUES(@name, @FormFactor, @Chipset, @Socet)", sqlConnection);
                command.Parameters.AddWithValue("name", textBox9.Text);
                command.Parameters.AddWithValue("FormFactor", textBox1.Text);
                command.Parameters.AddWithValue("Chipset", textBox3.Text);
                command.Parameters.AddWithValue("Socet", textBox2.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label7.Visible = true;
                label7.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу.";
            }

            SqlDataReader sqlReader = null;
            var command2 = new SqlCommand("SELECT * FROM [MotherBoard]", sqlConnection);
            try
            {
                listBox1.Items.Clear();
                sqlReader = await command2.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["MBId"]) + "      " +
                        Convert.ToString(sqlReader["name"]) + "      " + Convert.ToString(sqlReader["FormFactor"]) + "     " +
                        Convert.ToString(sqlReader["Chipset"]) + "       " + Convert.ToString(sqlReader["Socet"]));
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

            textBox9.Clear(); textBox1.Clear(); textBox2.Clear(); textBox3.Clear();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label11.Visible) label11.Visible = false;
            if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text)
                && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text)
               && !string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text)
                && !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text)
                 && !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text))
            {
                var command = new SqlCommand("UPDATE [MotherBoard] SET [name] = @name, [FormFactor] = @FormFactor, " +
                    "[Chipset] = @Chipset, [Socet] = @Socet WHERE [MBId] = @MBId", sqlConnection);
                command.Parameters.AddWithValue("MBId", textBox7.Text);
                command.Parameters.AddWithValue("name", textBox4.Text);
                command.Parameters.AddWithValue("FormFactor", textBox10.Text);
                command.Parameters.AddWithValue("Chipset", textBox6.Text);
                command.Parameters.AddWithValue("Socet", textBox5.Text);
                await command.ExecuteNonQueryAsync();
            }
            else if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text))
            {
                label11.Visible = true;
                label11.Text = "Полe ID не должно быть пустым.";
            }
            else
            {
                label11.Visible = true;
                label11.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу.";
            }

            SqlDataReader sqlReader = null;
            var command2 = new SqlCommand("SELECT * FROM [MotherBoard]", sqlConnection);

            try
            {
                listBox1.Items.Clear();
                sqlReader = await command2.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["MBId"]) + "      " +
                        Convert.ToString(sqlReader["name"]) + "      " + Convert.ToString(sqlReader["FormFactor"]) + "     " +
                        Convert.ToString(sqlReader["Chipset"]) + "       " + Convert.ToString(sqlReader["Socet"]));
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

            textBox5.Clear(); textBox4.Clear(); textBox10.Clear(); textBox6.Clear(); textBox7.Clear();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (label13.Visible) label13.Visible = false;
            if (!string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text))
            {
                var command = new SqlCommand("DELETE FROM [MotherBoard] WHERE [MBId] = @MBId", sqlConnection);
                command.Parameters.AddWithValue("MBId", textBox8.Text);
                await command.ExecuteNonQueryAsync();
            }
            else 
            {
                label13.Visible = true;
                label13.Text = "Полe ID не должно быть пустым.";
            }


            SqlDataReader sqlReader = null;
            var command2 = new SqlCommand("SELECT * FROM [MotherBoard]", sqlConnection);

            try
            {
                listBox1.Items.Clear();
                sqlReader = await command2.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["MBId"]) + "      " +
                        Convert.ToString(sqlReader["name"]) + "      " + Convert.ToString(sqlReader["FormFactor"]) + "     " +
                        Convert.ToString(sqlReader["Chipset"]) + "       " + Convert.ToString(sqlReader["Socet"]));
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
    }
}
