// PartnerInfoRepository.cs/Users/paritoshmacbook/Projects/JCPenney/PartnerAPI/Repository/Users/paritoshmacbook/Projects/JCPenney/PartnerAPI/Repository/PartnerInfoRepository.csParitosh Tiwaritiwari.paritosh@outlook.comParitosh Tiwari 2021*/PartnerInfoRepository
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartnerAPI.Data;
using PartnerAPI.Models;

namespace PartnerAPI.Repository
{
    public class PartnerInfoRepository : IRepository
    {
        private readonly DBContext context;

        public PartnerInfoRepository(DBContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<PartnerInformation>> AddPartner(PartnerInformation partnerInformation)
        {
            context.PartnerInfo.Add(partnerInformation);
            try
            {
                await context.SaveChangesAsync().ConfigureAwait(false);
                return await context.PartnerInfo.FindAsync(partnerInformation.Email);
            }
            catch(DbUpdateException)
            {
                if (!PartnerExist(partnerInformation.Email))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            
        }

        public async Task<ActionResult<PartnerInformation>> ChangePartnerDetails(string email, PartnerInformation partnerInformation)
        {
            if (email != partnerInformation.Email)
            {
                return null;
            }

            context.Entry(partnerInformation).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnerExist(email))
                {
                    throw new DbUpdateConcurrencyException();
                }
                else
                {
                    throw;
                }
            }
            return partnerInformation;
        }

        public async Task<ActionResult<PartnerInformation>> DeletePartner(string email)
        {
            var partner = await context.PartnerInfo.FindAsync(email);
            if (partner == null)
            {
                throw new Exception();
            }

            context.PartnerInfo.Remove(partner);
            await context.SaveChangesAsync();
            return partner;
        }

        public async Task<IEnumerable<PartnerInformation>> GetAllPartners()
        {
            return await context.PartnerInfo.ToListAsync().ConfigureAwait(false);
        }

        public async Task<ActionResult<PartnerInformation>> GetPartner(string email)
        {
            var partner = await context.PartnerInfo.FindAsync(email);
            if (partner == null)
            {
                throw new Exception();
            }
            return partner;
        }

        public bool PartnerExist(string email)
        {
            return context.PartnerInfo.Any(x => x.Email == email);
        }

    }
}
