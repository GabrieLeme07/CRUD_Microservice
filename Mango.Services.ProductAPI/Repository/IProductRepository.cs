using Mango.Services.ProductAPI.DTO;

namespace Mango.Services.ProductAPI.Repository;

public interface IProductRepository
{
    Task<IEnumerable<ProductDTO>> GetProducts();
    Task<ProductDTO> GetProductById(Guid id);
    Task<ProductDTO> CreateUpdateProduct(ProductDTO product);
    Task<bool> DeleteProduct(Guid id);
}

