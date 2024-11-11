using APDS3.Server.services;
using Microsoft.AspNetCore.Mvc;

namespace APDS3.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly PasswordHasherService _passwordHasherService;

        public AccountController(PasswordHasherService passwordHasherService)
        {
            _passwordHasherService = passwordHasherService;
        }

        // Endpoint for user registration
        [HttpPost("register")]
        public IActionResult Register(string username, string password)
        {
            // Hash the password
            var hashedPassword = _passwordHasherService.HashPassword(password);

            // Store the hashed password in the database (database code omitted)
            // SaveUserToDatabase(username, hashedPassword);

            return Ok("User registered with hashed password.");
        }

        // Endpoint for user login
        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            // Retrieve the stored hashed password for the user from the database
            // var storedHashedPassword = GetUserHashedPasswordFromDatabase(username);

            // Simulated hashed password retrieval for example purposes
            var storedHashedPassword = _passwordHasherService.HashPassword("examplePassword");

            // Verify the password
            var isPasswordValid = _passwordHasherService.VerifyPassword(storedHashedPassword, password);
            if (isPasswordValid)
            {
                return Ok("Login successful.");
            }
            return Unauthorized("Invalid password.");
        }
    }
}
