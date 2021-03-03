namespace Lot.IDAL
{
    public interface IDbSession
    {
        IUserDal UserDal { get; }

        int SaveChanges();
    }
}