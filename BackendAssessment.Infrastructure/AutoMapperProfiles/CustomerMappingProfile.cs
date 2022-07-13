using AutoMapper;
using BackendAssessment.Infrastructure.DTOs.Requests;
using BackendAssessment.Infrastructure.DTOs.Responses;
using BackendAssessment.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessment.Infrastructure.AutoMapper
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerRegRequestDTO>().ReverseMap();

            CreateMap<Customer, CustomerRegReponseDTO>().ReverseMap();

            CreateMap<Customer, BoardedResponse>().ReverseMap();

        }
    }
}
