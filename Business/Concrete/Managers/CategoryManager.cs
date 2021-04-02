using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete.Managers
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        private IResult BaseProccess(bool state,string message)
        {
            if (state)
            {
                return new SuccessResult(message);
            }
            return new ErrorResult();
        }
        public IResult Add(Category category)
        {
            return BaseProccess(_categoryDal.Add(category), Messages.Category.Added);
        }

        public IResult Delete(int id)
        {
            return BaseProccess(_categoryDal.Delete(new Category { CategoryID = id }),Messages.Category.Deleted);
        }

        public IDataResult<List<Category>> GetCategories()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.Category.Listed);
        }

        public IResult Update(Category category)
        {
            return BaseProccess(_categoryDal.Update(category), Messages.Category.Updated);
        }
    }
}
