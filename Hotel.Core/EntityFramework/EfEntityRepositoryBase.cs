using Hotel.Core.DataAccess;
using Hotel.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Hotel.Core.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using var context = new TContext();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using var context = new TContext();
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            return context.Set<TEntity>().SingleOrDefault(filter);
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            using var context = new TContext();
            var asQueryable = context.Set<TEntity>().AsQueryable();
            foreach (var include in includes)
            {
                var memberExpression = include.Body as MemberExpression;

                if (memberExpression != null)
                    asQueryable = asQueryable.Include(memberExpression.Member.Name);
            }

            return filter == null
                   ? asQueryable.ToList()
                   : asQueryable.Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {
            using var context = new TContext();
            var modifiedEntity = context.Entry(entity);
            modifiedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
