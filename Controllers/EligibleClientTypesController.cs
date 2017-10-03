using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models;
using InternalPortal.Models.Portal.Program;
using InternalPortal.Models.Portal.Implementations;

namespace InternalPortal.Controllers
{
    [Produces("application/json")]
    [Route("api/EligibleClientTypes")]
    public class EligibleClientTypesController : Controller
    {
        //private readonly PortalContext _context;

        //public EligibleClientTypesController(PortalContext context)
        //{
        //    _context = context;
        //}

        private readonly PortalContext _context;
        private UnitOfWork _unitOfWork;

        public EligibleClientTypesController(PortalContext context)
        {
            _context = context;
            // string Lang = RouteData.Values["lang"].ToString();
            _unitOfWork = new UnitOfWork(_context, "EN");
        }

        // GET: api/EligibleClientTypes
        [HttpGet]
        public IEnumerable<EligibleClientType> GetEligibleClientType()
        {
            return _unitOfWork.EligibleClientTypes.GetAll();
        }

        [HttpGet]
        [Route("GetEligibleClientTypeList")]
        public IEnumerable<ClientTypeStatic> GetEligibleClientTypeList()
        {
            return _unitOfWork.EligibleClientTypes.GetEligibleClientTypeList();
        }

        [HttpGet]
        [Route("GetEligibleClientType/{id}")]
        public ClientTypeStatic GetEligibleClientTypeStatic([FromRoute] int id)
        {
            return _unitOfWork.EligibleClientTypes.GetEligibleClientType(id);
        }

        // GET: api/EligibleClientTypes/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EligibleClientType), 200)]
        public async Task<IActionResult> GetEligibleClientType([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eligibleClientType = await _unitOfWork.EligibleClientTypes.GetAsync(id);

            if (eligibleClientType == null)
            {
                return NotFound();
            }

            return Ok(eligibleClientType);
        }

        // PUT: api/EligibleClientTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEligibleClientType([FromRoute] Guid id, [FromBody] EligibleClientType eligibleClientType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eligibleClientType.EligibleClientTypeId)
            {
                return BadRequest();
            }

            _context.Entry(eligibleClientType).State = EntityState.Modified;
            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EligibleClientTypeExists(id))
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

        // POST: api/EligibleClientTypes
        [HttpPost]
        public async Task<IActionResult> PostEligibleClientType([FromBody] EligibleClientType eligibleClientType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.EligibleClientTypes.Add(eligibleClientType);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetEligibleClientType", new { id = eligibleClientType.EligibleClientTypeId }, eligibleClientType);
        }

        // DELETE: api/EligibleClientTypes/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EligibleClientType), 200)]
        public async Task<IActionResult> DeleteEligibleClientType([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eligibleClientType = await _context.EligibleClientType.SingleOrDefaultAsync(m => m.EligibleClientTypeId == id);
            if (eligibleClientType == null)
            {
                return NotFound();
            }

            _unitOfWork.EligibleClientTypes.Remove(eligibleClientType);
            await _unitOfWork.SaveChangesAsync();

            return Ok(eligibleClientType);
        }

        private bool EligibleClientTypeExists(Guid id)
        {
            return _context.EligibleClientType.Any(e => e.EligibleClientTypeId == id);
        }
    }
}