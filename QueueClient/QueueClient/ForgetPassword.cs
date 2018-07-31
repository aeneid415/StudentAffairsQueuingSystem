using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueueClient
{
    public partial class ForgetPassword : Form
    {
        public ForgetPassword()
        {
            InitializeComponent();
            this.ControlBox = false;
            if(Emp.IPAddress == null)
            {
                IPLabel.Visible = true;
                Txt_ServerIP.Visible = true;
            }
            else
            {
                Txt_ServerIP.Text = Emp.IPAddress;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
