using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lot.IDAL
{
    public interface IBaseDal<T> where T : class, new()
    {
        IQueryable<T> GetEntityByLambda(Expression<Func<T, bool>> wherelambda);
        T AddEntity(T entity);
        bool DeleteEntity(T entity);
        bool UpdateEntity(T entity);
    }
}
