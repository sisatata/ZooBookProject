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
using ZooBook.Domain.Models;

namespace ZooBook.Application.QueryHandlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IList<EmployeeDto>>
    {
        #region propeties
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _autoMapper;

        #endregion

        #region ctor
        public GetAllEmployeesQueryHandler(IEmployeeRepository repository, IMapper autoMapper)
        {
            _repository = repository;
            _autoMapper = autoMapper;
        }
        #endregion

        #region method
        public async Task<IList<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                IList<Employee> types = await _repository.GetAll();
                IList<EmployeeDto> data = _autoMapper.Map<List<EmployeeDto>>(types);
                return data;
            }
            catch( Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
