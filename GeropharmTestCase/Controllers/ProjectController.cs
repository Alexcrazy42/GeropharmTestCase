using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeropharmTestCase.Models;
using GeropharmTestCase.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeropharmTestCase.Controllers
{
    [ApiController]
    [Route("[controller]")]
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



        [HttpPost]
        //[Route("UploadFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFile(IFormFile file, CancellationToken cancellationToken)
        {
            var result = await WriteFile(file);
            return Ok(result);
        }

        private async Task<string> WriteFile(IFormFile file)
        {
            string fileName = "";
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = DateTime.Now.Ticks.ToString() + extension;
                string directoryGoDown = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\"));
                //string directoryGoDown = Path.Combine(Directory.GetCurrentDirectory(), "..");
                var filePath = Path.Combine(directoryGoDown, "Upload\\Files");

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                if (Directory.Exists(filePath + fileName))
                {
                    Directory.Delete(filePath + fileName);
                }

                var exactPath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", fileName);
                using (var stream = new FileStream(exactPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

            }
            catch (Exception ex)
            {

            }
            return Directory.GetCurrentDirectory();
        }
    }
}
