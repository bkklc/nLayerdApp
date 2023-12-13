using Business.Abstracts;
using Business.Dtos.Requests;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateCustomerRequest createCustomerRequest)
        {
            var result = await _customerService.Add(createCustomerRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string Id, bool permanent)
        {
            var result = await _customerService.Delete(Id, permanent);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var result = await _customerService.GetAll(pageRequest);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerRequest updateCustomerRequest)
        {
            var result = await _customerService.Update(updateCustomerRequest);
            return Ok(result);
        }
    }
}