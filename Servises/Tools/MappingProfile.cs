using AutoMapper;
using DataLayer.Entities;
using Servises.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servises.Tools
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { 
            CreateMap<Customer, CustomerModel>();
            CreateMap<CustomerModel, Customer>();
            CreateMap<Nation, NationModel>();
            CreateMap<NationModel, Nation>();
        }
    }
}
