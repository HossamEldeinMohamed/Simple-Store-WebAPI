using DataAccess.Data;
using DataAccess.Entities;
using Repositories;
using Repositories.InterfaceGeneric;
using Repositories.Repositories;

using UnitOfWorkLayer.Interface;

namespace UnitOfWorkLayer.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Product = new ProductRepository(_context);
            Order = new OrderRepository(_context);
            OrderDetail = new OrderDetailRepository(_context);

        }

        public IGenericRepository<Product> Product { get; private set; }

        public IGenericRepository<Order> Order { get; private set; }

        public IOrderDetails OrderDetail { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
