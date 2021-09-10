using System;
using System.Collections.Generic;
using System.Text;
using ZooBook.Core.Interface;
using ZooBook.Domain.Models;

namespace ZooBook.Domain.Interface
{
   public interface IEmployeeRepository : IAsyncRepository<Employee, Guid>
    {
    }
}
