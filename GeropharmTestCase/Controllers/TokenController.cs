using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using GeropharmTestCase.Data;
using GeropharmTestCase.Models;

namespace GeropharmTestCase.Controllers
{

    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ApplicationContext _context;

        public TokenController(IConfiguration config)
        {
            _configuration = config;
            _context = new ApplicationContext();
        }


        [HttpPost]
        public async Task<IActionResult> Post(ProjectInfo _projectInfo)
        {
            if (_projectInfo != null && _projectInfo.Name != null && _projectInfo.Description != null)
            {
                var project = await GetProject(_projectInfo.Name, _projectInfo.Description);
                if (project != null)
                {
                    var claims = new Claim[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", project.Id.ToString()),
                        new Claim("Name", project.Name),
                        new Claim("Description", project.Description)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }


        private async Task<Project> GetProject(string projectName, string projectDescription)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.Name == projectName && p.Description == projectDescription);
        }
    }
}
