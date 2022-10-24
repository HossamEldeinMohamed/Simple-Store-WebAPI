using DataAccess.Entities;
using Repositories;
using Repositories.InterfaceGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkLayer.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<Product> Product
        {
            get;
        }
        public IGenericRepository<Order> Order
        {
            get;
        }
        public IOrderDetails OrderDetail
        {
            get;
        }
        public void Save();
    }
}
