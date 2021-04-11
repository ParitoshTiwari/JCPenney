// IInventoryRepository.cs/Users/paritoshmacbook/Projects/JCPenney/Partners/InventoryManagement/InventoryRepository/Users/paritoshmacbook/Projects/JCPenney/Partners/InventoryManagement/InventoryRepository/IInventoryRepository.csParitosh Tiwaritiwari.paritosh@outlook.comParitosh Tiwari 2021*/IInventoryRepository
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.InventoryRepository
{
    public interface IInventoryRepository
    {
        public Task<IEnumerable<ProductInfo>> GetAllProducts();
        public Task<ActionResult<ProductInfo>> GetProducts(string productId);
        public Task<ActionResult<ProductInfo>> AddProducts(ProductInfo productInfo);
        public Task<ActionResult<ProductInfo>> ChangeProductDescription(string productId, ProductInfo productInfo);
        public Task<ActionResult<ProductInfo>> DeleteProduct(string productId);
        public bool ProductExist(string productId);
    }
}
