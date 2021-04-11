using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PartnerAPI.Models;
using PartnerAPI.Repository;

namespace PartnerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PartnersController : ControllerBase
    {
        private readonly IRepository _repository;

        public PartnersController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<PartnerInformation>> Get()
        {
            return await _repository.GetAllPartners();
        }

        [HttpPost]
        public async Task<ActionResult<PartnerInformation>> CreatePartner(PartnerInformation partnerInformation)
        {
            if (partnerInformation is null)
                return BadRequest(new ArgumentNullException());
            try
            {
                return await _repository.AddPartner(partnerInformation);
            }
            catch (Exception)
            {
                return Conflict();
            }
            
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<PartnerInformation>> GetPartner(string email)
        {
            try
            {
                return await _repository.GetPartner(email).ConfigureAwait(false);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{email}")]
        public async Task<ActionResult<PartnerInformation>> EditPartnerDetails(string email, PartnerInformation partnerInformation)
        {
            try
            {
                return await _repository.ChangePartnerDetails(email, partnerInformation);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            catch
            {
                return NoContent();
            }
        }

        [HttpDelete("{email}")]
        public async Task<ActionResult<PartnerInformation>> RemovePartner(string email)
        {
            try
            {
                return await _repository.DeletePartner(email);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
