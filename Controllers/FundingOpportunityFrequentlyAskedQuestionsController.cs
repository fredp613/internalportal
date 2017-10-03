using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models;
using InternalPortal.Models.Portal.Program;

namespace InternalPortal.Controllers
{
    [Produces("application/json")]
    [Route("api/FundingOpportunityFrequentlyAskedQuestions")]
    public class FundingOpportunityFrequentlyAskedQuestionsController : Controller
    {
        private readonly PortalContext _context;

        public FundingOpportunityFrequentlyAskedQuestionsController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/FundingOpportunityFrequentlyAskedQuestions
        [HttpGet]
        public IEnumerable<FundingOpportunityFrequentlyAskedQuestion> GetFundingOpportunityFrequentlyAskedQuestion()
        {
            return _context.FundingOpportunityFrequentlyAskedQuestion;
        }

        // GET: api/FundingOpportunityFrequentlyAskedQuestions/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FundingOpportunityFrequentlyAskedQuestion), 200)]
        public async Task<IActionResult> GetFundingOpportunityFrequentlyAskedQuestion([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunityFrequentlyAskedQuestion = await _context.FundingOpportunityFrequentlyAskedQuestion.SingleOrDefaultAsync(m => m.FundingOpportunityFrequentlyAskedQuestionId == id);

            if (fundingOpportunityFrequentlyAskedQuestion == null)
            {
                return NotFound();
            }

            return Ok(fundingOpportunityFrequentlyAskedQuestion);
        }

        // PUT: api/FundingOpportunityFrequentlyAskedQuestions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFundingOpportunityFrequentlyAskedQuestion([FromRoute] Guid id, [FromBody] FundingOpportunityFrequentlyAskedQuestion fundingOpportunityFrequentlyAskedQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fundingOpportunityFrequentlyAskedQuestion.FundingOpportunityFrequentlyAskedQuestionId)
            {
                return BadRequest();
            }

            _context.Entry(fundingOpportunityFrequentlyAskedQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundingOpportunityFrequentlyAskedQuestionExists(id))
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

        // POST: api/FundingOpportunityFrequentlyAskedQuestions
        [HttpPost]
        [ProducesResponseType(typeof(FundingOpportunityFrequentlyAskedQuestion), 200)]
        public async Task<IActionResult> PostFundingOpportunityFrequentlyAskedQuestion([FromBody] FundingOpportunityFrequentlyAskedQuestion fundingOpportunityFrequentlyAskedQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FundingOpportunityFrequentlyAskedQuestion.Add(fundingOpportunityFrequentlyAskedQuestion);
            await _context.SaveChangesAsync();

            return Ok(fundingOpportunityFrequentlyAskedQuestion);
        }

        // DELETE: api/FundingOpportunityFrequentlyAskedQuestions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FundingOpportunityFrequentlyAskedQuestion), 200)]
        public async Task<IActionResult> DeleteFundingOpportunityFrequentlyAskedQuestion([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunityFrequentlyAskedQuestion = await _context.FundingOpportunityFrequentlyAskedQuestion.SingleOrDefaultAsync(m => m.FundingOpportunityFrequentlyAskedQuestionId == id);
            if (fundingOpportunityFrequentlyAskedQuestion == null)
            {
                return NotFound();
            }

            _context.FundingOpportunityFrequentlyAskedQuestion.Remove(fundingOpportunityFrequentlyAskedQuestion);
            await _context.SaveChangesAsync();

            return Ok(fundingOpportunityFrequentlyAskedQuestion);
        }

        private bool FundingOpportunityFrequentlyAskedQuestionExists(Guid id)
        {
            return _context.FundingOpportunityFrequentlyAskedQuestion.Any(e => e.FundingOpportunityFrequentlyAskedQuestionId == id);
        }
    }
}