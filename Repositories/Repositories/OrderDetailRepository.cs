using DataAccess.Data;
using DataAccess.Entities;
using Repositories.InterfaceGeneric;

namespace Repositories.Repositories
{
   public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetails
    {
        public new readonly ApplicationDbContext _context;

        public OrderDetailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IList<OrderDetail>> InsertRangeAsync(IList<OrderDetail> obj)
        {
            try
            {

               await _context.AddRangeAsync(obj);
                return obj;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

    }
}
