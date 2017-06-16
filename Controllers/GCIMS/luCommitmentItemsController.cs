using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models;

namespace InternalPortal.Controllers.GCIMS
{
    [Produces("application/json")]
    [Route("api/luCommitmentItems")]
    public class luCommitmentItemsController : Controller
    {
        private readonly GcimsContext _context;

        public luCommitmentItemsController(GcimsContext context)
        {
            _context = context;
        }

        // GET: api/luCommitmentItems
        [HttpGet]
        public IEnumerable<luCommitmentItems> GetluCommitmentItems()
        {
            return _context.luCommitmentItems;
        }

        // GET: api/luCommitmentItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetluCommitmentItems([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var luCommitmentItems = await _context.luCommitmentItems.SingleOrDefaultAsync(m => m.CommitmentItemID == id);

            if (luCommitmentItems == null)
            {
                return NotFound();
            }

            return Ok(luCommitmentItems);
        }
    }
}