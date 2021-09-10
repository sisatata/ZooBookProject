using System;
using System.Collections.Generic;
using System.Text;
using ZooBook.Data.Context;
using ZooBook.Domain.Interface;

namespace ZooBook.Data.Repository
{
  public  class EmployeeRepository : EfRepository<Domain.Models.Employee, Guid>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeRecordsDbContext DBContext) : base(DBContext)
        { }

    }
}
