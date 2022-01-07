using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System.Threading.Tasks;

namespace NewChallengeIterplayersApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;
        public PasswordController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAnnouncement([FromBody] string password)
        {
            if (password == null)
            {
                return BadRequest();
            }

            var obj = await _passwordService.RegisterPassword(password);
            return Ok(obj);

        }
    }
}
