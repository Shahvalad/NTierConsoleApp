using NTierConsoleAppp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierConsoleAppp.Data.Repositories
{
    internal interface IProductRepository<T> : IRepository<T> where T : Product 
    {

    }
}
