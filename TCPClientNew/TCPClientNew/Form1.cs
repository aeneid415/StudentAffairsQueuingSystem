using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text;

namespace TCPClientNew
{

    public partial class Form1 : Form
    {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        NetworkStream serverStream;
        
        public Form1()
        {
            InitializeComponent();
        }

        /*
        private void button1_Click(object sender, EventArgs e)
        {

        }
        
        public void msg(string mesg)
        {
            textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + mesg;
        }

        */
        private void Form1_Load_1(object sender, EventArgs e)
        {
            String r = "127.0.0.1";
            try
            {
                clientSocket.Connect(r, 8888);
                label1.Text = "Client Socket Program - Server Connected ...";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot connect with the server with IP Address " + r + " on port 8888. Make sure that the server is running before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            //msg("Client Started");
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(cubicleNumber.Text);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();



            /*
            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);
            msg("Data from Server : " + returndata);
            */
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (clientSocket.Connected)
            //{

                //clientSocket.GetStream().Close();
                //clientSocket.Close();
            //}

        }
    }


}

