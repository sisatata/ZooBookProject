using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZooBook.Application.Commands;
using ZooBook.Core.Interface;
using ZooBook.Data.Repository;
using ZooBook.Domain.Interface;
using ZooBook.Domain.Models;

namespace ZooBook.Application.CommandHandlers
{
   public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CommonResponseDto>
    {
        #region properties
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _autoMapper;
        #endregion

        #region ctor
        public CreateEmployeeCommandHandler(IEmployeeRepository repository, IMapper autoMapper)
        {
            _repository = repository;
            _autoMapper = autoMapper;
           

        }
        #endregion

        #region method

        public async Task<CommonResponseDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var commonResponseDto = new CommonResponseDto
            {
                Status = false,
                Message = "Failed"
            };
            try
            {
               
                var employee = _autoMapper.Map<Employee>(request);
                var result = await _repository.AddAsync(employee);
                commonResponseDto.ApplicationId = result.Id;
                commonResponseDto.Status = true;
               
                commonResponseDto.Message = "Entity Successfully Created";
                return commonResponseDto;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.ToString());
            }
        }
        #endregion
    }
}
