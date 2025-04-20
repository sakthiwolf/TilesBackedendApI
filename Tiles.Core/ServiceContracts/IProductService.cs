using Tiles.Core.DTO.ProductDto;

namespace Tiles.Core.ServiceContracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> GetAllProducts();
        Task<ProductResponse?> GetProductById(int id);
        Task<int> AddProduct(ProductRequest dto);
        Task UpdateProduct(int id, ProductUpdateRequest dto);
        Task DeleteProduct(int id);
    }
}
