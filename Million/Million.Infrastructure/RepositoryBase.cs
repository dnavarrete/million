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

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
    }
}
