using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    public interface IProductService : IBaseService
    {
        Task<T> GetAllProductsAsync<T>();
        Task<T> GetAllProductByIdAsync<T>(Guid id);
        Task<T> CreateProductAsync<T>(ProductDTO productDTO);
        Task<T> UpdateProductAsync<T>(ProductDTO productDTO);
        Task<T> DeleteProductAsync<T>(Guid id);
    }
}
