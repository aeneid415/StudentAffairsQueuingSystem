using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace QueueClient
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            if (Emp.IPAddress == null)
            {
                IPLabel.Visible = true;
                txt_IPAddress.Visible = true;
            }
            else
            {
                txt_IPAddress.Text = Emp.IPAddress;
                this.Size = new Size(435, 390);
                loginButton.Location = new Point(148, 310);
                lbl_ForgotPassword.Location = new Point(157, 280);
            }

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Emp.IPAddress = txt_IPAddress.Text;
            String ip = Emp.IPAddress;
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server="+ip+";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                try
                {
                    int count = 0;
                    int id = 0;
                    String firstname = "";
                    String lastname = "";
                    mysqlCon.Open();
                    MySqlDataReader reader = null;
                    string query = "SELECT account_id, username, password, first_name, last_name, department FROM accounts WHERE (username = @username AND password = @password AND department = @department);";

                    MySqlCommand command = new MySqlCommand(query, mysqlCon);
                    command.Parameters.AddWithValue("@username", txt_username.Text);
                    command.Parameters.AddWithValue("@password", GetPasswordHashed(txt_password.Text));
                    command.Parameters.AddWithValue("@department", txt_department.Text);
                    reader = command.ExecuteReader();
                    String access = txt_department.Text;
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                        firstname = reader.GetString(3);
                        lastname = reader.GetString(4);
                        Emp.empId = id;
                        count = count + 1;
                    }

                    if (access == "Admin")
                    {
                        if (count == 1)
                        {
                            MessageBox.Show("Login successful! Welcome, " + firstname + " " + lastname + ".", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            AdminModule f = new AdminModule();
                            f.Closed += (s, args) => this.Close();
                            f.Show();
                        }
                        else
                        {

                            MessageBox.Show("Username and Password are wrong!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (access == "Service Cubicle")
                    {
                        if (count == 1)
                        {
                            MessageBox.Show("You have successfully logged in. Welcome, " + firstname + " " + lastname + ", presiding over Cubicle " + id + ".", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid IP Address (or your server is out). Please try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

        }

        private void lbl_ForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetPassword f = new ForgetPassword();
            f.ShowDialog();
        }

        private String GetPasswordHashed(String source)
        {
            using (MD5 md5hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5hash, source);

                return VerifyMd5Hash(md5hash, source, hash) ? hash : null;
            }
        }

        private bool VerifyMd5Hash(MD5 md5hash, string source, string hash)
        {
            string hashOfInput = GetMd5Hash(md5hash, source);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0 ? true : false;


        }

        static string GetMd5Hash(MD5 md5hash, string source)
        {
            byte[] data = md5hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
