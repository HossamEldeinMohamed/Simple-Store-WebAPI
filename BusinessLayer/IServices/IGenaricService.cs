using Common_Utility.DTO;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IServices
{
    public interface IGenaricService<T> where T : class
    {
        Response GetAll();
        Task<Response> GetByIdAsync(Guid id);
        Task<Response> UpdateAsync(T obj);
        Task<Response> DeleteAsync(Guid id);
        Task<Response> InsertAsync(T obj);
    }
}
