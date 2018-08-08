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
    public partial class AccountSettings : Form
    {
        static String ip = Emp.IPAddress;
        public AccountSettings()
        {
            InitializeComponent();
            DefaultUsername();
            //this.ControlBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DefaultUsername()
        {
            MySqlDataReader reader = null;
            String firstname = "";
            String lastname = "";
            String username = "";
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server="+ip+";Database=osa_queuing;Uid=root;Pwd=;"))
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
                        firstname = reader.GetString(3);
                        lastname = reader.GetString(4);
                    }
                    Txt_Username.Text = username;
                    Txt_Firstname.Text = firstname;
                    Txt_Lastname.Text = lastname;
                }catch(Exception)
                {
                    MessageBox.Show("Cannot connect to database server.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(Environment.ExitCode);
                }
            }
        }

        private void AccountUpdate_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server="+ip+";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                try
                {
                    mysqlCon.Open();
                    String sql = "UPDATE accounts SET username = @username, password = @password, first_name = @firstname, last_name = @lastname WHERE account_id = @accountid";
                    if (!(Txt_Password.Text.Equals(Txt_ConfPass.Text)))
                    {
                        MessageBox.Show("Both of your new passwords do not match. Please try again.", "Account Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (Txt_Firstname.Equals("") || Txt_Lastname.Equals("") || Txt_Username.Equals("") || Txt_Password.Equals(""))
                    {
                        MessageBox.Show("Please fill in all the needed details.", "Account Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand(sql, mysqlCon);
                        cmd.Parameters.AddWithValue("@username", Txt_Username.Text);
                        cmd.Parameters.AddWithValue("@password", GetPasswordHashed(Txt_Password.Text));
                        cmd.Parameters.AddWithValue("@firstname", Txt_Firstname.Text);
                        cmd.Parameters.AddWithValue("@lastname", Txt_Lastname.Text);
                        cmd.Parameters.AddWithValue("@accountid", Emp.empId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your account has successfully updated!", "Account Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Sorry, we can't update your account details/credentials as your connection was interrupted.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
