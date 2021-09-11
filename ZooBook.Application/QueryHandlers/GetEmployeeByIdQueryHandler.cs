using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZooBook.Application.Queries;
using ZooBook.Application.Queries.Models;
using ZooBook.Domain.Interface;

namespace ZooBook.Application.QueryHandlers
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        #region properties
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _autoMapper;
        #endregion

        #region ctor
        public GetEmployeeByIdQueryHandler(IEmployeeRepository repository, IMapper autoMapper)
        {
            _repository = repository;
            _autoMapper = autoMapper;
        }
        #endregion

        #region method
        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _repository.GetByIdAsync(request.Id);
                return _autoMapper.Map<EmployeeDto>(employee);
            }
            catch( Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
