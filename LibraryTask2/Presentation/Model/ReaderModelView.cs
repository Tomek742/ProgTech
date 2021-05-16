using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace Presentation.Model
{
    public class ReaderModelView : IReader
    {
        public string Name { get; set; }
        public int ReaderID { get; set; }

        public ReaderModelView(string name, int readerID)
        {
            Name = name;
            ReaderID = readerID;
        }
    }
}
