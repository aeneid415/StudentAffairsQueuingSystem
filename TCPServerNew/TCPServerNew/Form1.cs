using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Media;


namespace TCPServerNew
{
    public partial class Form1 : Form
    {
        TcpListener serverSocket = new TcpListener(IPAddress.Any, 8888);
        TcpClient clientSocket = default(TcpClient);
        List<TcpClient> listOfClients = new List<TcpClient>();

        public Form1()
        {
            InitializeComponent();
            

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            serverSocket.Start();
            label1.Text = "Server Started";   
            /*
            Console.WriteLine(" >> " + "exit");
            Console.ReadLine();
            */
            
        }





        private void button1_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(connectionsCount.Text);
            while (true)
            {
                //String number = "";
                if (serverSocket.Pending())
                {

                    clientSocket = serverSocket.AcceptTcpClient();
                    listOfClients.Add(clientSocket);

                    /*
                    label6.Text = "Pending Connections";
                    number = listOfClients.Count().ToString();


                    label7.Text = "Number of Conn. Clients: " + number;

                    //handleClinet client = new handleClinet();

                    //client.startClient(clientSocket, Convert.ToString(counter));
                    */

                    
                }
                else
                {
                    /*
                    label6.Text = "No pending connections";
                    number = listOfClients.Count().ToString();
                    label7.Text = "Number of Conn. Clients: " + number;
                    */
                }

                if (listOfClients.Count() == count)
                {
                    acceptConn.Visible = false;
                    label7.Visible = false;
                    connectionsCount.Visible = false;
                    startClient(clientSocket);
                    break;
                }
            }
           

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                clientSocket.Close();
                serverSocket.Stop();
                System.Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(0);
            }
            
        }

        public void startClient(TcpClient inClientSocket)
        {
            //this.clientSocket = inClientSocket;
            //this.clNo = clineNo;
            Thread ctThread = new Thread(doChat);
            ctThread.Start();
        }

        delegate void SetTextCallback(string text);
        delegate void SetServingCallback(string text);

        private void SetText(string text)
        {
            if (this.cubicleNumber.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.cubicleNumber.Text = text;
            }
        }

        private void SetServingText(String text)
        {
            int a = Convert.ToInt32(servingNumber.Text);
            int b = Convert.ToInt32(text);
            if (b != 0)
            {
                int c = a + b;
                String newtext = Convert.ToString(c);
                while (true)
                {

                    if (this.servingNumber.InvokeRequired)
                    {

                        SetServingCallback d = new SetServingCallback(SetServingText);
                        this.Invoke(d, new object[] { text });
                        return;
                    }
                    else
                    {
                        if (a == 100)
                        {
                            this.servingNumber.Text = "1";
                            break;
                        }
                        else
                        {
                            this.servingNumber.Text = newtext;
                            break;
                        }


                    }
                }
            }
            else
            {
                if (this.servingNumber.InvokeRequired)
                {
                    SetServingCallback d = new SetServingCallback(SetServingText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.servingNumber.Text = text;
                }
            }
        }

        private void doChat()
        {
            //int requestCount = 0;
            byte[] bytesFrom = new byte[10025];
            string dataFromClient = null;
            //Byte[] sendBytes = null;
            //string serverResponse = null;
            //string rCount = null;
            //requestCount = 0;

            while ((true))
            {
                try
                {

                    if (serverSocket.Pending())
                    {

                        clientSocket = serverSocket.AcceptTcpClient();
                        listOfClients.Add(clientSocket);
                    }
                    //requestCount = requestCount + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, 1);
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    
                    String newdataFromClient = dataFromClient.Substring(0, 1);
                    playaudio();
                    //Console.WriteLine(" >> " + "From client-" + clNo + dataFromClient);
                    if (newdataFromClient.Equals("0"))
                    {
                        //cubicleNumber.Text = "0";
                        //servingNumber.Text = "0";
                        SetServingText("0");
                    }
                    else
                    {

                        SetText(newdataFromClient);
                        SetServingText("1");
                        //cubicleNumber.Text = newdataFromClient;
                        //servingNumber.Text = servingNumber.Text + 1;
                        
                    }
                    
                    


                    /*rCount = Convert.ToString(requestCount);
                    //serverResponse = "Server to clinet(" + clNo + ") " + rCount;
                    sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();
                    Console.WriteLine(" >> " + serverResponse);
                    */
                }

                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show("Please close the server before closing any of the clients.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Application.Exit();
                    continue;
                }

            }

        }

        private void servingNumber_Click(object sender, EventArgs e)
        {

        }

        private void playaudio() // defining the function
        {
            SoundPlayer audio = new SoundPlayer(TCPServerNew.Properties.Resources.ElectronicChime); // here WindowsFormsApplication1 is the namespace and Connect is the audio file name
            audio.Play();
        }

        private void cubicleNumber_Click(object sender, EventArgs e)
        {

        }
    }

    /*
    public class handleClinet
    {
        TcpClient clientSocket;
        string clNo;
        public void startClient(TcpClient inClientSocket, string clineNo)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
            Thread ctThread = new Thread(doChat);
            ctThread.Start();
        }

        
        private IPAddress getLocalIPAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return null;
            }

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host
                .AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }
        

        private void doChat()
        {
            //int requestCount = 0;
            byte[] bytesFrom = new byte[10025];
            string dataFromClient = null;
            Byte[] sendBytes = null;
            string serverResponse = null;
            string rCount = null;
            //requestCount = 0;

            while ((true))
            {
                try
                {
                    //requestCount = requestCount + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    //dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    //Console.WriteLine(" >> " + "From client-" + clNo + dataFromClient);


                    //rCount = Convert.ToString(requestCount);
                    serverResponse = "Server to clinet(" + clNo + ") " + rCount;
                    sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();
                    Console.WriteLine(" >> " + serverResponse);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(" >> " + ex.ToString() + " " + (int)clientSocket.ReceiveBufferSize);
                    break;
                }

            }

        }
       

    }
    */
}
