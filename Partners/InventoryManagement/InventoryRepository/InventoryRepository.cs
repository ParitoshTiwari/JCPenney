// InventoryRepository.cs/Users/paritoshmacbook/Projects/JCPenney/Partners/InventoryManagement/InventoryRepository/Users/paritoshmacbook/Projects/JCPenney/Partners/InventoryManagement/InventoryRepository/InventoryRepository.csParitosh Tiwaritiwari.paritosh@outlook.comParitosh Tiwari 2021*/InventoryRepository
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Data;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.InventoryRepository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly InventoryContext context;

        public InventoryRepository(InventoryContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<ProductInfo>> AddProducts(ProductInfo productsInfo)
        {
            context.Products.Add(productsInfo);
            try
            {
                await context.SaveChangesAsync().ConfigureAwait(false);
                return await context.Products.FindAsync(productsInfo.ProductId);
            }
            catch (DbUpdateException)
            {
                if (!ProductExist(productsInfo.ProductId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<ActionResult<ProductInfo>> ChangeProductDescription(string productId, ProductInfo productInfo)
        {
            if (productId != productInfo.ProductId)
            {
                return null;
            }

            context.Entry(productInfo).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExist(productId))
                {
                    throw new DbUpdateConcurrencyException();
                }
                else
                {
                    throw;
                }
            }
            return productInfo;
        }

        public async Task<ActionResult<ProductInfo>> DeleteProduct(string productId)
        {
            var partner = await context.Products.FindAsync(productId);
            if (partner == null)
            {
                throw new Exception();
            }

            context.Products.Remove(partner);
            await context.SaveChangesAsync();
            return partner;
        }

        public async Task<IEnumerable<ProductInfo>> GetAllProducts()
        {
            return await context.Products.ToListAsync().ConfigureAwait(false);
        }

        public async Task<ActionResult<ProductInfo>> GetProducts(string productId)
        {
            var products = await context.Products.FindAsync(productId);
            if (products == null)
            {
                throw new Exception();
            }
            return products;
        }

        public bool ProductExist(string productId)
        {
            return context.Products.Any(x => x.ProductId == productId);
        }
    }
}
