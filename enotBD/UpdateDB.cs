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
    public partial class UpdateDB : Form
    {
        SqlConnection sqlConnection;
        public UpdateDB()
        {
            InitializeComponent();
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private async void Form12_Load(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Enot_base.mdf;Integrated Security=True;";
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
                    listBox8.Items.Add(Convert.ToString(sqlReader["Id"]) + "      " +
                    Convert.ToString(sqlReader["Employee"]) + "      " + Convert.ToString(sqlReader["name"]) + "      "
                    + Convert.ToString(sqlReader["Procname"]) + "      " + Convert.ToString(sqlReader["VCname"])
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

            var command2 = new SqlCommand("SELECT * FROM [MotherBoard]", sqlConnection);
            try
            {
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

            var command3 = new SqlCommand("SELECT * FROM [Processor]", sqlConnection);
            try
            {
                sqlReader = await command3.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox2.Items.Add(Convert.ToString(sqlReader["ProcId"]) + "      " +
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

            var command4 = new SqlCommand("SELECT * FROM [Memory]", sqlConnection);
            try
            {
                sqlReader = await command4.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox4.Items.Add(Convert.ToString(sqlReader["MemoryId"]) + "      " +
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

            var command5 = new SqlCommand("SELECT * FROM [PowerSupply]", sqlConnection);
            try
            {
                sqlReader = await command5.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox6.Items.Add(Convert.ToString(sqlReader["PSId"]) + "      " +
                        Convert.ToString(sqlReader["PSname"]) + "      " + Convert.ToString(sqlReader["Form_factor"]) + "     " +
                        Convert.ToString(sqlReader["capacity"]) + "       " + Convert.ToString(sqlReader["main_connector"]));
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

            var command6 = new SqlCommand("SELECT * FROM [HardDrive]", sqlConnection);
            try
            {
                sqlReader = await command6.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox5.Items.Add(Convert.ToString(sqlReader["HDId"]) + "      " +
                        Convert.ToString(sqlReader["HDname"]) + "      " + Convert.ToString(sqlReader["Form_factor"]) + "     " +
                        Convert.ToString(sqlReader["Type"]) + "       " + Convert.ToString(sqlReader["amount"]));
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

            var command7 = new SqlCommand("SELECT * FROM [VideoCard]", sqlConnection);
            try
            {
                sqlReader = await command7.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox3.Items.Add(Convert.ToString(sqlReader["VCId"]) + "      " +
                        Convert.ToString(sqlReader["VCname"]) + "      " + Convert.ToString(sqlReader["amount_video"]) + "      " + Convert.ToString(sqlReader["Type"]) + "     " +
                        Convert.ToString(sqlReader["Bus_bit_depth"]));
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
        private void button16_Click(object sender, EventArgs e)
            {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed) sqlConnection.Close();
            this.Hide();
                var fr9 = new DBMenu();
                fr9.Show();
                this.Hide();
             }

        private async void button5_Click(object sender, EventArgs e)
        {
            if (label4.Visible || label2.Visible || label7.Visible || label14.Visible || label6.Visible || label10.Visible || label19.Visible)
            {
                label4.Visible = false;
                label2.Visible = false;
                label7.Visible = false;
                label14.Visible = false;
                label6.Visible = false;
                label10.Visible = false;
                label19.Visible = false;
            }

            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text)
                && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
               && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
                && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text)
                 && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text)
                 && !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text)
                 && !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
            {
                var command = new SqlCommand("UPDATE [Office] SET [Employee] = @Employee, [MBId] = @MBId, " +
                "[ProcId] = @ProcId, [MemoryId] = @MemoryId, [PSId] = @PSId, [HDId] = @HDId, [VCId] = @VCId WHERE [Id] = @Id", sqlConnection);
                command.Parameters.AddWithValue("Employee", textBox7.Text);
                command.Parameters.AddWithValue("MBId", textBox9.Text);
                command.Parameters.AddWithValue("ProcId", textBox1.Text);
                command.Parameters.AddWithValue("MemoryId", textBox3.Text);
                command.Parameters.AddWithValue("PSId", textBox6.Text);
                command.Parameters.AddWithValue("HDId", textBox5.Text);
                command.Parameters.AddWithValue("VCId", textBox2.Text);
                command.Parameters.AddWithValue("Id", textBox4.Text);

                listBox1.Items.Clear();

                textBox4.Clear(); textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear(); textBox9.Clear();

                label4.Visible = false;
                label2.Visible = false;
                label7.Visible = false;
                label14.Visible = false;
                label6.Visible = false;
                label10.Visible = false;
                label19.Visible = false;

                await command.ExecuteNonQueryAsync();

                SqlDataReader sqlReader = null;
                var command2 = new SqlCommand("SELECT [Office].Id, [Office].Employee, [MotherBoard].name, " +
                    "[Processor].Procname, [Memory].Memoryname, [PowerSupply].PSname, [HardDrive].HDname, [VideoCard ].VCname " +
                    "FROM [Office], [MotherBoard], [Processor], [Memory], [PowerSupply], [HardDrive], [VideoCard] " +
                    "WHERE [Office].MBId = [MotherBoard].MBId AND [Office].ProcId = [Processor].ProcId AND [Office].MemoryId = [Memory].MemoryId AND [Office].PSId = [PowerSupply].PSId AND [Office].HDId = [HardDrive].HDId AND [Office].VCId = [VideoCard ].VCId", sqlConnection);
                try
                {
                    sqlReader = await command2.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        listBox8.Items.Add(Convert.ToString(sqlReader["Id"]) + "      " +
                        Convert.ToString(sqlReader["Employee"]) + "      " + Convert.ToString(sqlReader["name"]) + "      "
                        + Convert.ToString(sqlReader["Procname"]) + "      " + Convert.ToString(sqlReader["VCname"])
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
            else
            {
                label4.Visible = true; label2.Visible = true; label7.Visible = true; label14.Visible = true; label6.Visible = true; label10.Visible = true; label19.Visible = true;

                label4.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label2.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label7.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label14.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label6.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label10.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label19.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";

            }
           
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label4.Visible || label2.Visible || label7.Visible || label14.Visible || label6.Visible || label10.Visible || label19.Visible)
            {
                label4.Visible = false;
                label2.Visible = false;
                label7.Visible = false;
                label14.Visible = false;
                label6.Visible = false;
                label10.Visible = false;
                label19.Visible = false;
            }

            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text)
                && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
               && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
                && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text)
                 && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text)
                 && !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text)
                 && !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
            {
                var command = new SqlCommand("UPDATE [Office] SET [Employee] = @Employee, [MBId] = @MBId, " +
                "[ProcId] = @ProcId, [MemoryId] = @MemoryId, [PSId] = @PSId, [HDId] = @HDId, [VCId] = @VCId WHERE [Id] = @Id", sqlConnection);
                command.Parameters.AddWithValue("Employee", textBox7.Text);
                command.Parameters.AddWithValue("MBId", textBox9.Text);
                command.Parameters.AddWithValue("ProcId", textBox1.Text);
                command.Parameters.AddWithValue("MemoryId", textBox3.Text);
                command.Parameters.AddWithValue("PSId", textBox6.Text);
                command.Parameters.AddWithValue("HDId", textBox5.Text);
                command.Parameters.AddWithValue("VCId", textBox2.Text);
                command.Parameters.AddWithValue("Id", textBox4.Text);

                listBox1.Items.Clear();

                textBox4.Clear(); textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear(); textBox9.Clear();

                label4.Visible = false;
                label2.Visible = false;
                label7.Visible = false;
                label14.Visible = false;
                label6.Visible = false;
                label10.Visible = false;
                label19.Visible = false;

                await command.ExecuteNonQueryAsync();

                SqlDataReader sqlReader = null;
                var command2 = new SqlCommand("SELECT [Office].Id, [Office].Employee, [MotherBoard].name, " +
                    "[Processor].Procname, [Memory].Memoryname, [PowerSupply].PSname, [HardDrive].HDname, [VideoCard ].VCname " +
                    "FROM [Office], [MotherBoard], [Processor], [Memory], [PowerSupply], [HardDrive], [VideoCard] " +
                    "WHERE [Office].MBId = [MotherBoard].MBId AND [Office].ProcId = [Processor].ProcId AND [Office].MemoryId = [Memory].MemoryId AND [Office].PSId = [PowerSupply].PSId AND [Office].HDId = [HardDrive].HDId AND [Office].VCId = [VideoCard ].VCId", sqlConnection);
                try
                {
                    sqlReader = await command2.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        listBox8.Items.Add(Convert.ToString(sqlReader["Id"]) + "      " +
                        Convert.ToString(sqlReader["Employee"]) + "      " + Convert.ToString(sqlReader["name"]) + "      "
                        + Convert.ToString(sqlReader["Procname"]) + "      " + Convert.ToString(sqlReader["VCname"])
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
            else
            {
                label4.Visible = true; label2.Visible = true; label7.Visible = true; label14.Visible = true; label6.Visible = true; label10.Visible = true; label19.Visible = true;

                label4.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label2.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label7.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label14.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label6.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label10.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label19.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";

            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            if (label4.Visible || label2.Visible || label7.Visible || label14.Visible || label6.Visible || label10.Visible || label19.Visible)
            {
                label4.Visible = false;
                label2.Visible = false;
                label7.Visible = false;
                label14.Visible = false;
                label6.Visible = false;
                label10.Visible = false;
                label19.Visible = false;
            }

            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text)
                && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
               && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
                && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text)
                 && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text)
                 && !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text)
                 && !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
            {
                var command = new SqlCommand("UPDATE [Office] SET [Employee] = @Employee, [MBId] = @MBId, " +
                "[ProcId] = @ProcId, [MemoryId] = @MemoryId, [PSId] = @PSId, [HDId] = @HDId, [VCId] = @VCId WHERE [Id] = @Id", sqlConnection);
                command.Parameters.AddWithValue("Employee", textBox7.Text);
                command.Parameters.AddWithValue("MBId", textBox9.Text);
                command.Parameters.AddWithValue("ProcId", textBox1.Text);
                command.Parameters.AddWithValue("MemoryId", textBox3.Text);
                command.Parameters.AddWithValue("PSId", textBox6.Text);
                command.Parameters.AddWithValue("HDId", textBox5.Text);
                command.Parameters.AddWithValue("VCId", textBox2.Text);
                command.Parameters.AddWithValue("Id", textBox4.Text);

                listBox1.Items.Clear();

                textBox4.Clear(); textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear(); textBox9.Clear();

                label4.Visible = false;
                label2.Visible = false;
                label7.Visible = false;
                label14.Visible = false;
                label6.Visible = false;
                label10.Visible = false;
                label19.Visible = false;

                await command.ExecuteNonQueryAsync();

                SqlDataReader sqlReader = null;
                var command2 = new SqlCommand("SELECT [Office].Id, [Office].Employee, [MotherBoard].name, " +
                    "[Processor].Procname, [Memory].Memoryname, [PowerSupply].PSname, [HardDrive].HDname, [VideoCard ].VCname " +
                    "FROM [Office], [MotherBoard], [Processor], [Memory], [PowerSupply], [HardDrive], [VideoCard] " +
                    "WHERE [Office].MBId = [MotherBoard].MBId AND [Office].ProcId = [Processor].ProcId AND [Office].MemoryId = [Memory].MemoryId AND [Office].PSId = [PowerSupply].PSId AND [Office].HDId = [HardDrive].HDId AND [Office].VCId = [VideoCard ].VCId", sqlConnection);
                try
                {
                    sqlReader = await command2.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        listBox8.Items.Add(Convert.ToString(sqlReader["Id"]) + "      " +
                        Convert.ToString(sqlReader["Employee"]) + "      " + Convert.ToString(sqlReader["name"]) + "      "
                        + Convert.ToString(sqlReader["Procname"]) + "      " + Convert.ToString(sqlReader["VCname"])
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
            else
            {
                label4.Visible = true; label2.Visible = true; label7.Visible = true; label14.Visible = true; label6.Visible = true; label10.Visible = true; label19.Visible = true;

                label4.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label2.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label7.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label14.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label6.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label10.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label19.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";

            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            if (label4.Visible || label2.Visible || label7.Visible || label14.Visible || label6.Visible || label10.Visible || label19.Visible)
            {
                label4.Visible = false;
                label2.Visible = false;
                label7.Visible = false;
                label14.Visible = false;
                label6.Visible = false;
                label10.Visible = false;
                label19.Visible = false;
            }

            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text)
                && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
               && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
                && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text)
                 && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text)
                 && !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text)
                 && !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
            {
                var command = new SqlCommand("UPDATE [Office] SET [Employee] = @Employee, [MBId] = @MBId, " +
                "[ProcId] = @ProcId, [MemoryId] = @MemoryId, [PSId] = @PSId, [HDId] = @HDId, [VCId] = @VCId WHERE [Id] = @Id", sqlConnection);
                command.Parameters.AddWithValue("Employee", textBox7.Text);
                command.Parameters.AddWithValue("MBId", textBox9.Text);
                command.Parameters.AddWithValue("ProcId", textBox1.Text);
                command.Parameters.AddWithValue("MemoryId", textBox3.Text);
                command.Parameters.AddWithValue("PSId", textBox6.Text);
                command.Parameters.AddWithValue("HDId", textBox5.Text);
                command.Parameters.AddWithValue("VCId", textBox2.Text);
                command.Parameters.AddWithValue("Id", textBox4.Text);

                listBox1.Items.Clear();

                textBox4.Clear(); textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear(); textBox9.Clear();

                label4.Visible = false;
                label2.Visible = false;
                label7.Visible = false;
                label14.Visible = false;
                label6.Visible = false;
                label10.Visible = false;
                label19.Visible = false;

                await command.ExecuteNonQueryAsync();

                SqlDataReader sqlReader = null;
                var command2 = new SqlCommand("SELECT [Office].Id, [Office].Employee, [MotherBoard].name, " +
                    "[Processor].Procname, [Memory].Memoryname, [PowerSupply].PSname, [HardDrive].HDname, [VideoCard ].VCname " +
                    "FROM [Office], [MotherBoard], [Processor], [Memory], [PowerSupply], [HardDrive], [VideoCard] " +
                    "WHERE [Office].MBId = [MotherBoard].MBId AND [Office].ProcId = [Processor].ProcId AND [Office].MemoryId = [Memory].MemoryId AND [Office].PSId = [PowerSupply].PSId AND [Office].HDId = [HardDrive].HDId AND [Office].VCId = [VideoCard ].VCId", sqlConnection);
                try
                {
                    sqlReader = await command2.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        listBox8.Items.Add(Convert.ToString(sqlReader["Id"]) + "      " +
                        Convert.ToString(sqlReader["Employee"]) + "      " + Convert.ToString(sqlReader["name"]) + "      "
                        + Convert.ToString(sqlReader["Procname"]) + "      " + Convert.ToString(sqlReader["VCname"])
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
            else
            {
                label4.Visible = true; label2.Visible = true; label7.Visible = true; label14.Visible = true; label6.Visible = true; label10.Visible = true; label19.Visible = true;

                label4.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label2.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label7.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label14.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label6.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label10.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label19.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";

            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (label4.Visible || label2.Visible || label7.Visible || label14.Visible || label6.Visible || label10.Visible || label19.Visible)
            {
                label4.Visible = false;
                label2.Visible = false;
                label7.Visible = false;
                label14.Visible = false;
                label6.Visible = false;
                label10.Visible = false;
                label19.Visible = false;
            }

            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text)
                && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
               && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
                && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text)
                 && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text)
                 && !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text)
                 && !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
            {
                var command = new SqlCommand("UPDATE [Office] SET [Employee] = @Employee, [MBId] = @MBId, " +
                "[ProcId] = @ProcId, [MemoryId] = @MemoryId, [PSId] = @PSId, [HDId] = @HDId, [VCId] = @VCId WHERE [Id] = @Id", sqlConnection);
                command.Parameters.AddWithValue("Employee", textBox7.Text);
                command.Parameters.AddWithValue("MBId", textBox9.Text);
                command.Parameters.AddWithValue("ProcId", textBox1.Text);
                command.Parameters.AddWithValue("MemoryId", textBox3.Text);
                command.Parameters.AddWithValue("PSId", textBox6.Text);
                command.Parameters.AddWithValue("HDId", textBox5.Text);
                command.Parameters.AddWithValue("VCId", textBox2.Text);
                command.Parameters.AddWithValue("Id", textBox4.Text);

                listBox1.Items.Clear();

                textBox4.Clear(); textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear(); textBox9.Clear();

                label4.Visible = false;
                label2.Visible = false;
                label7.Visible = false;
                label14.Visible = false;
                label6.Visible = false;
                label10.Visible = false;
                label19.Visible = false;

                await command.ExecuteNonQueryAsync();

                SqlDataReader sqlReader = null;
                var command2 = new SqlCommand("SELECT [Office].Id, [Office].Employee, [MotherBoard].name, " +
                    "[Processor].Procname, [Memory].Memoryname, [PowerSupply].PSname, [HardDrive].HDname, [VideoCard ].VCname " +
                    "FROM [Office], [MotherBoard], [Processor], [Memory], [PowerSupply], [HardDrive], [VideoCard] " +
                    "WHERE [Office].MBId = [MotherBoard].MBId AND [Office].ProcId = [Processor].ProcId AND [Office].MemoryId = [Memory].MemoryId AND [Office].PSId = [PowerSupply].PSId AND [Office].HDId = [HardDrive].HDId AND [Office].VCId = [VideoCard ].VCId", sqlConnection);
                try
                {
                    sqlReader = await command2.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        listBox8.Items.Add(Convert.ToString(sqlReader["Id"]) + "      " +
                        Convert.ToString(sqlReader["Employee"]) + "      " + Convert.ToString(sqlReader["name"]) + "      "
                        + Convert.ToString(sqlReader["Procname"]) + "      " + Convert.ToString(sqlReader["VCname"])
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
            else
            {
                label4.Visible = true; label2.Visible = true; label7.Visible = true; label14.Visible = true; label6.Visible = true; label10.Visible = true; label19.Visible = true;

                label4.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label2.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label7.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label14.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label6.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label10.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label19.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";

            }
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            if (label4.Visible || label2.Visible || label7.Visible || label14.Visible || label6.Visible || label10.Visible || label19.Visible)
            {
                label4.Visible = false;
                label2.Visible = false;
                label7.Visible = false;
                label14.Visible = false;
                label6.Visible = false;
                label10.Visible = false;
                label19.Visible = false;
            }

            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text)
                && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
               && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
                && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text)
                 && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text)
                 && !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text)
                 && !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
            {
                var command = new SqlCommand("UPDATE [Office] SET [Employee] = @Employee, [MBId] = @MBId, " +
                "[ProcId] = @ProcId, [MemoryId] = @MemoryId, [PSId] = @PSId, [HDId] = @HDId, [VCId] = @VCId WHERE [Id] = @Id", sqlConnection);
                command.Parameters.AddWithValue("Employee", textBox7.Text);
                command.Parameters.AddWithValue("MBId", textBox9.Text);
                command.Parameters.AddWithValue("ProcId", textBox1.Text);
                command.Parameters.AddWithValue("MemoryId", textBox3.Text);
                command.Parameters.AddWithValue("PSId", textBox6.Text);
                command.Parameters.AddWithValue("HDId", textBox5.Text);
                command.Parameters.AddWithValue("VCId", textBox2.Text);
                command.Parameters.AddWithValue("Id", textBox4.Text);

                listBox1.Items.Clear();

                textBox4.Clear(); textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear(); textBox9.Clear();

                label4.Visible = false;
                label2.Visible = false;
                label7.Visible = false;
                label14.Visible = false;
                label6.Visible = false;
                label10.Visible = false;
                label19.Visible = false;

                await command.ExecuteNonQueryAsync();

                SqlDataReader sqlReader = null;
                var command2 = new SqlCommand("SELECT [Office].Id, [Office].Employee, [MotherBoard].name, " +
                    "[Processor].Procname, [Memory].Memoryname, [PowerSupply].PSname, [HardDrive].HDname, [VideoCard ].VCname " +
                    "FROM [Office], [MotherBoard], [Processor], [Memory], [PowerSupply], [HardDrive], [VideoCard] " +
                    "WHERE [Office].MBId = [MotherBoard].MBId AND [Office].ProcId = [Processor].ProcId AND [Office].MemoryId = [Memory].MemoryId AND [Office].PSId = [PowerSupply].PSId AND [Office].HDId = [HardDrive].HDId AND [Office].VCId = [VideoCard ].VCId", sqlConnection);
                try
                {
                    sqlReader = await command2.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        listBox8.Items.Add(Convert.ToString(sqlReader["Id"]) + "      " +
                        Convert.ToString(sqlReader["Employee"]) + "      " + Convert.ToString(sqlReader["name"]) + "      "
                        + Convert.ToString(sqlReader["Procname"]) + "      " + Convert.ToString(sqlReader["VCname"])
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
            else
            {
                label4.Visible = true; label2.Visible = true; label7.Visible = true; label14.Visible = true; label6.Visible = true; label10.Visible = true; label19.Visible = true;

                label4.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label2.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label7.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label14.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label6.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label10.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label19.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";

            }
        }

        private async void button13_Click(object sender, EventArgs e)
        {
            if (label4.Visible || label2.Visible || label7.Visible || label14.Visible || label6.Visible || label10.Visible || label19.Visible)
            {
                label4.Visible = false;
                label2.Visible = false;
                label7.Visible = false;
                label14.Visible = false;
                label6.Visible = false;
                label10.Visible = false;
                label19.Visible = false;
            }

            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text)
                && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
               && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
                && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text)
                 && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text)
                 && !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text)
                 && !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
            {
                var command = new SqlCommand("UPDATE [Office] SET [Employee] = @Employee, [MBId] = @MBId, " +
                "[ProcId] = @ProcId, [MemoryId] = @MemoryId, [PSId] = @PSId, [HDId] = @HDId, [VCId] = @VCId WHERE [Id] = @Id", sqlConnection);
                command.Parameters.AddWithValue("Employee", textBox7.Text);
                command.Parameters.AddWithValue("MBId", textBox9.Text);
                command.Parameters.AddWithValue("ProcId", textBox1.Text);
                command.Parameters.AddWithValue("MemoryId", textBox3.Text);
                command.Parameters.AddWithValue("PSId", textBox6.Text);
                command.Parameters.AddWithValue("HDId", textBox5.Text);
                command.Parameters.AddWithValue("VCId", textBox2.Text);
                command.Parameters.AddWithValue("Id", textBox4.Text);

                listBox1.Items.Clear();

                textBox4.Clear(); textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear(); textBox9.Clear();

                label4.Visible = false;
                label2.Visible = false;
                label7.Visible = false;
                label14.Visible = false;
                label6.Visible = false;
                label10.Visible = false;
                label19.Visible = false;

                await command.ExecuteNonQueryAsync();

                SqlDataReader sqlReader = null;
                var command2 = new SqlCommand("SELECT [Office].Id, [Office].Employee, [MotherBoard].name, " +
                    "[Processor].Procname, [Memory].Memoryname, [PowerSupply].PSname, [HardDrive].HDname, [VideoCard ].VCname " +
                    "FROM [Office], [MotherBoard], [Processor], [Memory], [PowerSupply], [HardDrive], [VideoCard] " +
                    "WHERE [Office].MBId = [MotherBoard].MBId AND [Office].ProcId = [Processor].ProcId AND [Office].MemoryId = [Memory].MemoryId AND [Office].PSId = [PowerSupply].PSId AND [Office].HDId = [HardDrive].HDId AND [Office].VCId = [VideoCard ].VCId", sqlConnection);
                try
                {
                    sqlReader = await command2.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        listBox8.Items.Add(Convert.ToString(sqlReader["Id"]) + "      " +
                        Convert.ToString(sqlReader["Employee"]) + "      " + Convert.ToString(sqlReader["name"]) + "      "
                        + Convert.ToString(sqlReader["Procname"]) + "      " + Convert.ToString(sqlReader["VCname"])
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
            else
            {
                label4.Visible = true; label2.Visible = true; label7.Visible = true; label14.Visible = true; label6.Visible = true; label10.Visible = true; label19.Visible = true;

                label4.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label2.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label7.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label14.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label6.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label10.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";
                label19.Text = "Поля заполнены некорретно. Пожалуйста, не оставляйте пустых полей и используйте латиницу. Поле Работник может быть пустым.";

            }
        }

        private void UpdateDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed) sqlConnection.Close();
        }
    }
}
