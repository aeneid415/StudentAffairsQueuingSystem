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
using System.Collections;
using System.Threading;

namespace QueueClient
{
    public partial class QueuingClient : Form
    {
        private ArrayList l = new ArrayList();
        private int currNumber = 1;
        private String newNumber;

        public QueuingClient()
        {
            InitializeComponent();
            cubID.Text = Emp.empId.ToString();
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=localhost;Database=osa_queuing;Uid=root;Pwd=;"))
            {
                currentNumber.Text = QueueDB.getLastServed(Emp.empId.ToString(), mysqlCon);

            }


        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void callStudent_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=localhost;Database=osa_queuing;Uid=root;Pwd=;"))
            {
                try
                {
                    mysqlCon.Open();
                    l = QueueDB.gatherData(mysqlCon);
                    foreach (QueueStat cd in l)
                    {
                        currNumber = cd.getServingNumber() + 1;
                        if (currNumber == 71)
                        {
                            currNumber = 1;
                        }
                        newNumber = currNumber.ToString();
                    }
                    //DateTime c = new DateTime(DateTimeOffset.Now.ToUnixTimeMilliseconds());
                    DateTime c = new DateTime(DateTime.Now.Ticks);

                    QueueStat qs = new QueueStat(Emp.empId, currNumber, c);
                    QueueDB.addQueue(qs);
                    currentNumber.Text = QueueDB.getLastServed(Emp.empId.ToString(), mysqlCon);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The connection to the database server has either terminated abruptly or it doesn't exist.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                
            }

        }

        private void editCredentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            /*MessageBox.Show("This is a message", "Testing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AccountSettings f = new AccountSettings();
            f.Closed += (s, args) => this.Close();
            f.Show();
            */
            Thread sr = new Thread(new ThreadStart(ShowAccountSettings));
            sr.Start();
        }

        private void ShowAccountSettings()
        {
            AccountSettings f = new AccountSettings();
            f.ShowDialog();
        }

        private void clientLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f = new Login();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TimeSpan r = new TimeSpan(17, 0, 0);

            //TimeSpan s = DateTime.Now.TimeOfDay;
            //string sr = DateTime.Now.ToString("h:mm:ss tt");
            //MessageBox.Show(r.ToString() + ' ' + s.ToString(), "Testing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Thread sf = new Thread(new ThreadStart(ShowStats));
            sf.Start();
        }

        private void ShowStats()
        {
            QueueClientStat r = new QueueClientStat();
            r.ShowDialog();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Thread sf = new Thread(new ThreadStart(ShowAbout));
            sf.Start();
        }

        private void ShowAbout()
        {
            About re = new About();
            re.ShowDialog();
        }
    }
}
