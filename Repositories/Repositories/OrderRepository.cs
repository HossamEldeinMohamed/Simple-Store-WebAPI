using DataAccess.Data;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IGenericRepository<Order>
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}
