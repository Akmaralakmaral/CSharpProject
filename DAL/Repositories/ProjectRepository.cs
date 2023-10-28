
using DAL.Context;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;
namespace DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public void GetAll()
        {
            var projects = _context.Projects.ToList();
        }

    }
}
