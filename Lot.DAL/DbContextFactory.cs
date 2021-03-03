using Lot.Model;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace Lot.DAL
{
    public class DbContextFactory
    {
        public static DbContext GetCurrentDbContext()
        {
            DbContext context = CallContext.GetData("DbContext") as DbContext;
            if (context == null)
            {
                context = new LotModel();
                CallContext.SetData("DbContext", context);
            }
            return context;
        }
    }
}