using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QueueClient
{
    public partial class AccountSettings : Form
    {
        public AccountSettings()
        {
            InitializeComponent();
            DefaultUsername();
            //this.ControlBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void DefaultUsername()
        {
            MySqlDataReader reader = null;
            String username = "";
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=localhost;Database=osa_queuing;Uid=root;Pwd=;"))
            {
                try
                {
                    mysqlCon.Open();
                    String sql = "SELECT * FROM accounts WHERE account_id = @accountid";
                    MySqlCommand cmd = new MySqlCommand(sql, mysqlCon);
                    cmd.Parameters.AddWithValue("@accountid", Emp.empId);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        username = reader.GetString(1);
                    }
                    Txt_Username.Text = username;
                }catch(Exception ex)
                {
                    MessageBox.Show("Cannot connect to database server.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(Environment.ExitCode);
                }
            }
        }

        private void AccountUpdate_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=localhost;Database=osa_queuing;Uid=root;Pwd=;"))
            {
                try
                {
                    mysqlCon.Open();
                    String sql = "UPDATE accounts SET username = @username, password = @password WHERE account_id = @accountid";
                    if (!(Txt_Password.Text.Equals(Txt_ConfPass.Text)))
                    {
                        MessageBox.Show("Both of your new passwords do not match. Please try again.", "Account Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand(sql, mysqlCon);
                        cmd.Parameters.AddWithValue("@username", Txt_Username.Text);
                        cmd.Parameters.AddWithValue("@password", Txt_Password.Text);
                        cmd.Parameters.AddWithValue("@accountid", Emp.empId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your account has successfully updated!", "Account Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.ExitThread();
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sorry, we can't update your account credentials.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
