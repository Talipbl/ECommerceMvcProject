using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
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
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public IResult Add(Product product)
        {
            //business codes and rules
            //validation

            ValidationTool.Validate(new ProductValidator(), product);

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

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.Product.Updated);
        }
    }
}
