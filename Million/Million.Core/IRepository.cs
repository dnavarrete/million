using System.Linq.Expressions;

namespace Million.Core
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

        T Insert(T entity);

        T? Find(params object[] keys);

        T Update(T entity);
    }
}
