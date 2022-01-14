using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Catalog.Api.Entities;
using Catalog.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(IProductRepository repository, ILogger<CatalogController> logger)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
            _logger = logger ?? throw new ArgumentException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(IEnumerable<Product>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _repository.GetProducts();

            if (products == null)
            {
                _logger.LogInformation($"Products not found.");
                return NotFound();
            }

            return Ok(products);
        }
        
        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct(string id)
        {
            var product = await _repository.GetProduct(id);

            if (product == null)
            {
                _logger.LogInformation($"Product not found with id {id}", id);
                return NotFound();
            }

            return Ok(product);
        }
        
        [HttpGet]
        [Route("[action]/{name}", Name = "GetProductByName")]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(IEnumerable<Product>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByName(string name)
        {
            var products = await _repository.GetProductByName(name);

            if (products == null)
            {
                _logger.LogInformation($"Product not found with name {name}.", name);
                return NotFound();
            }

            return Ok(products);
        }
        
        [HttpGet]
        [Route("[action]/{category}", Name = "GetProductByCategory")]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(IEnumerable<Product>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
        {
            var products = await _repository.GetProductByCategory(category);

            if (products == null)
            {
                _logger.LogInformation($"Product not found with name {category}.", category);
                return NotFound();
            }

            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(Product))]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            await _repository.CreateProduct(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }
        
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(Product))]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var result = await _repository.UpdateProduct(product);

            return Ok(result);
        }
        
        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")] 
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(Product))]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var result = await _repository.DeleteProduct(id);

            return Ok(result);
        }
    }
}