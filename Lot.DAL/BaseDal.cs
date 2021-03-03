using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Lot.DAL
{
    public class BaseDal<T> where T : class, new()
    {
        //实例化上下文
        private DbContext context = DbContextFactory.GetCurrentDbContext();

        //使用lambda条件进行查询
        public IQueryable<T> GetEntityByLambda(Expression<Func<T, bool>> wherelambda)
        {
            return context.Set<T>().Where(wherelambda).AsQueryable();
        }

        //增删改

        #region 增删改

        public T AddEntity(T entity)
        {
            context.Set<T>().Add(entity);
            return entity;
        }

        public bool DeleteEntity(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Deleted;
            return true;
        }

        public bool UpdateEntity(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
            return true;
        }

        #endregion 增删改
    }
}