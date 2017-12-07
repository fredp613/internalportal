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
    [Route("api/Countries")]
    public class CountriesController : Controller
    {
        private readonly PortalContext _context;

        public CountriesController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/Countries
        [HttpGet]
        public IEnumerable<Country> GetCountry()
        {
            return _context.Country;
        }

      
    }
}