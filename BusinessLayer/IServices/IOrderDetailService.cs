using Common_Utility.DTO;
using DataAccess.Entities;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IServices
{
    public interface IOrderDetailService 
    {
        public Task<Response> GetOrderDetailById(Guid id);
        public Task<Response> CreateOrderDetailAsync(IList<OrderDetailDTO> OrderDetail, Guid orderId);
    }
}
