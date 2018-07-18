﻿using System;
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

        static MySqlConnection mysqlCon = new MySqlConnection(@"Server=localhost;Database=osa_queuing;Uid=root;Pwd=;");

        public static void setCon()
        {
            try
            {
                mysqlCon.Open();
            }
            catch (Exception e)
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
            string query = "SELECT * FROM osa_queuing.queue_stat ORDER BY timestamp DESC Limit 1";

            MySqlCommand command = new MySqlCommand(query, mysqlCon);


            reader = command.ExecuteReader();
            while (reader.Read())
            {
                QueueStat t = new QueueStat(reader.GetInt32(1), reader.GetInt32(2));
                queue.Add(t);
            }
            mysqlCon.Close();
            return queue;
        }

        public static void addQueue(QueueStat rs)
        {
            using (MySqlConnection secondCon = new MySqlConnection(@"Server=localhost;Database=osa_queuing;Uid=root;Pwd=;"))
            {
                secondCon.Open();
                String sql = "INSERT INTO queue_stat(cubicle_number, serving_number, timestamp) VALUES (@cubicle,@serving,@timestamp)";
                MySqlCommand cmd = new MySqlCommand(sql, secondCon);
                cmd.Parameters.AddWithValue("@cubicle", rs.getCubicleNumber());
                cmd.Parameters.AddWithValue("@serving", rs.getServingNumber());
                cmd.Parameters.AddWithValue("@timeStamp", rs.getTimeStamp());
                cmd.ExecuteNonQuery();
            }
        }

        public static String getLastServed(String cubicleID)
        {
            using (MySqlConnection secondCon = new MySqlConnection(@"Server=localhost;Database=osa_queuing;Uid=root;Pwd=;"))
            {
                int tr = 0;
                secondCon.Open();
                MySqlDataReader reader = null;
                String query = "SELECT * FROM osa_queuing.queue_stat WHERE cubicle_number = @cubicleID ORDER BY timestamp DESC Limit 1;";
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
                
        }
    }
}
