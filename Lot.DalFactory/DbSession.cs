using Lot.DAL;
using Lot.IDAL;

namespace Lot.DalFactory
{
    public class DbSession : IDbSession
    {
        //声明UserDal
        public IUserDal UserDal
        {
            get
            {
                return AbstractFactory.GetCurrentUserDal();
            }
        }

        //保存实体
        public int SaveChanges()
        {
            return DbContextFactory.GetCurrentDbContext().SaveChanges();
        }
    }
}