using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;
using Presentation.API;

namespace Presentation.Model
{
    public class ReaderModelView : IReaderModelView
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
