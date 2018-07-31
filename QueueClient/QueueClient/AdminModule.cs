using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QueueClient
{
    public partial class AdminModule : Form
    {
        static String ip = Emp.IPAddress;

        public AdminModule()
        {
            InitializeComponent();
            
            SetCubicleNumbers();
        }

        private void AdminLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f = new Login();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void ShowStat_Click(object sender, EventArgs e)
        {
            TimeSpan r = new TimeSpan(17, 0, 0);
            TimeSpan s = DateTime.Now.TimeOfDay;

            if (r > s)
            {
                MessageBox.Show("Data will be available at 5:00 PM.", "Time Check", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                SetEverythingToVisible();
            }
        }

        private void SetCubicleNumbers()
        {
            
            String sql = "SELECT (SELECT COUNT(queue_id) FROM queue_stat WHERE cubicle_number = 1 " +
                " AND date(timestamp) = date(now())) AS 'cubicle1', (SELECT COUNT(queue_id) FROM queue_stat WHERE cubicle_number = 2 " +
                "AND date(timestamp) = date(now())) AS 'cubicle2', (SELECT COUNT(queue_id) FROM queue_stat WHERE cubicle_number = 3 " +
                "AND date(timestamp) = date(now())) AS 'cubicle3', (SELECT COUNT(queue_id) FROM queue_stat WHERE cubicle_number = 4 " +
                "AND date(timestamp) = date(now())) As 'cubicle4', DATE(NOW()) AS date;";
            MySqlDataReader reader = null;
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server="+ip+";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                try
                {
                    mysqlCon.Open();
                    MySqlCommand com = new MySqlCommand(sql, mysqlCon);
                    reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        cubicle1.Text = reader.GetInt32(0).ToString();
                        cubicle2.Text = reader.GetInt32(1).ToString();
                        cubicle3.Text = reader.GetInt32(2).ToString();
                        cubicle4.Text = reader.GetInt32(3).ToString();
                    }
                    mysqlCon.Close();
                }catch(Exception ex)
                {
                    MessageBox.Show("The connection to the database server has either terminated abruptly or it doesn't exist.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetEverythingToVisible()
        {
            DateTime d = DateTime.Now;
            String r = d.Date.ToString("yyyy-MM-dd");

            cubicle1.Visible = true;
            cubicle2.Visible = true;
            cubicle3.Visible = true;
            cubicle4.Visible = true;
            dateLabel.Text = "Recorded as of: " + r;

        }

        private void ShowServer()
        {
            QueueClientServerWithDesign r = new QueueClientServerWithDesign();
            r.ShowDialog();
            //Application.Run(new QueueServerAdmin());
        }

        private void ViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread sf = new Thread(new ThreadStart(ShowServer));
            sf.Start();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Thread st = new Thread(new ThreadStart(ShowAccountChange));
            //st.Start();
            ShowAccountChange();
        }

        private void ShowAccountChange()
        {
            AccountSettings f = new AccountSettings();
            f.ShowDialog();
        }

        private void ShowAccountCreate()
        {
            AccountCreation f = new AccountCreation();
            f.ShowDialog();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAccountCreate();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAbout();
        }

        private void ShowAbout()
        {
            About re = new About();
            re.ShowDialog();
        }
    }
}
