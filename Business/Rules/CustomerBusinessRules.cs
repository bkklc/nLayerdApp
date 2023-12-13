using Business.Messages;
using Core.Business.Rules;
using Core.CrossCutingConcerns.Types;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules;

public class CustomerBusinessRules : BaseBusinessRules
{
    private readonly ICustomerDal _customerDal;

    public CustomerBusinessRules(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }

    public async Task ContactNameRepeat(string ContactName)
    {
        var result = await _customerDal.GetAsync(i => i.ContactName == ContactName);

        if (result != null)
        {
            throw new BusinessException(BusinessMessages.ContactNameLimit);
        }
    }

    public async Task CityLimitTen(string City)
    {
        var result = await _customerDal.GetListAsync(i => i.City == City);

        if (result.Count >= 10)
        {
            throw new BusinessException(BusinessMessages.CityLimit);
        }
    }
}