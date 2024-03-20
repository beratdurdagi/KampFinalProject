using Core.DataAccess.EntitiyFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework;

public class EFProductDal : EfEntityRepositoryBase<Product,Context>,IProductDal
{

   
    }

