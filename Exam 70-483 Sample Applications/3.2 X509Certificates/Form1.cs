using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security.Cryptography.X509Certificates;

namespace _3._2_X509Certificates
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            txtCertInfo.Text = string.Empty;

            X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Friendly Name \t\t\t\t Expiration Date");

            foreach(X509Certificate2 certificate in store.Certificates)
            {
                sb.AppendFormat("{0}\t{1}{2}", certificate.FriendlyName, certificate.NotAfter, Environment.NewLine);
            }
            store.Close();

            txtCertInfo.Text = sb.ToString();
        }
    }
}
