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
    
    public partial class AccountCreation : Form
    {
        static String ip = Emp.IPAddress;
        public AccountCreation()
        {
            InitializeComponent();
        }

        private void AccountCreate_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=" + ip + ";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                try
                {
                    mysqlCon.Open();
                    String sql = "INSERT INTO accounts (username, password, first_name, last_name, department) VALUES (@username, @password, @firstname, @lastname, 'Admin')";
                    if (!(Txt_Password.Text.Equals(Txt_ConfPass.Text)))
                    {
                        MessageBox.Show("Both of your new passwords do not match. Please try again.", "Account Settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand(sql, mysqlCon);
                        cmd.Parameters.AddWithValue("@username", Txt_Username.Text);
                        cmd.Parameters.AddWithValue("@password", Txt_Password.Text);
                        cmd.Parameters.AddWithValue("@firstname", Txt_Firstname.Text);
                        cmd.Parameters.AddWithValue("@lastname", Txt_Lastname.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your account was successfully created!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.ExitThread();
                    }
                }catch (Exception)
                {
                    MessageBox.Show("Sorry, we can't create your account as your connection was interrupted.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
    }
}
