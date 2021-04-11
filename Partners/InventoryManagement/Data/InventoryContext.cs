// InventoryContext.cs/Users/paritoshmacbook/Projects/JCPenney/Partners/InventoryManagement/Data/Users/paritoshmacbook/Projects/JCPenney/Partners/InventoryManagement/Data/InventoryContext.csParitosh Tiwaritiwari.paritosh@outlook.comParitosh Tiwari 2021*/InventoryContext
using System;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
        }

        public DbSet<ProductInfo> Products { get; set; }
    }
}
