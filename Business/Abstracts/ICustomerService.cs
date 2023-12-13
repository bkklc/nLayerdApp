using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.DTOs.Responses;
using Core.DataAccess.Paging;
using Core.Persistence.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface ICustomerService
{
    Task<CreatedCustomerResponse> Add(CreateCustomerRequest createCustomerRequest);
    Task<UpdatedCustomerResponse> Update(UpdateCustomerRequest updateCustomerRequest);
    Task<Customer> Delete(string Id, bool permanent);
    Task<IPaginate<GetListCustomerResponse>> GetAll(PageRequest pageRequest);
}