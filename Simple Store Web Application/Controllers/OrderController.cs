using BusinessLayer.IServices;
using Common_Utility.DTO;
using Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Simple_Store_Web_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _OrderService;
        public OrderController(IOrder order) => (_OrderService) = (order);

        [HttpPost("CreateOrderAsync")]
        [Produces("application/json")]
        public async Task<Response> CreateOrderAsync(OrderDTO Order)
        {
            // Order result = new Order();
            if (ModelState.IsValid)
            {
                var result = await _OrderService.InsertAsync(Order);
                return result;
            }
            return new Response { Data = ModelState.Values.SelectMany(v => v.Errors), Message = "Not Implemented" };
        }
        [HttpGet("GetOrderAsync")]
        [Produces("application/json")]
        public IActionResult GetOrderAsync()
        {
            if (ModelState.IsValid)
            {
                var result = _OrderService.GetAll();
                if (result != null)
                {
                    return StatusCode(200, new Response { Data = result, Message = "Get Successfully" });
                }
                return StatusCode(400, new Response { Data = result, Message = "No data Exist" });
            }
            return StatusCode(501, new Response { Data = ModelState.Values.SelectMany(v => v.Errors), Message = "Not Implemented" });
        }
        [HttpGet("GetOrderByIdAsync")]
        [Produces("application/json")]
        public async Task<Response> GetOrderByIdAsync(Guid Id)
        {
            if (ModelState.IsValid)
            {
                var result = await _OrderService.GetByIdAsync(Id);
                return result;
            }
            return new Response { Data = ModelState.Values.SelectMany(v => v.Errors), Message = "Not Implemented" };
        }
    }

}

