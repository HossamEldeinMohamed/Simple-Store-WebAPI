using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Utility.DTO
{
    public class UpdateProductDTO : ProductDTO
    {
        public Guid ID { get; set; }
    }
}
