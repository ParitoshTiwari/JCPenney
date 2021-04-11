using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UsersAPI.Models;
using UsersAPI.Repository;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserOrder _repository;

        public UsersController(IUserOrder repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<UserOrderData>> Get()
        {
            return await _repository.GetAllData();
        }

        [HttpPost]
        public async Task<ActionResult<UserOrderData>> CreateProduct(UserOrderData productInfo)
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
        public async Task<ActionResult<UserOrderData>> GetProduct(string productId)
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


        [HttpDelete("{productId}")]
        public async Task<ActionResult<UserOrderData>> RemoveProduct(string productId)
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
