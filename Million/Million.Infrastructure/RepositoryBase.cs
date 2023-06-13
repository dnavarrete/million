using Million.Core;
using System.Linq.Expressions;

namespace Million.Infrastructure
{
    public sealed class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly MillionContext _context;

        public RepositoryBase(MillionContext context) 
        {
            _context = context;
        }

        public T? Find(params object[] keys)
        {
            return _context.Set<T>().Find(keys);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public T Insert(T entity)
        {
            var addedEntity = _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return addedEntity.Entity;
        }

        public T Update(T entity)
        {
            var updatedEntity = _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return updatedEntity.Entity;
        }
    }
}
