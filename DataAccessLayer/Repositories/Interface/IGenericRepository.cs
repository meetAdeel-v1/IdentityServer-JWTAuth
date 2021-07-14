using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interface
{
    public interface IGenericRepository<T>
    {
        Task<T> Get(T dataObj);

        Task<T> GetAll(T dataObj);

        Task<T> Add(T dataObj);

        Task<T> Update(T dataObj);

        Task<T> Delete(T dataObj);
    }
}
