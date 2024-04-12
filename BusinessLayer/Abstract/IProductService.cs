using Core.Utilities.Results;
using Core.Utilities.Results.DataResult;
using EntityLayer.Concretes;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract;

public interface IProductService
{
    IDataResult<List<Product>> GetAll();
    IDataResult<List<Product>> GetAllByCategoryId(int id);
    IDataResult<List<Product>> GetByUnitPrice(decimal min , decimal max);
    IDataResult<List<ProductDetalilDto>> GetProductDetails();
    IDataResult<Product> GetById(int ProductId);

    IResult Add(Product product);

   
}
