using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
            if (product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(int id)
        {
            _productDal.Delete(new Product { ProductID = id });
        }

        public IDataResult<Product> GetProduct(int productId)
        {
            return _productDal.Get(x => x.ProductID == productId);
        }

        public IDataResult<List<Product>> GetProducts()
        {
            if (DateTime.Now.Hour==10)
            {
                return new ErrorResult();
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),true,"Ürünler listelendi.");
        }

        public IDataResult<List<Product>> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(x => x.CategoryId == categoryId);
        }

        public IDataResult<List<Product>> GetProductsByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(x => x.UnitPrice >= min && x.UnitPrice <= max);
        }

        public IDataResult<List<Product>> GetProductsWithCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
