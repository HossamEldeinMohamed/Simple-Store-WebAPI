using BusinessLayer.IServices;
using Common_Utility.DTO;
using Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Simple_Store_Web_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _OrderDetailService;

        public OrderDetailsController(IOrderDetailService OrderDetailService) => (_OrderDetailService) = (OrderDetailService);

        [HttpPost("CreateOrderDetailAsync")]
        [Produces("application/json")]
        public async Task<Response> CreateOrderDetailAsync(IList<OrderDetailDTO> OrderDetail, Guid orderId)
        {
            // OrderDetail result = new OrderDetail();
            if (ModelState.IsValid)
            {
                var result = await _OrderDetailService.CreateOrderDetailAsync(OrderDetail, orderId);
                return result;
            }
            return new Response { Data = ModelState.Values.SelectMany(v => v.Errors), Message = "Not Implemented" };
        }
       
        [HttpGet("GetOrderDetailByIdAsync")]
        [Produces("application/json")]
        public async Task<Response> GetOrderDetailByIdAsync(Guid Id)
        {
            // OrderDetail result = new OrderDetail();
            if (ModelState.IsValid)
            {
                var result = await _OrderDetailService.GetOrderDetailById(Id);
                return result;
            }
            return new Response { Data = ModelState.Values.SelectMany(v => v.Errors), Message = "Not Implemented" };
        }


    }
}
