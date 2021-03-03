using System;
using System.Linq;
using System.Linq.Expressions;

namespace Lot.IBLL
{
    public interface IBaseService<T> where T : class, new()
    {
        IQueryable<T> GetEntityByLambda(Expression<Func<T, bool>> wherelambda);

        T AddEntity(T entity);

        bool DeleteEntity(T entity);

        bool UpdateEntity(T entity);
    }
}