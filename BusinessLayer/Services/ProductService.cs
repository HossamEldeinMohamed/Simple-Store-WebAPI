using AutoMapper;
using BusinessLayer.IServices;
using Common_Utility.DTO;
using DataAccess.Entities;
using Helpers;
using UnitOfWorkLayer.Interface;

namespace BusinessLayer.Services
{
    public class ProductService : IProduct
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response> DeleteAsync(Guid id)
        {
            try
            {
                var result =await unitOfWork.Product.DeleteAsync(id);
                unitOfWork.Save();
                return new Response { Code = 200, Data = result };
            }
            catch(Exception ex)
            {
                return new Response { Code = 500, Message = ex.Message };
            }


        }

        public Response GetAll()
        {
            try
            {
                return new Response { Code = 200, Data = unitOfWork.Product.GetAll()};
            }
            catch(Exception ex)
            {
                return new Response { Code = 400 , Message = ex.Message};
            }
        }

        public async Task<Response> GetByIdAsync(Guid id)
        {
            try
            {
                return new Response { Code = 200, Data = await unitOfWork.Product.GetByIdAsync(id) };
            }
            catch(Exception ex)
            {
                return new Response { Code = 400, Message =  ex.Message};
            }
        }

        public async Task<Response> InsertAsync(ProductDTO obj)
        {
            try
            {
                var product = _mapper.Map<Product>(obj);
                var resut =await unitOfWork.Product.InsertAsync(product);
                unitOfWork.Save();
                return new Response { Code = 200, Data = resut };
            }
            catch(Exception e)
            {
                return new Response { Code = 400 , Data = e.Message };
            }
        }

        public async Task<Response> UpdateAsync(ProductDTO obj)
        {
            try
            {
                var product = _mapper.Map<Product>(obj);

                var resut =await unitOfWork.Product.UpdateAsync(product);
                unitOfWork.Save();
                return new Response { Code = 200, Data = resut };
            }
            catch (Exception e)
            {
                return new Response { Code = 400, Data = e.Message };
            }
        }
    }
}
