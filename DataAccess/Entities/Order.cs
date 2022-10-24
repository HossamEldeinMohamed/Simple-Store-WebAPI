using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Order : Entity
    {
        public string CustomerUserId { get; set; }
        public int OrderNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public double Total { get; set; }


        public virtual IdentityUser CustomerUser { get; set; }
        public virtual ICollection<OrderDetail> OrderDetailes { get; set; }
    }
}
