using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;

namespace Presentation.API
{
    interface IEventModelData
    {
        IEventService Service { get; }
        IEnumerable<IEventData> Event { get; }
        IEventModelView CreateEvent(int ID, DateTime Date, int BookID, int ReaderID);
    }
}
