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
    public partial class ForgetPassword : Form
    {
        public ForgetPassword()
        {
            InitializeComponent();
            this.ControlBox = false;
            if(Emp.IPAddress == null)
            {
                IPLabel.Visible = true;
                Txt_ServerIP.Visible = true;
            }
            else
            {
                Txt_ServerIP.Text = Emp.IPAddress;
                closeButton.Location = new Point(230, 180);
                AccountUpdate.Location = new Point(100, 180);
                this.Size = new Size(440, 260);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AccountUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                CheckAccount();
                UpdatePassword();

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Username does not exist!", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (MySqlException)
            {
                MessageBox.Show("Your account cannot be updated. Either your IP Address is wrong or you have disconnected from the server.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }


            
        }

        public void CheckAccount()
        {
            String ip = Txt_ServerIP.Text;
            MySqlDataReader reader = null; 
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=" + ip + ";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                mysqlCon.Open();
                String sql = "SELECT username FROM accounts WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(sql, mysqlCon);
                cmd.Parameters.AddWithValue("@username", Txt_Username.Text);
                reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    throw new ArgumentException("Username cannot be found!");
                }
            }
        }

        public void UpdatePassword()
        {
            String ip = Txt_ServerIP.Text;
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=" + ip + ";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                mysqlCon.Open();
                String sql = "UPDATE accounts SET password = @password WHERE username = @username";
                if (!(Txt_Password.Text.Equals(Txt_ConfPass.Text)))
                {
                    MessageBox.Show("Both of your new passwords do not match. Please try again.", "Account Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Txt_Username.Equals("") || Txt_Password.Equals("") || Txt_ServerIP.Equals(""))
                {
                    MessageBox.Show("Please fill in all the needed details.", "Account Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand(sql, mysqlCon);
                    cmd.Parameters.AddWithValue("@username", Txt_Username.Text);
                    cmd.Parameters.AddWithValue("@password", Txt_Password.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your account has successfully updated!", "Account Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
    }
}
