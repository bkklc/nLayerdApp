using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Paging;
using Core.Persistence.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        public async Task Add(Product product)
        {
            await _productDal.AddAsync(product);
        }

        public async Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest)
        {
            Product product =  _mapper.Map<Product>(createProductRequest) ;
            Product createdProduct = await _productDal.AddAsync(product);
            CreatedProductResponse createdProductResponse = _mapper.Map<CreatedProductResponse>(createdProduct);
            return createdProductResponse;

                    


        //Product product = new Product();
        //product.Id = Guid.NewGuid();
        //product.ProductName = createProductRequest.ProductName;
        //product.UnitPrice = createProductRequest.UnitPrice;
        //product.QuantityPerUnit = createProductRequest.QuantityPerUnit;
        //product.UnitsInStock = createProductRequest.UnitsInStock;

        //Product createdProduct = await _productDal.AddAsync(product);

        //CreatedProductResponse createdProductResponse = new CreatedProductResponse();
        //createdProductResponse.Id = createdProduct.Id;
        //createdProductResponse.ProductName = createdProduct.ProductName;
        //createdProductResponse.UnitPrice = createdProduct.UnitPrice;
        //createdProductResponse.QuantityPerUnit = createdProduct.QuantityPerUnit;
        //createdProductResponse.UnitsInStock = createdProduct.UnitsInStock;
        //return createdProductResponse;

    }

        public async Task<IPaginate<GetListProductResponse>> GetListAsync(PageRequest pageRequest)
        {
            //IPaginate<Product> products = await _productDal.GetListAsync();
            //GetListProductResponse mapped = _mapper.Map<GetListProductResponse>(products);
            //return mapped;

            var data = await _productDal.GetListAsync(
                include: p => p.Include(p => p.Category),
                index: pageRequest.PageIndex,
                size: pageRequest.PageSıze
                
                );

            var result = _mapper.Map<Paginate<GetListProductResponse>>(data); 
            return result;




        }



        //public List<GetListResponse> GetAll()
        //{
        //    //business rules
        //    IPaginate<Product> products = _productDal.GetList();

        //    List<GetListResponse> responses = _mapper.Map<List<GetListResponse>>(products.Items);

        //    //List<GetListProductResponse> responses = new List<GetListProductResponse>();

        //    //foreach (Product product in products.Items)
        //    //{
        //    //    GetListProductResponse getProductResponse = new GetListProductResponse();
        //    //    getProductResponse.ProductName = product.ProductName;
        //    //    getProductResponse.UnitPrice = product.UnitPrice;
        //    //    getProductResponse.UnitsInStock = product.UnitsInStock;
        //    //    responses.Add(getProductResponse);
        //    //}

        //    return responses;
        //}
    }
}
