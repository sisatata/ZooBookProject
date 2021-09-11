using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZooBook.Application.Commands;
using ZooBook.Domain.Interface;
using ZooBook.Domain.Models;

namespace ZooBook.Application.CommandHandlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, CommonResponseDto>
    {
        #region properties
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _autoMapper;
        #endregion

        #region ctor
        public UpdateEmployeeCommandHandler(IEmployeeRepository repository, IMapper autoMapper)
        {
            _repository = repository;
            _autoMapper = autoMapper;

        }

        #endregion

        #region method
        public async Task<CommonResponseDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new CommonResponseDto
            {
                Message = "Employee can't be Updated",
                Status = false
            };
            try
            {
                var employee = await _repository.GetByIdAsync(request.Id);
                employee.FirstName = request.FirstName;
                employee.LastName = request.LastName;
                employee.MiddleName = request.MiddleName;
                await _repository.UpdateAsync(employee);
                response.Status = true;
                response.ApplicationId = request.Id;
                response.Message = "employee successfully Updated";
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
