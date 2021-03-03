using Lot.DalFactory;
using Lot.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lot.BLL
{
    public abstract class BaseService<T> where T:class,new()
    {
        public IBaseDal<T> CurrentDal { get; set; }
        public IDbSession DbSession
        {
            get
            {
                return DbSessionFactory.GetCurrentDbSession();
            }
        }

        public BaseService()
        {
            SetCurrentDal();
        }
        public abstract void SetCurrentDal();//抽象方法：要求子类必须实现。

        public IQueryable<T> GetEntityByLambda(Expression<Func<T, bool>> wherelambda)
        {
            return CurrentDal.GetEntityByLambda(wherelambda);
        }
        public T AddEntity(T entity)
        {
            CurrentDal.AddEntity(entity);
            DbSession.SaveChanges();
            return entity;
        }

        //删除

        public bool DeleteEntity(T entity)
        {
            CurrentDal.DeleteEntity(entity);
            return DbSession.SaveChanges() > 0;

        }
        // 改
        public bool UpdateEntity(T entity)
        {
            CurrentDal.UpdateEntity(entity);
            return DbSession.SaveChanges() > 0;

        }
    }
}
