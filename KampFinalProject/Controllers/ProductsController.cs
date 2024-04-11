using BusinessLayer.Abstract;
using BusinessLayer.Concretes;
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
            

        [HttpGet]
        public IActionResult GetAll() { 
        
            var result =_productManager.GetAll();
            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
