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
            // .ForMember(m => m.Id, opt => opt.Ignore() will ignore ID mapping during update since updating ID will throw exception
            //Mapper.CreateMap<Customer, CustomerDto>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(m => m.Id, opt => opt.Ignore());

            // Create a mapping configuration for MoviesDto to Movies object model
            //Mapper.CreateMap<Movie, MovieDto>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore()); // Dto to domain

            // Create a mapping configuration for MembershipType
            Mapper.CreateMap<MembershipType, MembershipTypeDto>(); // domain to Dto

        }
    }
}