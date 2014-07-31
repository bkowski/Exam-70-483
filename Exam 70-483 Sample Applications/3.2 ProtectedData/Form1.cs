using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security.Cryptography;

namespace _3._2_ProtectedData
{
    public partial class Form1 : Form
    {
        private byte[] encryptedData;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            // check textbox is not empty
            if(string.IsNullOrEmpty(txtEncrypt.Text))
            {
                MessageBox.Show("Please enter some text to encrypt!");
            }
            else
            {
                // encrypt data
                byte[] data = System.Text.Encoding.Default.GetBytes(txtEncrypt.Text);
                try
                {
                    encryptedData = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
                    MessageBox.Show("Encryption Successful!");
                }
                catch(CryptographicException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            // decrypt data and display in label
            lblDecrypt.Text = System.Text.Encoding.Default.GetString(ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.CurrentUser));
        }

    }
}
