using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        //BUSINESS CODE AND RULES
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService):this(productDal)
        {
            _categoryService = categoryService;
        }
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }


        [SecuredOperation("admin,editor")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExist(product.ProductName), CheckIfProductCountOfCategoryCorrect(product.CategoryId),CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.Product.Added);

        }

        public IResult Delete(int id)
        {
            _productDal.Delete(new Product { ProductID = id });
            return new SuccessResult(Messages.Product.Deleted);
        }

        public IDataResult<Product> GetProduct(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductID == productId), Messages.Product.Listed);
        }
        public IDataResult<List<Product>> GetProducts()
        {
            if (DateTime.Now.Hour == 10)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.Product.ProductsListed);
        }

        public IDataResult<List<Product>> GetProductsByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.CategoryId == categoryId), Messages.Product.ProductsListed);
        }

        public IDataResult<List<Product>> GetProductsByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.UnitPrice >= min && x.UnitPrice <= max), Messages.Product.ProductsListed);
        }


        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.Product.Updated);
        }



        private IResult CheckIfProductNameExist(string productName)
        {
            var result = _productDal.Get(p => p.ProductName == productName);
            if (result != null)
            {
                return new ErrorResult(Messages.Product.NameInvalid);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId);
            if (result.Count >= 10)
            {
                return new ErrorResult(Messages.Product.CountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetCategories();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.Category.LimitExceded);
            }

            return new SuccessResult();
        }

    }
}
