using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;

namespace QueueServer
{
    public partial class QueueServerWithDesign : Form
    {
        Color maincolor = Color.FromArgb(143, 180, 239);
        Color secondarycolor = Color.FromArgb(255, 255, 255);
        Color blinker = Color.FromArgb(245, 0, 0);
        Color black = Color.Black;
        private static int x;
        private static String y;
        private static ArrayList l = new ArrayList();


        public QueueServerWithDesign()
        {
            InitializeComponent();           
            tableLayoutPanel1.BackColor = maincolor;
            InitTimer();
        }

        /*private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            
            
            var brush = new SolidBrush(myrgbColor);
            if (e.Row == 0 && e.Column == 0)
            {
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
            if (e.Row == 2 && e.Column == 0)
            {
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
        }*/

        private void tableLayoutPanel2_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            var brush = new SolidBrush(secondarycolor);
            if (e.Row == 0 && e.Column == 1)
            {
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
            if (e.Row == 0 && e.Column == 0)
            {
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
        }

        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MySqlConnection mysqlCon = new MySqlConnection(@"Server=localhost;Database=osa_queuing;Uid=root;Pwd=;");

            try
            {
                mysqlCon.Open();
                l = QueueDB.gatherData(mysqlCon);
                string sr = DateTime.Now.ToString("h:mm tt yyyy-MM-dd");
                DateLabel.Text = sr;
                foreach (QueueStat c in l)
                {
                    x = c.getCubicleNumber();
                    y = c.getServingNumber().ToString();
                }
                checkLastNumbers();
                servingNumber.ForeColor = servingNumber.ForeColor == Color.White ? blinker : Color.White; 
                cubicleNumber.Text = "Cubicle " + x.ToString();
                servingNumber.Text = y;
                mysqlCon.Close();
            }
            catch (Exception ex)
            {
                timer1.Stop();
                MessageBox.Show("The connection to the database server has either terminated abruptly or it doesn't exist.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void checkLastNumbers()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(@"Server=localhost;Database=osa_queuing;Uid=root;Pwd=;"))
            {
                for(int i = 1; i <= 4; i++)
                {
                    String z = "0";
                    mysqlCon.Open();
                    MySqlDataReader reader = null;
                    string query = "SELECT * FROM osa_queuing.queue_stat WHERE cubicle_number = @cubiclenumber AND date(timestamp) = date(now()) ORDER BY timestamp DESC LIMIT 1;";

                    MySqlCommand command = new MySqlCommand(query, mysqlCon);
                    command.Parameters.AddWithValue("@cubiclenumber", i);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        z = reader.GetInt32(2).ToString();
                    }

                    switch (i)
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
                    mysqlCon.Close();
                }
                

            }
        }
    }
}
