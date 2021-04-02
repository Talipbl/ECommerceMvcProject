using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetProducts();
        IDataResult<List<Product>> GetProductsByCategory(int categoryId);
        IDataResult<List<Product>> GetProductsByUnitPrice(decimal min, decimal max);
        IDataResult<Product> GetProduct(int productId);
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(int id);
    }
}
