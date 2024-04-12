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
using Core.Constants;
using Core.Utilities.Results.DataResult;
using BusinessLayer.ValidationRules.FluentValidation;
using FluentValidation.Results;
using FluentValidation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Aspect.AutoFact.Validation;

namespace BusinessLayer.Concretes;

public class ProductManager : IProductService


{

   private readonly IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {   
        _productDal = productDal;
        
    }
    [ValidationAspect(typeof(ProductValidator))]
    public IResult Add(Product product)
    {
        //business codes

        //validation
        ValidationTool.Validate(new ProductValidator(),product);
       
       
        _productDal.Add(product);
        return new SuccessResult(Messages.ProductAdded);

       
    }
    
    public IDataResult<List<Product>> GetAll()
    {

        var result = _productDal.GetAll();

        return new SuccessDataResult<List<Product>>(result, Messages.ProductsListed);


        }

    public IDataResult<List<Product>> GetAllByCategoryId(int id)
    {
        var result = _productDal.GetAll(p => p.CategoryId == id);
        return new SuccessDataResult<List<Product>>(result);
    }

    public IDataResult<Product> GetById(int ProductId)
    {

        //business codes
        var result = _productDal.Get(p =>p.ProductId == ProductId);
        return new SuccessDataResult<Product>(result,Messages.ProductListed);
    }

    public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
    {
        var result = _productDal.GetAll(p=>p.UnitPrice >= min && p.UnitPrice <= max);
        return new SuccessDataResult<List<Product>>(result);
    }

    public IDataResult<List<ProductDetalilDto>> GetProductDetails()
    {
        var result = _productDal.GetProductDetails();

        return new SuccessDataResult<List<ProductDetalilDto>>(result);
    }
}
