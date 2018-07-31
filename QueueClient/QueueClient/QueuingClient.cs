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
            if (SecondInitialCheck(Emp.empId))
            {
                PrevButton.Enabled = false;
            }
            else
            {
                PrevButton.Enabled = true;
            }


            if (!InitialCheck(Emp.empId))
            {
                callStudent.Enabled = false;
                NextButton.Enabled = true;
            }
            
            else
            {
                callStudent.Enabled = true;
                NextButton.Enabled = false;
            }


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




        /* Main Buttons */
        /* Call a Student Method. Type - insert into DB */
        private async void callStudent_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server="+ip+";Database=osa_queuing;Uid=root;Pwd=;"))
            {
                try
                {
                    callStudent.Enabled = false;
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
                    mysqlCon.Open();
                    QueueDB.addQueue(qs);
                    currentNumber.Text = QueueDB.getLastServed(Emp.empId.ToString(), mysqlCon);
                    if (SecondInitialCheck(Emp.empId))
                    {
                        PrevButton.Enabled = false;
                    }
                    else
                    {
                        PrevButton.Enabled = true;
                    }
                    await Task.Delay(3000);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The connection to the database server has either terminated abruptly or it doesn't exist.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (SecondInitialCheck(Emp.empId))
                {
                    PrevButton.Enabled = false;
                }
                else
                {
                    PrevButton.Enabled = true;
                }

                if (!InitialCheck(Emp.empId))
                {
                    callStudent.Enabled = false;
                    NextButton.Enabled = true;
                }
                else 
                {
                    callStudent.Enabled = true;
                    NextButton.Enabled = false;
                }
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
                if (SecondInitialCheck(Emp.empId))
                {
                    PrevButton.Enabled = false;
                }
                else
                {
                    PrevButton.Enabled = true;
                }


                if (!InitialCheck(Emp.empId))
                {
                    callStudent.Enabled = false;
                    NextButton.Enabled = true;
                }
                else
                {
                    callStudent.Enabled = true;
                    NextButton.Enabled = false;
                }
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


    }
}
