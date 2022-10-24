using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class OrderDetail : Entity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }


    }
}
