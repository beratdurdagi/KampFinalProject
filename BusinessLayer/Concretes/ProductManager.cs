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
using BusinessLayer.Constants;
using Core.Utilities.Results.DataResult;
using BusinessLayer.ValidationRules.FluentValidation;
using FluentValidation.Results;
using FluentValidation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Aspect.AutoFact.Validation;
using DataAccessLayer.Concrete.EntityFramework;
using Core.Utilities.Business;
using BusinessLayer.BusinessAspects.Autofac;
using Core.Aspect.AutoFact.Caching;
using Core.Aspects.Autofac.Transaction;

namespace BusinessLayer.Concretes;

public class ProductManager : IProductService


{

   private readonly IProductDal _productDal;
   private readonly ICategoryService _categoryService;
    public ProductManager(IProductDal productDal,ICategoryService categoryService)
    {   
        _productDal = productDal;
        _categoryService = categoryService;


    }
    [SecuredOperation("product.add,admin")]
    [ValidationAspect(typeof(ProductValidator))]
    [CacheRemoveAspect("IProductService.Get")]
    public IResult Add(Product product)
    {
        //business codes

        //validation


        // bir kategoride en fazla 10 ürün olabilir
        var result = BusinessRules.Run(CategoryFilter(product.CategoryId), CheckIfProductNameExists(product.ProductName));
        // aynı isimde ürün eklenemez

        if (result !=null)
        {
            return result;
        }

        _productDal.Add(product);

        return new SuccessResult(Messages.ProductAdded);
    }

    private IResult CheckIfProductNameExists(string productName)
    {

        var result = _productDal.GetAll(p => p.ProductName == productName).Any();
        if (result)
        {
            return new ErrorResult(Messages.ProductNameAlreadyTaken);
        }

        return new SuccessResult();
    }





    private IResult CategoryFilter(int categoryId) { 

        var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
        if (result >= 10)
        {
            return new ErrorResult(Messages.ProductCountofCategoryError);
        }

        return new SuccessResult();
    }


    [CacheAspect]
    public IDataResult<List<Product>> GetAll()
    {

        var result = _productDal.GetAll();

        return new SuccessDataResult<List<Product>>(result, Messages.ProductsListed);


        }

    public IDataResult<List<Product>> GetAllByCategoryId(int id)
    {
        var result = _productDal.GetAll(p => p.CategoryId == id);
        return new SuccessDataResult<List<Product>>(result,Messages.ProductsListed);
    }
    [CacheAspect] 
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
    [ValidationAspect(typeof(ProductValidator))]
    [CacheRemoveAspect("IProductService.Get")]
    [SecuredOperation("product.update,admin")]
    public IResult Update(Product product)
    {
        _productDal.Update(product);
        return new SuccessResult(Messages.ProductUpdated);
    }

    [TransactionScopeAspect]
    public IResult TransactionalOperation(Product product)
    {
        _productDal.Update(product);
        _productDal.Add(product);
        return new SuccessResult(Messages.ProductUpdated);
    }
}
