using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.InventoryRepository;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InventoryManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryManagement : ControllerBase
    {
        //Added Inventory Management
        private readonly IInventoryRepository _repository;

        public InventoryManagement(IInventoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductInfo>> Get()
        {
            return await _repository.GetAllProducts();
        }

        [HttpPost]
        public async Task<ActionResult<ProductInfo>> CreateProduct(ProductInfo productInfo)
        {
            if (productInfo is null)
                return BadRequest(new ArgumentNullException());
            try
            {
                return await _repository.AddProducts(productInfo);
            }
            catch (Exception)
            {
                return Conflict();
            }

        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductInfo>> GetProduct(string productId)
        {
            try
            {
                return await _repository.GetProducts(productId).ConfigureAwait(false);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{productId}")]
        public async Task<ActionResult<ProductInfo>> EditProductDetails(string productId, ProductInfo productInfo)
        {
            try
            {
                return await _repository.ChangeProductDescription(productId, productInfo);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            catch
            {
                return NoContent();
            }
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult<ProductInfo>> RemoveProduct(string productId)
        {
            try
            {
                return await _repository.DeleteProduct(productId);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
