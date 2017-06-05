using InternalPortal.Models.Portal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternalPortal.Models.Portal;
using InternalPortal.Models;

namespace InternalPortal.Models.Portal.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly PortalContext _context;
        public IProjectRepository Projects { get; private set; }

        public UnitOfWork(PortalContext context)
        {
            _context = context;
            Projects = new ProjectRepository(_context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
