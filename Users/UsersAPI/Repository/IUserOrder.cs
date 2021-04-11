// IUserOrder.cs/Users/paritoshmacbook/Projects/JCPenney/Users/UsersAPI/Repository/Users/paritoshmacbook/Projects/JCPenney/Users/UsersAPI/Repository/IUserOrder.csParitosh Tiwaritiwari.paritosh@outlook.comParitosh Tiwari 2021*/IUserOrder
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Models;

namespace UsersAPI.Repository
{
    public interface IUserOrder
    {
        public Task<IEnumerable<UserOrderData>> GetAllData();
        public Task<ActionResult<UserOrderData>> GetProducts(string productId);
        public Task<ActionResult<UserOrderData>> AddProducts(UserOrderData productInfo);
        public Task<ActionResult<UserOrderData>> DeleteProduct(string productId);
        public bool ProductExist(string productId);
    }
}
