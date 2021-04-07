using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTask1.DataLayer
{
    class Reader
    {
        public string Name { get; set; }
        public int ReaderID { get; set; }

        public Reader(string name, int readerID)
        {
            Name = name;
            ReaderID = readerID;
        }
    }
}
