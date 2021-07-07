using DataAccessLayer.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        public GenericRepository()
        {

        }

        public async Task<T> Get(T dataObj)
        {
            return dataObj;
        }
        public async Task<T> GetAll(T dataObj)
        {
            return dataObj;
        }
        public async Task<T> Add(T dataObj)
        {
            return dataObj;
        }

        public async Task<T> Update(T dataObj)
        {
            return dataObj;
        }

        public async Task<T> Delete(T dataObj)
        {
            return dataObj;
        }
    }
}
