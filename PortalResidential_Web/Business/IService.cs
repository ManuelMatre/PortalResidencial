﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalResidential_Web.Business
{
    internal interface IService<T>
    {
        bool Save(T obj);
        bool Delete(T obj);
    }
}
