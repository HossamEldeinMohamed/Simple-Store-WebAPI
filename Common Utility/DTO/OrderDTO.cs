
using System.ComponentModel.DataAnnotations;


namespace Common_Utility.DTO
{
    public class OrderDTO
    {
       public string CustomerUserId { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ShipDate { get; set; }
        public virtual IList<OrderDetailDTO> OrderDetailes { get; set; }

    }
}
