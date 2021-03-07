using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int id)
        {
            _productDal.Delete(new Product { ProductID = id });
        }

        public Product GetProduct(int productId)
        {
            return _productDal.Get(x => x.ProductID == productId);
        }

        public List<Product> GetProducts()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(x => x.CategoryId == categoryId);
        }

        public List<Product> GetProductsByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(x => x.UnitPrice >= min && x.UnitPrice <= max);
        }

        public List<Product> GetProductsWithCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
