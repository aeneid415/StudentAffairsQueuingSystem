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
                        cmd.Parameters.AddWithValue("@password", GetPasswordHashed(Txt_Password.Text));
                        cmd.Parameters.AddWithValue("@firstname", Txt_Firstname.Text);
                        cmd.Parameters.AddWithValue("@lastname", Txt_Lastname.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your account was successfully created!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }catch (Exception)
                {
                    MessageBox.Show("Sorry, we can't create your account as your connection was interrupted.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Application.ExitThread();
            this.Close();
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
