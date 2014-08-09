using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2._6_IDisposable
{
    class OpenFile : IDisposable
    {
        public FileStream stream { get; private set; }

        // constructor
        public OpenFile(string path)
        {
            this.stream = File.Open(path, FileMode.Open);
        }

        // destructor
        ~OpenFile()
        {
            Dispose(false);
        }

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(stream != null)
                {
                    stream.Close();
                }
            }
        }
    }
}
