using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeropharmTestCase.Models;
using GeropharmTestCase.Data;

namespace GeropharmTestCase.Controllers
{
    [ApiController]
    [Route("projects")]
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ProjectController()
        {
            _context = new ApplicationContext();
        }


        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<object>>> GetAllProjects() // 
        {
            if (_context.Projects == null)
            {
                return NotFound();
            }
            var projects = from p in _context.Projects
                           select new
                           {
                               Id = p.Id,
                               Name = p.Name,
                               Description = p.Description
                           };
            return await projects.ToListAsync();

        }

        [HttpGet]
        public async Task<ActionResult<object>> GetSomeProjects(int firstId, int count)
        {
            if (_context.Projects == null)
            {
                return NotFound();
            }

            var projects = from p in _context.Projects
                           where p.Id >= firstId && p.Id < (firstId + count)
                           select new
                           {
                               Id = p.Id, 
                               Name = p.Name,
                               Descriprion = p.Description
                           };

            if (projects.ToArray().Length == 0)
            {
                return NotFound();
            }

            return await projects.ToListAsync();
        }

    }
}
