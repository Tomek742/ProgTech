﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.API
{
    public interface IReaderModelView
    {
        string Name { get; set; }
        int ReaderID { get; set; }
    }
}
