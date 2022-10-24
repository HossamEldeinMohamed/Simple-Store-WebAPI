using BusinessLayer.IServices;
using BusinessLayer.Services;
using Common_Utility.DTO;
using Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Simple_Store_Web_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _ProductService;
        public ProductController(IProduct ProductService) => (_ProductService) = (ProductService);
        [HttpPost("CreateProductAsync")]
        [Produces("application/json")]
        public async Task<Response> CreateProductAsync(ProductDTO Product)
        {
             if (ModelState.IsValid)
            {
                var result = await _ProductService.InsertAsync(Product);
                return result;
            }
            return new Response { Data = ModelState.Values.SelectMany(v => v.Errors), Message = "Not Implemented" };
        }
        [HttpGet("GetProductAsync")]
        [Produces("application/json")]
        public async Task<IActionResult> GetProductAsync()
        {
            // Product result = new Product();
            if (ModelState.IsValid)
            {
                var result = _ProductService.GetAll();
                if (result != null)
                {
                    return StatusCode(200, new Response { Data = result, Message = "Get Successfully" });
                }
                return StatusCode(400, new Response { Data = result, Message = "No data Exist" });

            }
            return StatusCode(501, new Response { Data = ModelState.Values.SelectMany(v => v.Errors), Message = "Not Implemented" });
        }
        [HttpGet("GetProductByIdAsync")]
        [Produces("application/json")]
        public async Task<Response> GetProductByIdAsync(Guid Id)
        {
            if (ModelState.IsValid)
            {
                var result = await _ProductService.GetByIdAsync(Id);
                return result;
            }
            return new Response { Data = ModelState.Values.SelectMany(v => v.Errors), Message = "Not Implemented" };
        }
        [HttpPut("UpdataByIdAsync")]
        [Produces("application/json")]
        public async Task<Response> UpdataByIdAsync(UpdateProductDTO Product)
        {
            // Product result = new Product();
            if (ModelState.IsValid)
            {
                var result = await _ProductService.UpdateAsync(Product);
                return result;
            }
            return new Response { Data = ModelState.Values.SelectMany(v => v.Errors), Message = "Not Implemented" };
        }
        [HttpDelete("DeleteByIdAsync")]
        [Produces("application/json")]
        public async Task<Response> DeleteProductAsync(Guid Id)
        {
            // Product result = new Product();
            if (ModelState.IsValid)
            {
                var result = await _ProductService.DeleteAsync(Id);
                return result;
            }
            return new Response { Data = ModelState.Values.SelectMany(v => v.Errors), Message = "Not Implemented" };
        }

    }
}

