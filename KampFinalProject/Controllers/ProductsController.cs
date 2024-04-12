using BusinessLayer.Abstract;
using BusinessLayer.Concretes;
using EntityLayer.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productManager;
        public ProductsController(IProductService productManager)
        {
            _productManager= productManager;
        } 
            

        [HttpGet("GetAll")]
        public IActionResult GetAll() { 
        
            var result =_productManager.GetAll();
            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]

        public IActionResult AddProduct(Product product) {

            var result = _productManager.Add(product);

            if(result.Success)
            {
                return Created();
            }

            return BadRequest(result.Message);
        
        }

    }
}
