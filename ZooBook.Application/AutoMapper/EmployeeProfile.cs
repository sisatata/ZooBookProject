using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ZooBook.Application.Commands;
using ZooBook.Domain.Models;

namespace ZooBook.Application.AutoMapper
{
    internal class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateEmployeeCommand, Employee>().ReverseMap();
            CreateMap<UpdateEmployeeCommand, Employee>().ReverseMap();
        }
    }
}
