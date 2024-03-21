using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concretes
{
    public class CategoryManager : ICategoryService


    {

        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public List<Category> GetAll()
        {
            //Business rules
            
            return _categoryDal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(P => P.CategoryId == categoryId);
        }
    }
}
