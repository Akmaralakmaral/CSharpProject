
using DAL.Context;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        AppDbContext _context;

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
