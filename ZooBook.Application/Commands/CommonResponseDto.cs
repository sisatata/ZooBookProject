using System;
using System.Collections.Generic;
using System.Text;

namespace ZooBook.Application.Commands
{
  public  class CommonResponseDto
    {
        public Guid ApplicationId { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
