// UserContext.cs/Users/paritoshmacbook/Projects/JCPenney/Users/UsersAPI/Data/Users/paritoshmacbook/Projects/JCPenney/Users/UsersAPI/Data/UserContext.csParitosh Tiwaritiwari.paritosh@outlook.comParitosh Tiwari 2021*/UserContext
using System;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Models;

namespace UsersAPI.Data
{
    public class UserContext :DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<UserOrderData> UserBasket { get; set; }
    }
}
