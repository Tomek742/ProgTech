using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Service.API;

namespace Presentation.API
{
    interface IEventModelData
    {
        IEventService Service { get; }
        IEnumerable<IEvent> Event { get; }
        IEvent CreateEvent(int ID, DateTime Date, int BookID, int ReaderID);
    }
}
