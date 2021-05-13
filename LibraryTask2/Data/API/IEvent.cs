using System;

namespace Data
{
    public interface IEvent
    {
        IBook BookItem { get; set; }
        IReader ReaderPerson { get; set; }
        DateTime Date { get; set; }
        int EventID { get; set; }
    }
}
