using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface ICategoryService
    {
        List<Category> GetCategories();
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
