using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;

namespace Service.DataFiles
{
    public class ReaderData : IReaderData
    {
        public string Name { get; set; }
        public int ReaderID { get; set; }
    }
}
