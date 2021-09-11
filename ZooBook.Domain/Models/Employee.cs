using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ZooBook.Shared;

namespace ZooBook.Domain.Models
{
  public  class Employee : BaseEntity<Guid>
    {
        [Required(ErrorMessage = "First Name name is required")]
        [StringLength(50, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength =5)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Middle Name name is required")]
        [StringLength(50, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 5)]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name name is required")]
        [StringLength(50, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 5)]
        public string LastName { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
