using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API
{
    public interface IEventData
    {
        int EventID { get; set; }
        DateTime? Date { get; set; }
        int? BookID { get; set; }
        int? ReaderID { get; set; }
    }
}
