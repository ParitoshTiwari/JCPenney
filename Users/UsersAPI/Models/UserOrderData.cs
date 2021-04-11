// UserOrderData.cs/Users/paritoshmacbook/Projects/JCPenney/Users/UsersAPI/Models/Users/paritoshmacbook/Projects/JCPenney/Users/UsersAPI/Models/UserOrderData.csParitosh Tiwaritiwari.paritosh@outlook.comParitosh Tiwari 2021*/UserOrderData
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersAPI.Models
{
    public class UserOrderData
    {
        [Key]
        [Column("ProductId")]
        [StringLength(10)]
        public string ProductId { get; set; }
        [Column("ProductName")]
        [StringLength(50)]
        public string ProductName { get; set; }
        [Column("ProductQuantity")]
        [StringLength(10)]
        public string ProductQuantity { get; set; }
        [Column("ProductPrice")]
        [StringLength(10)]
        public string ProductPrice { get; set; }
    }
}
