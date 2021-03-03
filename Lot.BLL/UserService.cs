using Lot.DAL;
using Lot.DalFactory;
using Lot.IBLL;
using Lot.IDAL;
using Lot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lot.BLL
{
    public class UserService:BaseService<USERINFO>,IUserService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.DbSession.UserDal;
        }
    }
}
