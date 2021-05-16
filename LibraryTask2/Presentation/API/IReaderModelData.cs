using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Service.API;

namespace Presentation.API
{
    interface IReaderModelData
    {
        IReaderService Service { get; }
        IEnumerable<IReader> Reader { get; }
        IReader CreateReader(string Name, int ID);
    }
}
