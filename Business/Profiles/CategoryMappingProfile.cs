using AutoMapper;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<Category, CreatedCategoryResponse>();
        }
    }
}
