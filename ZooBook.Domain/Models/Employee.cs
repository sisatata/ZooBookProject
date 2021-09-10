using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ZooBook.Shared;

namespace ZooBook.Domain.Models
{
  public  class Employee : BaseEntity<Guid>
    {
        [Required]
        [StringLength(50, MinimumLength =5)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string LastName { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
