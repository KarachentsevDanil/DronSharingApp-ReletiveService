using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using RCS.BLL.Dto.Customers;
using RCS.BLL.Services.Contracts;
using RCS.WebApi.Authentication;
using RCS.WebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RCS.Domain.Params;

namespace RCS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<Domain.Users.User> _userManager;
        private readonly SignInManager<Domain.Users.User> _signInManager;
        private readonly IUserService _customerService;
        private readonly IResidentContactService _residentContactService;

        public AccountController(
            UserManager<Domain.Users.User> userManager,
            SignInManager<Domain.Users.User> signInManager,
            IUserService customerService,
            IResidentContactService residentContactService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _customerService = customerService;
            _residentContactService = residentContactService;
        }


        [HttpGet]
        public IActionResult GetMyContacts(string userId)
        {
            var contacts = _residentContactService.GetResidentContactsByParams(new ResidentContactsFilterParams
            {
                UserId = userId
            });

            return Json(JsonResultData.Success(contacts));
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var token = GenerateToken(model.Email);
                var user = _customerService.GetCustomerByTerm(model.Email);

                return Json(new { user, token, tokenExpireData = DateTime.Now.AddDays(1) });
            }

            return Json(JsonResultData.Error("Username or password isn't correct."));
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto data)
        {
            if (ModelState.IsValid)
            {
                var user = new Domain.Users.User
                {
                    UserName = data.Email,
                    Email = data.Email,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    FacilityId = data.FacilityId,
                    DoctorId = data.DoctorId,
                    DateOfBirthsday = data.DateOfBirthsday,
                    Role = data.Role
                };

                var result = await _userManager.CreateAsync(user, data.Password);

                if (result.Succeeded)
                {
                    return Json(JsonResultData.Success());
                }
            }

            return Json(JsonResultData.Error("User already exists."));
        }

        [HttpPost]
        public IActionResult GetUsers([FromBody] UsersFilterParams filterParams)
        {
            var users = _customerService.GetCustomers(filterParams);
            return Json(JsonResultData.Success(users));
        }

        private string GenerateToken(string username)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    AuthenticationOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
