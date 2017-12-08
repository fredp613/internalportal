using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models;
using InternalPortal.Models.Portal;

namespace InternalPortal.Controllers
{
    [Produces("application/json")]
    [Route("api/Feedbacks")]
    public class FeedbacksController : Controller
    {
        private readonly PortalContext _context;

        public FeedbacksController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/Feedbacks
        [HttpGet]
        public IEnumerable<Feedback> GetFeedback()
        {
            return _context.Feedback;
        }

        // GET: api/Feedbacks/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Feedback), 200)]
        public async Task<IActionResult> GetFeedback([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feedback = await _context.Feedback.SingleOrDefaultAsync(m => m.FeedbackId == id);

            if (feedback == null)
            {
                return NotFound();
            }

            return Ok(feedback);
        }

        // GET: api/Accounts/5
        [HttpGet("GetByProject/{projectid}")]
        public IEnumerable<Feedback> GetAccountsByContact([FromRoute] Guid projectid)
        {

            return _context.Feedback.Where(p => p.ProjectId == projectid).OrderByDescending(d => d.CreatedOn);
        }

        // PUT: api/Feedbacks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedback([FromRoute] Guid id, [FromBody] Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feedback.FeedbackId)
            {
                return BadRequest();
            }
            feedback.UpdatedOn = DateTime.Now;
            _context.Entry(feedback).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackExists(id))
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

        // POST: api/Feedbacks
        [HttpPost]
        [ProducesResponseType(typeof(Feedback), 200)]
        public async Task<IActionResult> PostFeedback([FromBody] Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(feedback).Property(c => c.CreatedOn).CurrentValue = DateTime.Now;
            _context.Entry(feedback).Property(c=> c.UpdatedOn).CurrentValue = DateTime.Now;
          
            _context.Feedback.Add(feedback);
            await _context.SaveChangesAsync();

            var project = _context.Project.SingleOrDefault(p => p.ProjectId == feedback.ProjectId);
            if (feedback.IsRejection)
            {
                project.ProjectStatus = Status.Rejected;
            } else
            {
                project.ProjectStatus = Status.Incomplete;
            }
           
            _context.Entry(project).Property(s => s.ProjectStatus).IsModified = true;
            _context.SaveChanges();





            return Ok(feedback);
            //return CreatedAtAction("GetFeedback", new { id = feedback.FeedbackId }, feedback);
        }

        // DELETE: api/Feedbacks/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Feedback), 200)]
        public async Task<IActionResult> DeleteFeedback([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feedback = await _context.Feedback.SingleOrDefaultAsync(m => m.FeedbackId == id);
            if (feedback == null)
            {
                return NotFound();
            }

            _context.Feedback.Remove(feedback);
            await _context.SaveChangesAsync();

            return Ok(feedback);
        }

        private bool FeedbackExists(Guid id)
        {
            return _context.Feedback.Any(e => e.FeedbackId == id);
        }
    }
}