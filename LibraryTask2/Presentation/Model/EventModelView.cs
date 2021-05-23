using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;
using Presentation.API;

namespace Presentation.Model
{
    public class EventModelView : IEventModelView
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
