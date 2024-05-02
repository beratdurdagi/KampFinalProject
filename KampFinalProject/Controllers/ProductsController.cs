using BusinessLayer.Abstract;
using BusinessLayer.Concretes;
using EntityLayer.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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




        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productManager.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll() { 
        
            var result =_productManager.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetbyId/{id}")]
        public IActionResult GetById(int id)
        {
            var result =_productManager.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getproductdetails")]
        public IActionResult GetProductDetails()
        {
            var result = _productManager.GetProductDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productManager.Add(product);
            if (result.Success)
            {
             
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

    }


    
}
