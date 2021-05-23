using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IEnumerable<IReaderData> Reader
        {
            get
            {
                IEnumerable<IReaderData> readers = Service.GetReaders();
                return readers;
            }
        }

        public IReaderModelView CreateReader(string Name, int ID)
        {
            return new ReaderModelView(Name, ID);
        }
    }
}
