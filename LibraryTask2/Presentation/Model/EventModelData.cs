using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IEnumerable<IEventData> Event
        {
            get
            {
                IEnumerable<IEventData> events = Service.GetEvents();
                return events;
            }
        }

        public IEventModelView CreateEvent(int ID, DateTime Date, int BookID, int ReaderID)
        {
            return new EventModelView(ID, Date, BookID, ReaderID);
        }
    }
}
