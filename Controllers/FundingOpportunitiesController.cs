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

namespace InternalPortal.Controllers
{
    [Produces("application/json")]
    [Route("api/FundingOpportunities")]
    public class FundingOpportunitiesController : Controller
    {
        private readonly PortalContext _context;

        public FundingOpportunitiesController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/FundingOpportunities
        [HttpGet]
        public IEnumerable<FundingOpportunity> GetFundingOpportunity()
        {
            return _context.FundingOpportunity;
        }

        // GET: api/FundingOpportunities/GetActiveFundingOpportunities
        [HttpGet]
        [Route("GetActiveFundingOpportunities")]
        public IEnumerable<FundingOpportunity> GetActiveFundingOpportunities()
        {
            
            var fos = _context.FundingOpportunity.Where(f => f.ActivationStartDate <= DateTime.Now.Date).ToList();

            foreach (var x in fos)
            {
                var test = new List<object>();
                string test1 = "";
                var criterias = new List<EligibilityCriteria>();
                var foec = _context.FundingOpportunityEligibilityCriteria.Where(g => g.FundingOpportunityId == x.FundingOpportunityId)
                                        .Include(y=>y.EligibilityCriteria).ToList();
                foreach (var y in foec)
                {
                    //criterias.Add(y.EligibilityCriteria);
                    test.Add(new {
                        DescriptionE = y.EligibilityCriteria.DescriptionE
                    });
                    test1 += y.EligibilityCriteria.DescriptionE + ";&#010;&#013;&#010;";
                }
                x.Criterias1 = test1;
                x.Criterias = test;
                
            }            


            return fos;
        }

        // GET: api/FundingOpportunities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFundingOpportunity([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var language = RouteData.Values["lang"] as string;
            Debug.WriteLine(language);
            var fundingOpportunity = await _context.FundingOpportunity.SingleOrDefaultAsync(m => m.FundingOpportunityId == id);

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

            _context.Entry(fundingOpportunity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundingOpportunityExists(id))
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

            _context.FundingOpportunity.Add(fundingOpportunity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFundingOpportunity", new { id = fundingOpportunity.FundingOpportunityId }, fundingOpportunity);
        }

        // DELETE: api/FundingOpportunities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFundingOpportunity([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunity = await _context.FundingOpportunity.SingleOrDefaultAsync(m => m.FundingOpportunityId == id);
            if (fundingOpportunity == null)
            {
                return NotFound();
            }

            _context.FundingOpportunity.Remove(fundingOpportunity);
            await _context.SaveChangesAsync();

            return Ok(fundingOpportunity);
        }

        private bool FundingOpportunityExists(Guid id)
        {
            return _context.FundingOpportunity.Any(e => e.FundingOpportunityId == id);
        }
    }
}