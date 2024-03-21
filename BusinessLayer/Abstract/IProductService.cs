﻿using Core.Utilities.Results;
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
    List<Product> GetAll();
    List<Product> GetAllByCategoryId(int id);
    List<Product> GetByUnitPrice(decimal min , decimal max);
    List<ProductDetalilDto> GetProductDetails();

    Product GetById(int ProductId);

    IResult Add(Product product);

   
}
