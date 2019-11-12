using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multicast
{
    public partial class Form1 : Form
    {
        Socket soc = null;
        public Form1()
        {
            InitializeComponent();

            soc = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("224.5.5.5"), 1024);
            soc.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 2);
            soc.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(IPAddress.Parse("224.5.5.5")));
            soc.Connect(ipep);

            textBox1.TextChanged += TextBox1_TextChanged;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string msg = textBox1.Text;
            soc.Send(Encoding.Default.GetBytes(msg));
        }
    }
}
