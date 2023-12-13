using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.DTOs.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using Core.Persistence.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class CustomerManager : ICustomerService
{
    ICustomerDal _customerDal;
    IMapper _mapper;
    CustomerBusinessRules _rules;
    public CustomerManager(ICustomerDal customerDal, IMapper mapper, CustomerBusinessRules rules)
    {
        _customerDal = customerDal;
        _mapper = mapper;
        _rules = rules;
    }

    public async Task<CreatedCustomerResponse> Add(CreateCustomerRequest createCustomerRequest)
    {
        await _rules.ContactNameRepeat(createCustomerRequest.ContactName);
        await _rules.CityLimitTen(createCustomerRequest.City);
        Customer customer = _mapper.Map<Customer>(createCustomerRequest);
        Customer createdCustomer = await _customerDal.AddAsync(customer);
        CreatedCustomerResponse createdCustomerResponse = _mapper.Map<CreatedCustomerResponse>(createdCustomer);
        return createdCustomerResponse;
    }

    public async Task<Customer> Delete(string Id, bool permanent)
    {
        var data = await _customerDal.GetAsync(i => i.Id == Id);
        var result = await _customerDal.DeleteAsync(data, permanent);
        return result;
    }

    public async Task<IPaginate<GetListCustomerResponse>> GetAll(PageRequest pageRequest)
    {
        var data = await _customerDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
                );
        var result = _mapper.Map<Paginate<GetListCustomerResponse>>(data);
        return result;
    }


    public async Task<UpdatedCustomerResponse> Update(UpdateCustomerRequest updateCustomerRequest)
    {
        var data = await _customerDal.GetAsync(i => i.Id == updateCustomerRequest.Id);
        _mapper.Map(updateCustomerRequest, data);
        data.UpdatedDate = DateTime.Now;
        await _customerDal.UpdateAsync(data);
        var result = _mapper.Map<UpdatedCustomerResponse>(data);
        return result;
    }
}