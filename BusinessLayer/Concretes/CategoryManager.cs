using BusinessLayer.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Results.DataResult;
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
        public IDataResult<List<Category>>  GetAll()
        {
            //Business rules
            var result = _categoryDal.GetAll();
            return new SuccessDataResult<List<Category>>(result) ;
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            var result = _categoryDal.Get(P => P.CategoryId == categoryId);

            return new SuccessDataResult<Category>(result);
        }
    }
}
