using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models;
using InternalPortal.Models.Portal;
using System.Diagnostics;
using InternalPortal.Models.Portal.Program;
using InternalPortal.Models.Portal.Implementations;

namespace InternalPortal.Controllers
{
    [Produces("application/json")]
    [Route("api/{lang}/FundingOpportunities")]
    public class FundingOpportunitiesController : Controller
    {
        private readonly PortalContext _context;
        private UnitOfWork _unitOfWork;

       

        //public FundingOpportunitiesController(PortalContext context)
        //{
        //    _context = context;
        //}

        public FundingOpportunitiesController(PortalContext context)
        {
            _context = context;
           // string Lang = RouteData.Values["lang"].ToString();
            _unitOfWork = new UnitOfWork(_context, "EN");
        }

        // GET: api/FundingOpportunities
        [HttpGet]
        public IEnumerable<FundingOpportunity> GetFundingOpportunity()
        {
            return _unitOfWork.FundingOpportunities.GetAll();
        }

        // GET: api/FundingOpportunities/GetActiveFundingOpportunities
        [HttpGet]
        [Route("GetActiveFundingOpportunities")]
        public IEnumerable<FundingOpportunity> GetActiveFundingOpportunities()
        {
            return _unitOfWork.FundingOpportunities.GetActiveFundingOpportunities();           

        }

        [HttpGet]
        [Route("GetActiveFundingOpportunitiesWithRelationshipsCollapsed")]
        public IEnumerable<FundingOpportunity> GetActiveFundingOpportunitiesWithRelationshipsCollapsed()
        {
            return _unitOfWork.FundingOpportunities.GetActiveFundingOpportunitiesCollapsedRelationships();

        }

        // GET: api/en/FundingOpportunities/5
        [HttpGet("{id}")]
     
        public async Task<IActionResult> GetFundingOpportunity([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var fundingOpportunity = await _unitOfWork.FundingOpportunities.GetAsync(id);
            var fundingOpportunity = await _unitOfWork.FundingOpportunities.GetActiveFundingOpportunityCollapsedRelationships(id);

            if (fundingOpportunity == null)
            {
                return NotFound();
            }

            return Ok(fundingOpportunity);
        }

        // PUT: api/FundingOpportunities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFundingOpportunity([FromRoute] Guid id, [FromBody] FundingOpportunity fundingOpportunity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fundingOpportunity.FundingOpportunityId)
            {
                return BadRequest();
            }

            _unitOfWork.FundingOpportunities.Update(fundingOpportunity);
           

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_unitOfWork.FundingOpportunities.FundingOpportunityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FundingOpportunities
        [HttpPost]
        public async Task<IActionResult> PostFundingOpportunity([FromBody] FundingOpportunity fundingOpportunity)
        {
            
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.FundingOpportunities.Add(fundingOpportunity);
            await _unitOfWork.SaveChangesAsync();

           
            //  return CreatedAtAction("GetFundingOpportunity", new { id = fundingOpportunity.FundingOpportunityId }, fundingOpportunity);
            //return Ok(fundingOpportunity);
           
            return Ok(fundingOpportunity);
        }

        // DELETE: api/FundingOpportunities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFundingOpportunity([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunity = await _unitOfWork.FundingOpportunities.GetAsync(id);
            if (fundingOpportunity == null)
            {
                return NotFound();
            }

            _context.FundingOpportunity.Remove(fundingOpportunity);
            await _unitOfWork.SaveChangesAsync();

            return Ok(fundingOpportunity);
        }

      
    }
}