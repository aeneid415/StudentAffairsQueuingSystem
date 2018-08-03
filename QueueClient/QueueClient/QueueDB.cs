using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;

using System.Windows.Forms;

namespace QueueClient
{
    public class QueueDB
    {
        static String ip = Emp.IPAddress;


        public static ArrayList gatherData(MySqlConnection con)
        {
            try
            {
                ArrayList queue = new ArrayList();
                MySqlDataReader reader = null;
                string query = "SELECT * FROM osa_queuing.queue_stat WHERE date(timestamp) = date(now()) AND deact_flag = 0 ORDER BY timestamp DESC Limit 1";

                MySqlCommand command = new MySqlCommand(query, con);
                

                reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    QueueStat t = new QueueStat(0, 0);
                    queue.Add(t);
                }
                else
                {
                    while (reader.Read())
                    {
                        QueueStat t = new QueueStat(reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(4));
                        queue.Add(t);
                    }

                }

                return queue;
            }catch (Exception)
            {
                MessageBox.Show("The connection to the database server has either terminated abruptly or it doesn't exist.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }
            finally
            {
                con.Close();              
            }


        }

        public static ArrayList gatherData(MySqlConnection con, String query)
        {
            try
            {
                ArrayList queue = new ArrayList();
                MySqlDataReader reader = null;

                MySqlCommand command = new MySqlCommand(query, con);


                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    QueueStat t = new QueueStat(reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(4));
                    queue.Add(t);
                }

                return queue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }
            finally
            {
                con.Close();
            }


        }

        public static void addQueue(QueueStat rs)
        {
            using (MySqlConnection secondCon = new MySqlConnection(@"Server="+ip+";Database=osa_queuing;Uid=root;Pwd=;")) { 
                try
                {
                    secondCon.Open();
                    String sql = "INSERT INTO queue_stat(cubicle_number, serving_number, timestamp) VALUES (@cubicle,@serving,@timestamp)";
                    MySqlCommand cmd = new MySqlCommand(sql, secondCon);
                    cmd.Parameters.AddWithValue("@cubicle", rs.getCubicleNumber());
                    cmd.Parameters.AddWithValue("@serving", rs.getServingNumber());
                    cmd.Parameters.AddWithValue("@timeStamp", rs.getTimeStamp());
                    cmd.ExecuteNonQuery();
                } catch (Exception)
                {
                    MessageBox.Show("Cannot insert!", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    secondCon.Close();
                }
            }
            
            
        }

        public static String getLastServed(String cubicleID, MySqlConnection secondCon)
        {
            try
            {
                int tr = 0;
                //secondCon.Open();
                MySqlDataReader reader = null;
                String query = "SELECT * FROM osa_queuing.queue_stat WHERE cubicle_number = @cubicleID AND date(timestamp) = date(now())  ORDER BY timestamp DESC Limit 1;";
                MySqlCommand cmd = new MySqlCommand(query, secondCon);
                cmd.Parameters.AddWithValue("@cubicleID", cubicleID);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tr = reader.GetInt32(2);
                }
                String serving_number = tr.ToString();
                return serving_number;
            }
            catch(Exception e)
            {
                MessageBox.Show("The connection to the database server has either terminated abruptly or it doesn't exist.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return null;
            }   
                
            
                
        }
    }
}
