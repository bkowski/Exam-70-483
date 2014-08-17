using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._4_Contravariance
{
    public partial class Form1 : Form
    {
        // event handler
        private void MultiHandler(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }
        public Form1()
        {
            InitializeComponent();

            this.button1.KeyDown += this.MultiHandler;

            this.button1.Click += this.MultiHandler;
        }
    }
}
