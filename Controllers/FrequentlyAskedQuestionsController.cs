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
    [Route("api/FrequentlyAskedQuestions")]
    public class FrequentlyAskedQuestionsController : Controller
    {
        private readonly PortalContext _context;

        public FrequentlyAskedQuestionsController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/FrequentlyAskedQuestions
        [HttpGet]
        public IEnumerable<FrequentlyAskedQuestion> GetFrequentlyAskedQuestion()
        {
            return _context.FrequentlyAskedQuestion;
        }

        // GET: api/FrequentlyAskedQuestions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFrequentlyAskedQuestion([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var frequentlyAskedQuestion = await _context.FrequentlyAskedQuestion.SingleOrDefaultAsync(m => m.FrequentlyAskedQuestionId == id);

            if (frequentlyAskedQuestion == null)
            {
                return NotFound();
            }

            return Ok(frequentlyAskedQuestion);
        }

        // PUT: api/FrequentlyAskedQuestions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFrequentlyAskedQuestion([FromRoute] Guid id, [FromBody] FrequentlyAskedQuestion frequentlyAskedQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != frequentlyAskedQuestion.FrequentlyAskedQuestionId)
            {
                return BadRequest();
            }

            _context.Entry(frequentlyAskedQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FrequentlyAskedQuestionExists(id))
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

        // POST: api/FrequentlyAskedQuestions
        [HttpPost]
        public async Task<IActionResult> PostFrequentlyAskedQuestion([FromBody] FrequentlyAskedQuestion frequentlyAskedQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FrequentlyAskedQuestion.Add(frequentlyAskedQuestion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFrequentlyAskedQuestion", new { id = frequentlyAskedQuestion.FrequentlyAskedQuestionId }, frequentlyAskedQuestion);
        }

        // DELETE: api/FrequentlyAskedQuestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFrequentlyAskedQuestion([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var frequentlyAskedQuestion = await _context.FrequentlyAskedQuestion.SingleOrDefaultAsync(m => m.FrequentlyAskedQuestionId == id);
            if (frequentlyAskedQuestion == null)
            {
                return NotFound();
            }

            _context.FrequentlyAskedQuestion.Remove(frequentlyAskedQuestion);
            await _context.SaveChangesAsync();

            return Ok(frequentlyAskedQuestion);
        }

        private bool FrequentlyAskedQuestionExists(Guid id)
        {
            return _context.FrequentlyAskedQuestion.Any(e => e.FrequentlyAskedQuestionId == id);
        }
    }
}