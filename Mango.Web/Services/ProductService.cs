using Mango.Web.Models;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
            => _clientFactory = clientFactory;


        public async Task<T> CreateProductAsync<T>(ProductDTO productDTO)
            => await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = productDTO,
                Url = SD.ProductAPIBase + "/api/productapi",
                AccessToken = ""
            });

        public async Task<T> DeleteProductAsync<T>(Guid id)
            => await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + "/api/productapi/" + id,
                AccessToken = ""
            });

        public async Task<T> GetAllProductByIdAsync<T>(Guid id)
            => await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/productapi/" + id,
                AccessToken = ""
            });

        public async Task<T> GetAllProductsAsync<T>()
            => await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/productapi",
                AccessToken = ""
            });

        public async Task<T> UpdateProductAsync<T>(ProductDTO productDTO)
            => await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = productDTO,
                Url = SD.ProductAPIBase + "/api/productapi",
                AccessToken = ""
            });
    }
}
