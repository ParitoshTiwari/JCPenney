// PartnerInformation.cs/Users/paritoshmacbook/Projects/JCPenney/PartnerAPI/Models/Users/paritoshmacbook/Projects/JCPenney/PartnerAPI/Models/PartnerInformation.csParitosh Tiwaritiwari.paritosh@outlook.comParitosh Tiwari 2021*/PartnerInformation
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartnerAPI.Models
{
    [Table("PartnerInfo")]
    public class PartnerInformation
    {
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Key]
        [Column("emailId")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("phoneNum")]
        [StringLength(10)]
        public string PhoneNum { get; set; }
    }
}
