using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QueueServer
{
    public partial class QueueServer : Form
    {
        
        private static int x;
        private static String y;
        private static String z;
        private static ArrayList l = new ArrayList();

        public QueueServer()
        {
            InitializeComponent();
            InitTimer();
        }

        public void InitTimer()
        {
            timer2 = new Timer();
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Interval = 2000;
            timer2.Start();
        }

        private void QueueServer_Load(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            QueueDB.setCon();
            l = QueueDB.gatherData();
            foreach (QueueStat c in l)
            {
                x = c.getCubicleNumber();
                y = c.getServingNumber().ToString();
            }
            checkLastNumbers(x);

            servingNumber.Text = y;
            QueueDB.connectionClose();
        }

        private void checkLastNumbers(int x)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=localhost;Database=osa_queuing;Uid=root;Pwd=;"))
            {
                mysqlCon.Open();
                MySqlDataReader reader = null;
                string query = "SELECT * FROM osa_queuing.queue_stat WHERE cubicle_number = @cubiclenumber ORDER BY timestamp DESC LIMIT 1;";

                MySqlCommand command = new MySqlCommand(query, mysqlCon);
                command.Parameters.AddWithValue("@cubiclenumber", x);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    z = reader.GetInt32(2).ToString();
                }

                switch (x)
                {
                    case 1:
                        cubicleNum1.Text = z;
                        break;
                    case 2:
                        cubicleNum2.Text = z;
                        break;
                    case 3:
                        cubicleNum3.Text = z;
                        break;
                    case 4:
                        cubicleNum4.Text = z;
                        break;
                    default:
                        break;
                }

            }
               

        }
    }
}
