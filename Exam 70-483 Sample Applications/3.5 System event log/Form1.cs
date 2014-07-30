using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

namespace _3._5_System_event_log
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            string source = txtSource.Text;
            string log = txtLog.Text;
            string message = txtEvent.Text;
            int id = int.Parse(txtId.Text);

            // create the source if necessary (requires admin privileges)
            if(!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, log);
            }

            // write the log entry
            EventLog.WriteEntry(source, message, EventLogEntryType.Information, id);

            MessageBox.Show("OK");
        }
    }
}
