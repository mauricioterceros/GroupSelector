using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace APITEST.Controllers
{
    [Route("api-crm/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBackingService _productBS;
        public ProductController(IProductBackingService productBS)
        {
            _productBS = productBS;
        }
        
        [HttpGet]
        [Route("")]
        public List<ProductBsDTO> Get()
        {
            Console.WriteLine("This is the END POINT for Products");
            return _productBS.GetAllProduct().Result;
        }

        [HttpGet]
        [Route("{id}")]
        public IEnumerable<string> GetById()
        {
            throw new NotImplementedException();
        }
    }
}
