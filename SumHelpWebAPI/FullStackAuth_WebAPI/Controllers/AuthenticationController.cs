using AutoMapper;
using FullStackAuth_WebAPI.ActionFilters;
using FullStackAuth_WebAPI.Contracts;
using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using FullStackAuth_WebAPI.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthenticationManager _authManager;
        private readonly ApplicationDbContext _context;
        public AuthenticationController(IMapper mapper, UserManager<User> userManager, IAuthenticationManager authManager, ApplicationDbContext context)
        {
            _mapper = mapper;
            _userManager = userManager;
            _authManager = authManager;
            _context = context;
            
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {

            var user = _mapper.Map<User>(userForRegistration);

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await _userManager.AddToRoleAsync(user, "USER");

            UserModel newAppUser = new()
            {

                Username = user.UserName,
                LastLogin = DateTime.Now,
                RevenueCatUserId = "",
                SubscriptionStatus = "free",


            };
            _context.AppUsers.Add(newAppUser);  
            await _context.SaveChangesAsync();

            UserForDisplayDto createdUser = new()
            {
                Id = user.Id,
                UserName = user.UserName,
                
            };
            return StatusCode(201, createdUser);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody]TokenDto tokenDto)
        {
            if (tokenDto == null)
            {
                return BadRequest("Invalid client request");
            }

            var token = await _authManager.Refresh(tokenDto);

            if (token == null)
            {
                return Unauthorized("Invalid client request");
            }

            return Ok(token);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                return Unauthorized();
            }

            return Ok(new { access = await _authManager.CreateToken() });
        }
    }
}