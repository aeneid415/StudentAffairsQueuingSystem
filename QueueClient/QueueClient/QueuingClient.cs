﻿using System;
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
            QueueDB.setCon();
            currentNumber.Text = QueueDB.getLastServed(Emp.empId.ToString());
            QueueDB.connectionClose();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void callStudent_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=localhost;Database=osa_queuing;Uid=root;Pwd=;"))
            {
                QueueDB.setCon();
                l = QueueDB.gatherData();
                foreach (QueueStat cd in l)
                {
                    currNumber = cd.getServingNumber() + 1;
                    if(currNumber == 71)
                    {
                        currNumber = 1;
                    }
                    newNumber = currNumber.ToString();
                }
                //DateTime c = new DateTime(DateTimeOffset.Now.ToUnixTimeMilliseconds());
                DateTime c = new DateTime(DateTime.Now.Ticks);
                
                QueueStat qs = new QueueStat(Emp.empId, currNumber, c);
                QueueDB.addQueue(qs);
                currentNumber.Text = QueueDB.getLastServed(Emp.empId.ToString());
            }

        }

        private void editCredentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("This is a message", "Testing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AccountSettings f = new AccountSettings();
            f.Closed += (s, args) => this.Close();
            f.Show();
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

        
    }
}
