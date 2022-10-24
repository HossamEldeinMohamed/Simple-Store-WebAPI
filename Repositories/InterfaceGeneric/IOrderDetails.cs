using DataAccess.Entities;


namespace Repositories.InterfaceGeneric
{
    public interface IOrderDetails : IGenericRepository<OrderDetail>
    {
        Task<IList<OrderDetail>> InsertRangeAsync(IList<OrderDetail> obj);
    }
}
