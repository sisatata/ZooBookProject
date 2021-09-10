using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBook.Core.Interface;
using ZooBook.Data.Context;
using ZooBook.Shared;

namespace ZooBook.Data.Repository
{
   public class EfRepository<T, TId> : IAsyncRepository<T, TId> where T : BaseEntity<TId>
    {
          protected readonly EmployeeRecordsDbContext _employeeRecordsDbContext;
        public EfRepository(EmployeeRecordsDbContext employeeRecordsDbContext)
        {
            _employeeRecordsDbContext = employeeRecordsDbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _employeeRecordsDbContext.Set<T>().AddAsync(entity);
           // await _employeeRecordsDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _employeeRecordsDbContext.Set<T>().Remove(entity);
          //  await _employeeRecordsDbContext.SaveChangesAsync();
        }
        public async Task<T> GetByIdAsync(TId id)
        {
            return await _employeeRecordsDbContext.Set<T>().FindAsync(id);
        }
        public async Task<IList<T>> GetAll()
        {
            return await _employeeRecordsDbContext.Set<T>().AsNoTracking().Where(x => x.IsDeleted != false).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {

            await _employeeRecordsDbContext.SaveChangesAsync();
        }
    }
}
