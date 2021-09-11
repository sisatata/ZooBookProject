using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ZooBook.Domain.Models;

namespace ZooBook.Application.Queries.Models
{
    [AutoMap(typeof(Employee))]
    public class EmployeeDto 
    {
      
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
