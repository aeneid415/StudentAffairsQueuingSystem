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
    public partial class QueueClientStat : Form
    {
        static String ip = Emp.IPAddress;
        public QueueClientStat()
        {
            InitializeComponent();
            this.ControlBox = false;
            UpdateNumber();
            SetDateAndTime();
        }

        private void CloseStatistics_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void UpdateNumber()
        {
            MySqlDataReader reader = null;
            int tr = 0;
            using (MySqlConnection secondCon = new MySqlConnection(@"Server="+ip+";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                try
                {
                    String sql = "SELECT COUNT(queue_id) FROM queue_stat WHERE cubicle_number = @cubiclenumber AND date(timestamp) = date(now());";
                    secondCon.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, secondCon);
                    cmd.Parameters.AddWithValue("@cubiclenumber", Emp.empId);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tr = reader.GetInt32(0);
                    }
                    CubicleStats.Text = tr.ToString();
                }
                catch (Exception ml)
                {
                    MessageBox.Show("The connection to the database server has either terminated abruptly or it doesn't exist.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(Environment.ExitCode);
                }

            }
        }

        private void SetDateAndTime()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("h:mm:ss tt");
            DateLabel.Text = "As of " + date + " at " + time + ", you have served: ";
        }


    }
}
