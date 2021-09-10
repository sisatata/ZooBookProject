using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ZooBook.Domain.Models;

namespace ZooBook.Application.Commands
{
    [AutoMap(typeof(Employee))]
  public  class CreateEmployeeCommand : IRequest<CommonResponseDto>
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string LastName { get; set; }
    }
}
