using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZooBook.Application.AutoMapper
{
  public  class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
            });
        }
    }
}
