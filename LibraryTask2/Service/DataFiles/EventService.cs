using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataFiles;
using Data.API;
using Service.API;

namespace Service.DataFiles
{
    class EventService : IEventService
    {
        private IDataManager manager;
        public EventService(IDataManager manager)
        {
            this.manager = manager;
        }
        public EventService()
        {
            this.manager = new DataManager();
        }
        public IEnumerable<IEvent> GetEvents()
        {
            return manager.GetEvents();
        }

        public IEvent GetEventByID(int ID)
        {
            return manager.GetEventByID(ID);
        }

        public IEnumerable<IEvent> GetEventsByReaderID(int ID)
        {
            return manager.GetEventsByReaderID(ID);
        }

        public bool AddEvent(int EventID, DateTime Date, int BookID, int ReaderID)
        {
            return manager.AddEvent(EventID, Date, BookID, ReaderID);
        }

        public bool UpdateEventBook(int ID, int BookID)
        {
            return manager.UpdateEventBook(ID, BookID);
        }

        public bool UpdateEventReader(int ID, int ReaderID)
        {
            return manager.UpdateEventReader(ID, ReaderID);
        }

        public bool DeleteEvent(int ID)
        {
            return manager.DeleteEvent(ID);
        }
    }
}
