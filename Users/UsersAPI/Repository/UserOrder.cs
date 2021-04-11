// UserOrder.cs/Users/paritoshmacbook/Projects/JCPenney/Users/UsersAPI/Repository/Users/paritoshmacbook/Projects/JCPenney/Users/UsersAPI/Repository/UserOrder.csParitosh Tiwaritiwari.paritosh@outlook.comParitosh Tiwari 2021*/UserOrder
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Data;
using UsersAPI.Models;

namespace UsersAPI.Repository
{
    public class UserOrder : IUserOrder
    {
        private readonly UserContext context;

        public UserOrder(UserContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<UserOrderData>> AddProducts(UserOrderData orderInfo)
        {
            context.UserBasket.Add(orderInfo);
            try
            {
                await context.SaveChangesAsync().ConfigureAwait(false);
                return await context.UserBasket.FindAsync(orderInfo.ProductId);
            }
            catch (DbUpdateException)
            {
                if (!ProductExist(orderInfo.ProductId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<ActionResult<UserOrderData>> DeleteProduct(string productId)
        {
            var orderData = await context.UserBasket.FindAsync(productId);
            if (orderData == null)
            {
                throw new Exception();
            }

            context.UserBasket.Remove(orderData);
            await context.SaveChangesAsync();
            return orderData;
        }

        public async Task<IEnumerable<UserOrderData>> GetAllData()
        {
            return await context.UserBasket.ToListAsync().ConfigureAwait(false);
        }

        public async Task<ActionResult<UserOrderData>> GetProducts(string productId)
        {
            var products = await context.UserBasket.FindAsync(productId);
            if (products == null)
            {
                throw new Exception();
            }
            return products;
        }

        public bool ProductExist(string productId)
        {
            return context.UserBasket.Any(x => x.ProductId == productId);
        }
    }
}
