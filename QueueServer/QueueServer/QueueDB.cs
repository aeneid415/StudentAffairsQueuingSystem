using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QueueServer
{
    public class QueueDB
    {
        static MySqlConnection mysqlCon = new MySqlConnection(@"Server=localhost;Database=osa_queuing;Uid=root;Pwd=;");

        public static void setCon()
        {
            try
            {
                mysqlCon.Open();
            }catch(Exception e)
            {
                MessageBox.Show("Cannot Connect to Server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void connectionClose()
        {
            mysqlCon.Close();
        }

        public static ArrayList gatherData()
        {
            ArrayList queue = new ArrayList();
            MySqlDataReader reader = null;
            string query = "SELECT * FROM osa_queuing.queue_stat WHERE date(timestamp) = date(now()) ORDER BY timestamp DESC Limit 1";

            MySqlCommand command = new MySqlCommand(query, mysqlCon);


            reader = command.ExecuteReader();
            while (reader.Read())
            {
                QueueStat t = new QueueStat(reader.GetInt32(1), reader.GetInt32(2));
                queue.Add(t);
            }
            return queue;
        }

    }
}
