using EmsBusiness.Services;
using EmsEntity;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Threading.Tasks;

namespace EMS_SprintProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly LoginService _loginService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        /// <param name="loginService">The login service.</param>
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
            _logger.Info("LoginController Constructor");
        }

        /// <summary>
        /// Handles the HTTP POST request for user login.
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <param name="password">The user password.</param>
        /// <param name="UserType">The user type.</param>
        /// <returns>An asynchronous task that represents the HTTP action result containing the authenticated user information.</returns>
        [HttpPost]
        public async Task<ActionResult<User_Master>> Login(string id, string password, string UserType)
        {
            try
            {
                _logger.Info("Login method entered");
                var user = await _loginService.Authenticate(id, password, UserType);

                if (user == null)
                {
                    _logger.Error("Login failed - Invalid username or password");
                    return Unauthorized("Invalid username or password");
                }

                _logger.Info("Login successful");
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in Login method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }
    }
}
