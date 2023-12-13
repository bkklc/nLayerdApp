using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.DTOs.Responses;
using Core.DataAccess.Paging;
using Core.Persistence.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<CreateCustomerRequest, Customer>();
        CreateMap<Customer, CreatedCustomerResponse>();


        CreateMap<Customer, GetListCustomerResponse>().ReverseMap();
        CreateMap<Paginate<Customer>, Paginate<GetListCustomerResponse>>();

        CreateMap<UpdateCustomerRequest, Customer>().ForMember(dest => dest.CreatedDate, opt => opt.Ignore());
        CreateMap<Customer, UpdatedCustomerResponse>();
    }
}