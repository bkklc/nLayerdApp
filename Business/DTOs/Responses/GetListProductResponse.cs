using Business.DTOs.Models;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses
{
    public class GetListProductResponse : BasePageableModel
    {
        public IList<ProductListDto> Items { get; set; }
    }


    
}
