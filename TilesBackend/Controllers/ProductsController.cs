using Microsoft.AspNetCore.Mvc;
using Tiles.Core.ServiceContracts;
using Microsoft.Extensions.Logging;
using Tiles.Core.DTO.ProductDto;

namespace TilesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService service, ILogger<ProductsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductRequest dto)
        {
            _logger.LogInformation("POST request received to create a product: {ProductName}", dto.Name);

            var id = await _service.AddProduct(dto);
            _logger.LogInformation("Product created successfully with ID: {ProductId}", id);

            return CreatedAtAction(nameof(Get), new { id }, new { id, dto.Name, dto.Price });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductUpdateRequest dto)
        {
            _logger.LogInformation("PUT request received to update product with ID: {ProductId}", id);

            await _service.UpdateProduct(id, dto);
            _logger.LogInformation("Product with ID {ProductId} updated successfully.", id);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("GET request received to fetch all products.");

            var products = await _service.GetAllProducts();

            _logger.LogInformation("Returned {Count} products.", products.Count());

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation("GET request received for product ID: {ProductId}", id);

            var product = await _service.GetProductById(id);
            if (product == null)
            {
                _logger.LogWarning("Product with ID {ProductId} not found.", id);
                return NotFound();
            }

            _logger.LogInformation("Product with ID {ProductId} returned successfully.", id);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("DELETE request received for product ID: {ProductId}", id);

            await _service.DeleteProduct(id);

            _logger.LogInformation("Product with ID {ProductId} deleted successfully.", id);
            return NoContent();
        }
    }
}
