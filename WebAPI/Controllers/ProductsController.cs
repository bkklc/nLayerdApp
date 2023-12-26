using Business.Abstracts;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add")] 
        public async Task<IActionResult> Add([FromBody] CreateProductRequest createProductRequest) 

        {
            var result = await _productService.Add(createProductRequest);
            return Ok(result);
        }

        [HttpGet("GetAll")] 
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest ) 

        {
            var result =  await _productService.GetListAsync(pageRequest);
            return Ok(result); 
        }
    }
}
