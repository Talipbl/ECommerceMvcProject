using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IProductService
    {
        IDataResult<List<Product>> GetProducts();
        IDataResult<List<Product>> GetProductsWithCategoryId(int categoryId);
        IDataResult<List<Product>> GetProductsByCategory(int categoryId);
        IDataResult<List<Product>> GetProductsByUnitPrice(decimal min, decimal max);
        IDataResult<Product> GetProduct(int productId);
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(int id);
    }
}
