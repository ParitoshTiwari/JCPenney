// PartnerServiceInterface.cs/Users/paritoshmacbook/Projects/JCPenney/UI/JCPenneyUI/Services/Users/paritoshmacbook/Projects/JCPenney/UI/JCPenneyUI/Services/PartnerServiceInterface.csParitosh Tiwaritiwari.paritosh@outlook.comParitosh Tiwari 2021*/PartnerServiceInterface
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using JCPenneyUI.Data;

namespace JCPenneyUI.Services
{
    public interface IPartnerService
    {
        Task<IEnumerable<PartnerModel>> GetPartners();
        Task<PartnerModel> AddPartners(string name, string email, string phone);
        Task<PartnerModel> EditPartners(string name, string email, string phone, string emailID);
        Task DeletePartner(string email);
    }
}
