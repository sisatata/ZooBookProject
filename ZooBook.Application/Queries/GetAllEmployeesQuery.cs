using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ZooBook.Application.Queries.Models;

namespace ZooBook.Application.Queries
{
  public  class GetAllEmployeesQuery : IRequest<IList<EmployeeDto>>
    {
    }
}
