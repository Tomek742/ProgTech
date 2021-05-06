using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
