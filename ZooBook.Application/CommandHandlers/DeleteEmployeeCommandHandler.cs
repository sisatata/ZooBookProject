using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZooBook.Application.Commands;
using ZooBook.Core.Interface;
using ZooBook.Domain.Interface;

namespace ZooBook.Application.CommandHandlers
{
    class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, CommonResponseDto>
    {
        private readonly IEmployeeRepository _repository;
       
        public DeleteEmployeeCommandHandler(IEmployeeRepository repository)
        {
            _repository = repository;
           
        }

        public async Task<CommonResponseDto> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new CommonResponseDto
            {
                Message = "Employee can't be deleted",
                Status = false
            };
            try
            {
                var employee = await _repository.GetByIdAsync(request.Id);
                employee.IsDeleted = true;
                await _repository.UpdateAsync(employee);
                response.Status = true;
                response.ApplicationId = request.Id;
                response.Message = "Employee successfully Deleted";
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

