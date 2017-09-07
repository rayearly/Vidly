using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Dto;
using Vidly.Models;

// class loaded when application started by adding a line of initialization in Global.asax
namespace Vidly.App_Start
{
    // Derive class from Profile in AutoMapper namespace
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Create a mapping configuration between two types - Do it vice versa
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}