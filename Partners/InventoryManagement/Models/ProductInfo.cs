// ProductInfo.cs/Users/paritoshmacbook/Projects/JCPenney/Partners/InventoryManagement/Data/Users/paritoshmacbook/Projects/JCPenney/Partners/InventoryManagement/Data/ProductInfo.csParitosh Tiwaritiwari.paritosh@outlook.comParitosh Tiwari 2021*/ProductInfo
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Models
{
    [Table("Products")]
    public class ProductInfo
    {
        [Key]
        [Column("ProductId")]
        [StringLength(10)]
        public string ProductId { get; set; }
        [Column("ProductName")]
        [StringLength(50)]
        public string ProductName { get; set; }
        [Column("ProductDescription")]
        [StringLength(100)]
        public string ProductDescription { get; set; }
        [Column("ProductQuantity")]
        [StringLength(10)]
        public string ProductQuantity { get; set; }
        [Column("ProductPrice")]
        [StringLength(10)]
        public string ProductPrice { get; set; }
    }
}
