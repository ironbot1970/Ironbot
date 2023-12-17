using System.Threading.Tasks;
using irobotservice.Models;
using Microsoft.AspNetCore.Mvc;

namespace irobotservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRobotRepository _robotRepository;

        public UserController(IRobotRepository robotRepository)
        {
            _robotRepository = robotRepository;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<User>> Login([FromBody] LoginInfo loginInfo)
        {
            var user = await _robotRepository.GetUserByEmailAndPasswordAsync(loginInfo.Email, loginInfo.Password);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<bool>> Register([FromBody] RegistrationInfo registrationInfo)
        {
            var result = await _robotRepository.RegisterUserAsync(registrationInfo);

            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}