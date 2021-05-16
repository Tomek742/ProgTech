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
    public class ReaderModelData : IReaderModelData
    {
        public IReaderService Service { get; }
        public ReaderModelData(IReaderService service)
        {
            Service = service;
        }

        public IEnumerable<IReader> Reader
        {
            get
            {
                IEnumerable<IReader> readers = Service.GetReaders();
                return readers;
            }
        }

        public IReader CreateReader(string Name, int ID)
        {
            return new ReaderModelView(Name, ID);
        }
    }
}
