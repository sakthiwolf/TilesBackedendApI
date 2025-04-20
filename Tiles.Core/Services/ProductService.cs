using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tiles.Core.Domain.Entites;
using Tiles.Core.Domain.RepositroyContracts;
using Tiles.Core.DTO.ProductDto;
using Tiles.Core.ServiceContracts;

namespace Tiles.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> AddProduct(ProductRequest dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price
            };

            await _repo.AddAsync(product);
            return product.Id;
        }

        public async Task UpdateProduct(int id, ProductUpdateRequest dto)
        {
            var product = new Product
            {
                Id = id,
                Name = dto.Name,
                Price = dto.Price
            };

            await _repo.UpdateAsync(product);
        }

        public async Task<IEnumerable<ProductResponse>> GetAllProducts()
        {
            var products = await _repo.GetAllAsync();
            return products.Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            });
        }

        public async Task<ProductResponse?> GetProductById(int id)
        {
            var p = await _repo.GetByIdAsync(id);
            return p == null ? null : new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            };
        }

        public async Task DeleteProduct(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
