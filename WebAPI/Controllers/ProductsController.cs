using Business.Concrete.Managers;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]//Attribute
    public class ProductsController : ControllerBase
    {
        //IoC Container
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            var result = _productService.GetProducts();
            return result.Data;
        }
    }
}
