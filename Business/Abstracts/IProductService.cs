using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Paging;
using Core.Persistence.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IProductService
    {
        //Task<IPaginate<Product>> GetListAsync();
        Task<IPaginate<GetListProductResponse>> GetListAsync(PageRequest pageRequest);
        //Task<IPaginate<GetListProductResponse>> GetListAsync(GetListProductResponse getProductResponse);
        Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest);
        

    }
}
