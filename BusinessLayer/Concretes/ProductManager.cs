using BusinessLayer.Abstract;
using EntityLayer.Concretes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using EntityLayer.DTOs;
using Core.Utilities.Results;

namespace BusinessLayer.Concretes;

public class ProductManager : IProductService


{

   private readonly IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {   
        _productDal = productDal;
        
    }

    public IResult Add(Product product)
    {

        //business codes
        _productDal.Add(product);
        return new Result(true,"Product Added");

  
    }

    public List<Product> GetAll()
    {

        return _productDal.GetAll();
        }

    public List<Product> GetAllByCategoryId(int id)
    {
        return _productDal.GetAll(p => p.CategoryId == id);
    }

    public Product GetById(int ProductId)
    {

        //business codes
      return _productDal.Get(p=>p.ProductId == ProductId);
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
