using BusinessLayer.Abstract;
using EntityLayer.Concretes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using EntityLayer.DTOs;

namespace BusinessLayer.Concretes;

public class ProductManager : IProductService


{

   private readonly IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {   
        _productDal = productDal;
        
    }
    public List<Product> GetAll()
    {

        return _productDal.GetAll();
        }

    public List<Product> GetAllByCategoryId(int id)
    {
        return _productDal.GetAll(p => p.CategoryId == id);
    }

    public List<Product> GetByUnitPrice(decimal min, decimal max)
    {
        return _productDal.GetAll(p=>p.UnitPrice >= min && p.UnitPrice <= max);
    }

    public List<ProductDetalilDto> GetProductDetails()
    {
        return _productDal.GetProductDetails();
    }
}
