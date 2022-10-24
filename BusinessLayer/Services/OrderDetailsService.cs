using AutoMapper;
using BusinessLayer.IServices;
using Common_Utility.DTO;
using DataAccess.Entities;
using Helpers;
using UnitOfWorkLayer.Interface;

namespace BusinessLayer.Services
{
    public class OrderDetailsService : IOrderDetailService
    {
        readonly IList<OrderDetail> orderList = new List<OrderDetail>();
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        public OrderDetailsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> CreateOrderDetailAsync(IList<OrderDetailDTO> OrderDetailObj, Guid orderId)
        {
            foreach (var item in OrderDetailObj)
            {
                var Product = await unitOfWork.Product.GetByIdAsync(item.ProductId);
                var Order = await unitOfWork.Order.GetByIdAsync(orderId);
                if (Product != null)
                {
                    if (Product.Amount >= item.Quantity)
                    {
                        var result = _mapper.Map<OrderDetail>(item);
                        result.TotalPrice = item.Quantity * Product.Price;
                        result.Price = Product.Price;
                        result.OrderId = orderId;
                        result.ProductId = Product.ID;
                        orderList.Add(result);
                        Order.Total += result.TotalPrice;
                        Product.Amount -= item.Quantity;
                        try
                        {
                           await unitOfWork.Product.UpdateAsync(Product);
                           await unitOfWork.Order.UpdateAsync(Order);
                        }
                        catch (Exception e)
                        {
                            return new Response { Code = 400, Data = e.Data, Message = e.Message };
                        }
                    }
                    else
                        return new Response { Code = 404, Message = "please the required quantity is not available " };
                }
                else
                    return new Response { Code = 404, Message = "The Product is null" };
            }
            await unitOfWork.OrderDetail.InsertRangeAsync(orderList);
            unitOfWork.Save();
            return new Response { Code = 200, Data = orderList, Message = "Create Successfully" };
        }

        public async Task<Response> GetOrderDetailById(Guid id)
        {
            var result = await unitOfWork.OrderDetail.GetByIdAsync(id);
            if (result != null)
                return new Response { Code = 200, Data = result, Message = "Get Successfully" };
            return new Response { Code = 400, Message = "Not Exist in Database" };
        }
    }
}
