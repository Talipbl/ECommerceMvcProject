using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IProductService
    {
        List<Product> GetProducts();
        List<Product> GetProductsWithCategoryId(int categoryId);
        List<Product> GetProductsByCategory(int categoryId);
        List<Product> GetProductsByUnitPrice(decimal min, decimal max);
        Product GetProduct(int productId);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
