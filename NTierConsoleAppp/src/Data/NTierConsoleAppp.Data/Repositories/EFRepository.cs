using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierConsoleAppp.Data.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        public void GetAll()
        {
            throw new NotImplementedException();
        }
        public void Add(T item)
        {
            throw new NotImplementedException();
        }
        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }


    }
}
