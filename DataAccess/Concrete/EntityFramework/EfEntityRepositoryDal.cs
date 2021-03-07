using DataAccess.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryDal<TEntity> : IEntityRepositoryDal<TEntity>
        where TEntity: class, IEntity, new() 
    {
        private void NorthwindEntry(TEntity entity,EntityState state)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                db.Entry<TEntity>(entity).State = state;
                db.SaveChanges();
            }
        }

        public void Add(TEntity entity)
        {
            NorthwindEntry(entity, EntityState.Added);
        }

        public void Delete(TEntity entity)
        {
            NorthwindEntry(entity, EntityState.Deleted);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                return db.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                return filter == null ? db.Set<TEntity>().ToList() : db.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            NorthwindEntry(entity, EntityState.Modified);
        }
    }
}
