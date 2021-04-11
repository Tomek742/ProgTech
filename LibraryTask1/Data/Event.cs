using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Event
    {
        public Book BookItem { get; set; }
        public Reader ReaderPerson { get; set; }
        public DateTime Date { get; set; }
        public int EventID { get; set; }

        public Event(Book bookItem, Reader readerPerson, DateTime date, int eventID)
        {
            BookItem = bookItem;
            ReaderPerson = readerPerson;
            Date = date;
            EventID = eventID;
        }
    }
}
