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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=localhost;Database=osa_queuing;Uid=root;Pwd=;"))
            {
                int count = 0;
                int id = 0;
                mysqlCon.Open();
                MySqlDataReader reader = null;
                string query = "SELECT account_id, username, password, department FROM accounts WHERE (username = @username AND password = @password AND department = @department);";

                MySqlCommand command = new MySqlCommand(query, mysqlCon);
                command.Parameters.AddWithValue("@username", txt_username.Text);
                command.Parameters.AddWithValue("@password", txt_password.Text);
                command.Parameters.AddWithValue("@department", txt_department.Text);
                reader = command.ExecuteReader();
                String access = txt_department.Text;
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    Emp.empId = id;
                    count = count + 1;
                }

                if(access == "Admin")
                {
                    if (count == 1)
                    {
                        MessageBox.Show("Login successful! Welcome, Admin.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {

                        MessageBox.Show("Username and Password are wrong!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if(access == "Service Cubicle")
                {
                    if(count == 1)
                    {
                        MessageBox.Show("You have successfully logged in. Welcome, Cubicle " + id, "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        QueuingClient f = new QueuingClient();
                        f.Closed += (s, args) => this.Close();
                        f.Show();

                    }
                    else
                    {
                        MessageBox.Show("Username and Password are wrong!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("You have not selected a department. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }

        }
    }
}
