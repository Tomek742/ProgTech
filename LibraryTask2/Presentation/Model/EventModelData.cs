using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Service.API;
using Presentation.API;

namespace Presentation.Model
{
    public class EventModelData : IEventModelData
    {
        public IEventService Service { get; }
        public EventModelData(IEventService service)
        {
            Service = service;
        }

        public IEnumerable<IEvent> Event
        {
            get
            {
                IEnumerable<IEvent> events = Service.GetEvents();
                return events;
            }
        }

        public IEvent CreateEvent(int ID, DateTime Date, int BookID, int ReaderID)
        {
            return new EventModelView(ID, Date, BookID, ReaderID);
        }
    }
}
