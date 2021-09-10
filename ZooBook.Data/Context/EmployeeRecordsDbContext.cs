using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ZooBook.Domain.Models;

namespace ZooBook.Data.Context
{
   public class EmployeeRecordsDbContext : DbContext
    {
        public EmployeeRecordsDbContext(DbContextOptions<EmployeeRecordsDbContext> options) : base(options)
        {
            
        }
      public  DbSet<Employee> Employees { get; set; }
    }
}
