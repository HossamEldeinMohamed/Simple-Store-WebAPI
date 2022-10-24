using AutoMapper;
using BusinessLayer.IServices;
using Common_Utility.DTO;
using DataAccess.Entities;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkLayer.Interface;

namespace BusinessLayer.Services
{
    public class OrderService : IOrder
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IOrderDetailService orderDetails;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IOrderDetailService order)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
            orderDetails = order;
        }

        public Task<Response> DeleteAsync(Guid id)
        {
            //Not Require but to make this selution scalble
            throw new NotImplementedException();
        }

        public Response GetAll()
        {
            try
            {
                return new Response { Code = 200, Data = unitOfWork.Order.GetAll() };
            }
            catch (Exception ex)
            {
                return new Response { Code = 400, Message = ex.Message };
            }
        }

        public async Task<Response> GetByIdAsync(Guid id)
        {
            try
            {
                return new Response { Code = 200, Data = await unitOfWork.Order.GetByIdAsync(id) };
            }
            catch (Exception ex)
            {
                return new Response { Code = 400, Message = ex.Message };
            }
        }

        public async Task<Response> InsertAsync(OrderDTO obj)
        {
            try
            {
                var order = _mapper.Map<Order>(obj);

                var resut = await unitOfWork.Order.InsertAsync(order);
                unitOfWork.Save();
                var OrderItems = await orderDetails.CreateOrderDetailAsync(obj.OrderDetailes, order.ID);
                return new Response { Code = 200, Data = resut };
            }
            catch (Exception e)
            {
                return new Response { Code = 400, Data = e.Message };
            }
        }

        public Task<Response> UpdateAsync(OrderDTO obj)
        {
            //Not Require but to make this selution scalble
            throw new NotImplementedException();
        }
    }
}
