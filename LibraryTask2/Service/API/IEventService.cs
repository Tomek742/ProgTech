using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;

namespace Service.API
{
    interface IEventService
    {
        IEnumerable<Event> GetEvents();
        Event GetEventById(int ID);
        bool AddEvent(DateTime date, int ID, int BookID, int ReaderID);
        bool UpdateEvent(int ID, int ReaderID);
        bool DeleteEvent(int ID);
    }
}
