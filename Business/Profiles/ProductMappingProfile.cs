using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Entities.Concretes;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Persistence.Paging;


namespace Business.DTOs.Profiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, CreatedProductResponse>();
            //CreateMap<Product, GetListProductResponse>();

            //CreateMap<IPaginate<Product>, GetListProductResponse>();
            //CreateMap<Product, ProductListDto>();

            CreateMap<Product, GetListProductResponse>()
                .ForMember(destinationMember: p => p.CategoryName,
                    memberOptions: opt => opt.MapFrom(p => p.Category.Name)).ReverseMap();
            CreateMap<Paginate<Product>, Paginate<GetListProductResponse>>().ReverseMap();          

            
            

        }
    }
}
