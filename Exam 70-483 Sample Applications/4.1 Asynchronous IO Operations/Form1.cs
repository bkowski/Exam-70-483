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
using System.IO;

namespace _4._1_Asynchronous_IO_Operations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.Text = "Searching...";
            string outputFileName = @"C:\Users\Public\FoundFiles.txt";

            await SearchDirectoryAsync(@"C:\Users\Carolyn", "abc", outputFileName);

            this.Text = "Finished";

            Process.Start(outputFileName);
        }

        private static async Task SearchDirectoryAsync(string searchPath, string searchString, string outputFileName)
        {
            StreamWriter sw = File.CreateText(outputFileName);

            string[] fileNames = Directory.GetFiles(searchPath);
            await FindTextInFilesAsync(fileNames, searchString, sw);

            sw.Close();
        }

        private static async Task FindTextInFilesAsync(string[] fileNames, string searchString, StreamWriter outputFile)
        {
            foreach(string fileName in fileNames)
            {
                if(fileName.ToLower().EndsWith(".txt"))
                {
                    StreamReader streamReader = new StreamReader(fileName);

                    string textOfFile = await streamReader.ReadToEndAsync();
                    streamReader.Close();

                    if(textOfFile.Contains(searchString))
                    {
                        await outputFile.WriteLineAsync(fileName);
                    }
                }
            }
        }
    }
}
