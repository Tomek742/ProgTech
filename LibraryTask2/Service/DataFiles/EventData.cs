using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;

namespace Service.DataFiles
{
    public class EventData : IEventData
    {
        public int EventID { get; set; }
        public DateTime? Date { get; set; }
        public int? BookID { get; set; }
        public int? ReaderID { get; set; }
    }
}
