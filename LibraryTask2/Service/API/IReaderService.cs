using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;

namespace Service.API
{
    interface IReaderService
    {
        IEnumerable<Reader> GetReaders();
        Reader GetReader(int ID);
        bool AddReader(int ID, string Name);
        bool UpdateReader(int ID, string Name);
        bool DeleteReader(int ID);

    }
}
