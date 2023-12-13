using Business.Abstracts;
using Business.Messages;
using Core.Business.Rules;
using Core.CrossCutingConcerns.Types;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class ProductBusinessRules : BaseBusinessRules
    {
        private readonly IProductDal _productDal;


        public ProductBusinessRules(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task MaximumProduct(int CategoryId)
        {
            var result = await _productDal.GetListAsync(i => i.CategoryId == CategoryId);

            if (result.Count >= 20)
            {
                throw new BusinessException(BusinessMessages.ProductLimit);
            }
        }
    }
}
