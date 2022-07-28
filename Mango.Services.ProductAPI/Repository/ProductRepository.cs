using AutoMapper;
using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.DTO;
using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDTO> CreateUpdateProduct(ProductDTO productDTO)
        {
            Product product = _mapper.Map<ProductDTO, Product>(productDTO);

            if (product.ProductId != Guid.Empty)
                _db.Produtcs.Update(product);
            else
                _db.Produtcs.Add(product);

            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDTO>(product);
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            try
            {
                Product product = await _db.Produtcs
                .Where(e => e.ProductId == id)
                .FirstOrDefaultAsync();

                if (product == null)
                    return false;

                _db.Produtcs.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            List<Product> productList = await _db.Produtcs.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(productList);
        }

        public async Task<ProductDTO> GetProductById(Guid id)
        {
            Product product = await _db.Produtcs
                .Where(e => e.ProductId == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<ProductDTO>(product);
        }
    }
}
