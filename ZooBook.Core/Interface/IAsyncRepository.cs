using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZooBook.Shared;

namespace ZooBook.Core.Interface
{
    public interface IAsyncRepository<T, TId> where T : BaseEntity<TId>
    {
       
        Task<T> AddAsync(T entity);
        Task<T> GetByIdAsync(TId id);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IList<T>> GetAll();


       


    }
}
