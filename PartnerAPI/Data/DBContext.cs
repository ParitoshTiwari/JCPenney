// DBContext.cs/Users/paritoshmacbook/Projects/JCPenney/PartnerAPI/Data/Users/paritoshmacbook/Projects/JCPenney/PartnerAPI/Data/DBContext.csParitosh Tiwaritiwari.paritosh@outlook.comParitosh Tiwari 2021*/DBContext
using System;
using Microsoft.EntityFrameworkCore;
using PartnerAPI.Models;

namespace PartnerAPI.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<PartnerInformation> PartnerInfo { get; set; }
    }
}
