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
    class ReaderService : IReaderService
    {
        private IDataManager manager;
        public ReaderService(IDataManager manager)
        {
            this.manager = manager;
        }
        public ReaderService()
        {
            this.manager = new DataManager();
        }
        public IEnumerable<IReader> GetReaders()
        {
            return manager.GetReaders();
        }

        public IReader GetReader(int ID)
        {
            return manager.GetReader(ID);
        }

        public bool AddReader(int ID, string Name)
        {
            return manager.AddReader(ID, Name);
        }

        public bool UpdateReader(int ID, string Name)
        {
            return manager.UpdateReader(ID, Name);
        }

        public bool DeleteReader(int ID)
        {
            return manager.DeleteReader(ID);
        }
    }
}
