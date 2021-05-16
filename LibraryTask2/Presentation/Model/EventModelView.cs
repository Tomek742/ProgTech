using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace Presentation.Model
{
    public class EventModelView : IEvent
    {
        public int EventID { get; set; }
        public DateTime? Date { get; set; }
        public int? BookID { get; set; }
        public int? ReaderID { get; set; }

        public EventModelView(int eventID, DateTime? date, int? bookID, int? readerID)
        {
            EventID = eventID;
            Date = date;
            BookID = bookID;
            ReaderID = readerID;
        }
    }
}
