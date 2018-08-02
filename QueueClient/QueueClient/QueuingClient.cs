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
        //private String newNumber;
        private static String ip = Emp.IPAddress;

        public QueuingClient()
        {
            InitializeComponent();
            /* The Employee ID/Cubicle Number will be displayed on the lower left hand corner*/
            cubID.Text = Emp.empId.ToString();
            /* Get the last number of the cubicle (on startup) */
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server="+ip+";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                mysqlCon.Open();
                currentNumber.Text = QueueDB.getLastServed(Emp.empId.ToString(), mysqlCon);

            }
            /* Check if there are recalled records as of today (on startup). See the method below. */
            FirstCheck();

            SecondCheck();

            ThirdCheck();


        }

        /* This method will check if there are any recalled records as of today */
        private Boolean InitialCheck(int x)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=" + ip + ";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                int check = 0;
                MySqlDataReader reader = null;
                String sql = "SELECT COUNT(queue_id) FROM recalled_records WHERE cubicle_number = @cubiclenumber AND date(timestamp) = date(now());";
                mysqlCon.Open();
                MySqlCommand cmd = new MySqlCommand(sql, mysqlCon);
                cmd.Parameters.AddWithValue("@cubiclenumber", x);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    check = reader.GetInt32(0);

                }
                if (check == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
        }

        public Boolean SecondInitialCheck(int x)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=" + ip + ";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                int check = 0;
                MySqlDataReader reader = null;
                String sql = "SELECT COUNT(queue_id) FROM queue_stat WHERE cubicle_number = @cubiclenumber AND date(timestamp) = date(now());";
                mysqlCon.Open();
                MySqlCommand cmd = new MySqlCommand(sql, mysqlCon);
                cmd.Parameters.AddWithValue("@cubiclenumber", x);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    check = reader.GetInt32(0);

                }
                if (check == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
        }

        public Boolean ActivationCheck(int x)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=" + ip + ";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                int check = 0;
                MySqlDataReader reader = null;
                String sql = "SELECT deact_flag FROM queue_stat WHERE cubicle_number = @cubiclenumber AND date(timestamp) = date(now()) ORDER BY queue_id DESC LIMIT 1;";
                mysqlCon.Open();
                MySqlCommand cmd = new MySqlCommand(sql, mysqlCon);
                cmd.Parameters.AddWithValue("@cubiclenumber", x);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    check = reader.GetInt32(0);

                }
                if (check == 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }




        /* Main Buttons */
        /* Call a Student Method. Type - insert into DB */
        private async void callStudent_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server="+ip+";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                string query = "SELECT * FROM osa_queuing.queue_stat WHERE date(timestamp) = date(now()) AND deact_flag = 0 UNION SELECT *, 0 FROM recalled_records WHERE date(timestamp) = date(now()) ORDER BY timestamp DESC Limit 1;";
                try
                {
                    callStudent.Enabled = false;
                    mysqlCon.Open();
                    l = QueueDB.gatherData(mysqlCon, query);
                    foreach (QueueStat cd in l)
                    {
                        currNumber = cd.getServingNumber() + 1;
                        if (currNumber == 71)
                        {
                            currNumber = 1;
                        }
                        //newNumber = currNumber.ToString();
                    }
                    //DateTime c = new DateTime(DateTimeOffset.Now.ToUnixTimeMilliseconds());
                    DateTime c = new DateTime(DateTime.Now.Ticks);

                    QueueStat qs = new QueueStat(Emp.empId, currNumber, c);
                    mysqlCon.Open();
                    QueueDB.addQueue(qs);
                    currentNumber.Text = QueueDB.getLastServed(Emp.empId.ToString(), mysqlCon);
                    FirstCheck();
                    await Task.Delay(3000);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                finally
                {
                    callStudent.Enabled = true;
                }
                
            }

        }

        /* Previous Button Method. Type - "transfer" record from main table (queue_stat) to temporary table via SPs */
        private void PrevButton_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=" + ip + ";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                mysqlCon.Open();
                InsertToRecall(Emp.empId);
                currentNumber.Text = QueueDB.getLastServed(Emp.empId.ToString(), mysqlCon);
                FirstCheck();
                SecondCheck();
                
            }
        }

        private void FirstCheck()
        {
            if (SecondInitialCheck(Emp.empId))
            {
                PrevButton.Enabled = false;
            }
            else
            {
                PrevButton.Enabled = true;
            }
        }

        private void SecondCheck()
        {
            if (!InitialCheck(Emp.empId))
            {
                callStudent.Enabled = false;
                NextButton.Enabled = true;
                activateToolStripMenuItem.Enabled = false;
                deactivateToolStripMenuItem.Enabled = false;
            }
            else
            {
                callStudent.Enabled = true;
                NextButton.Enabled = false;
                activateToolStripMenuItem.Enabled = true;
                deactivateToolStripMenuItem.Enabled = true;
            }
        }

        private void ThirdCheck()
        {
            if (ActivationCheck(Emp.empId))
            {
                activateToolStripMenuItem.Visible = false;
                deactivateToolStripMenuItem.Visible = true;
                FirstCheck();
                SecondCheck();
            }
            else
            {
                activateToolStripMenuItem.Visible = true;
                deactivateToolStripMenuItem.Visible = false;
                callStudent.Enabled = false;
                PrevButton.Enabled = false;
                NextButton.Enabled = false;
            }
        }

        /* Previous Button Method. Type - same as above, but the other way around*/

        private void NextButton_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=" + ip + ";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                mysqlCon.Open();
                DeleteFromRecall(Emp.empId);
                currentNumber.Text = QueueDB.getLastServed(Emp.empId.ToString(), mysqlCon);
                FirstCheck();


                SecondCheck();
            }
        }

        private void clientLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f = new Login();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        /* End of Main Buttons */


        /* Menu Items */
        private void editCredentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAccountSettings();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ShowStats();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowAbout();
        }


        private void ShowAccountSettings()
        {
            AccountSettings f = new AccountSettings();
            f.ShowDialog();
        }

        private void ShowStats()
        {
            QueueClientStat r = new QueueClientStat();
            r.ShowDialog();
        }

        private void ShowAbout()
        {
            About re = new About();
            re.ShowDialog();
        }

     
        

        
        /* Stored Procedure Methods */
        private void InsertToRecall(int x)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=" + ip + ";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                try{
                    mysqlCon.Open();
                    MySqlCommand cmd = new MySqlCommand("insert_recall", mysqlCon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new MySqlParameter("@num", x));
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void DeleteFromRecall(int x)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=" + ip + ";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                try
                {
                    mysqlCon.Open();
                    MySqlCommand cmd = new MySqlCommand("remove_recall", mysqlCon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new MySqlParameter("@num", x));
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

            }
        }

        private void DeactivateCubicle(int x)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=" + ip + ";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                try
                {
                    mysqlCon.Open();
                    MySqlCommand cmd = new MySqlCommand("deact_account", mysqlCon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new MySqlParameter("@num", x));
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void ActivateCubicle(int x)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=" + ip + ";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                try
                {
                    mysqlCon.Open();
                    MySqlCommand cmd = new MySqlCommand("act_account", mysqlCon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new MySqlParameter("@num", x));
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void InsertToMultRecall(int x)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=" + ip + ";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                try
                {
                    mysqlCon.Open();
                    MySqlCommand cmd = new MySqlCommand("insert_mult_recalls", mysqlCon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new MySqlParameter("@num", x));
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void DeleteFromMultRecall(int x)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=" + ip + ";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                try
                {
                    mysqlCon.Open();
                    MySqlCommand cmd = new MySqlCommand("remove_mult_recall", mysqlCon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new MySqlParameter("@num", x));
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void deactivateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertToMultRecall(Emp.empId);
            DeactivateCubicle(Emp.empId);
            ThirdCheck();
            currentNumber.Text = "N/A";
        }

        private void activateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActivateCubicle(Emp.empId);
            DeleteFromMultRecall(Emp.empId);
            ThirdCheck();
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=" + ip + ";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                mysqlCon.Open();
                currentNumber.Text = QueueDB.getLastServed(Emp.empId.ToString(), mysqlCon);
            }
        }
    }
}
