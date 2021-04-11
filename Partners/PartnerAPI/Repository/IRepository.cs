// IRepository.cs/Users/paritoshmacbook/Projects/JCPenney/PartnerAPI/Repository/Users/paritoshmacbook/Projects/JCPenney/PartnerAPI/Repository/IRepository.csParitosh Tiwaritiwari.paritosh@outlook.comParitosh Tiwari 2021*/IRepository
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartnerAPI.Models;

namespace PartnerAPI.Repository
{
    public interface IRepository
    {
        public Task<IEnumerable<PartnerInformation>> GetAllPartners();
        public Task<ActionResult<PartnerInformation>> GetPartner(string email);
        public Task<ActionResult<PartnerInformation>> AddPartner(PartnerInformation partnerInformation);
        public Task<ActionResult<PartnerInformation>> ChangePartnerDetails(string email, PartnerInformation partnerInformation);
        public Task<ActionResult<PartnerInformation>> DeletePartner(string email);
        public bool PartnerExist(string email);
    }
}
