using System;

namespace Data
{
    public class Event : IEvent
    {
        public IBook BookItem { get; set; }
        public IReader ReaderPerson { get; set; }
        public DateTime Date { get; set; }
        public int EventID { get; set; }

        public Event(IBook bookItem, IReader readerPerson, DateTime date, int eventID)
        {
            BookItem = bookItem;
            ReaderPerson = readerPerson;
            Date = date;
            EventID = eventID;
        }
    }
}
