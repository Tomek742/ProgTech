using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Service.API;

namespace Service.DataFiles
{
    class ReaderService : IReaderService
    {
        public IEnumerable<Reader> GetReaders()
        {
            using (var context = new LibraryDataContext())
            {
                return context.Readers.ToList();
            }
        }

        public Reader GetReader(int ID)
        {
            using (var context = new LibraryDataContext())
            {
                foreach (Reader Reader in context.Readers.ToList())
                {
                    if (Reader.id.Equals(ID))
                    {
                        return Reader;
                    }
                }
                return null;
            }
        }

        public bool AddReader(int ID, string Name)
        {
            using (var context = new LibraryDataContext())
            {
                if (GetReader(ID) == null && !Name.Equals(null))
                {
                    Reader NewReader = new Reader
                    {
                        id = ID,
                        name = Name
                    };
                    context.Readers.InsertOnSubmit(NewReader);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public bool UpdateReader(int ID, string Name)
        {
            using (var context = new LibraryDataContext())
            {
                Reader Reader = context.Readers.SingleOrDefault(i => i.id == ID);
                if (GetReader(ID) == null && !Name.Equals(null))
                {
                    Reader.id = ID;
                    Reader.name = Name;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public bool DeleteReader(int ID)
        {
            using (var context = new LibraryDataContext())
            {
                Reader Reader = context.Readers.SingleOrDefault(i => i.id == ID);
                if (GetReader(ID) != null)
                {
                    context.Readers.DeleteOnSubmit(Reader);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
