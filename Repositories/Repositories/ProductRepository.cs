using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;


namespace Repositories.Repositories
{
   public class ProductRepository : GenericRepository<Product>, IGenericRepository<Product>
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
