using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZooBook.Application.Commands
{
  public  class DeleteEmployeeCommand :  IRequest<CommonResponseDto>
    {
        public Guid Id { get; set; }
    }
}
