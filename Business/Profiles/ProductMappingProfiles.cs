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
    public class ProductMappingProfiles : Profile
    {
        public ProductMappingProfiles()
        {            
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, CreatedProductResponse>();
            //GetListResponse İçin
            CreateMap<IPaginate<Product>, GetListResponse>();
            CreateMap<Product, ProductListDto>();


        }
    }
}
