using Core.DataAccess.EntitiyFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EFCategoryDal:EfEntityRepositoryBase<Category,Context>,ICategoryDal
    {
    }
}
