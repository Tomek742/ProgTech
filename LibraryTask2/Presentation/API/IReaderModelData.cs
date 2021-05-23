using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;

namespace Presentation.API
{
    interface IReaderModelData
    {
        IReaderService Service { get; }
        IEnumerable<IReaderData> Reader { get; }
        IReaderModelView CreateReader(string Name, int ID);
    }
}
