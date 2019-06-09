using System;
using System.Collections.Generic;
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
using RCS.Domain.Facilities;
using RCS.Domain.Params;
using RCS.Domain.Residents;
using RCS.Domain.Users;

namespace RCS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService _customerService;
        private readonly IResidentContactService _residentContactService;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
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
                var user = _customerService.GetCustomerByTerm(model.Email);
                var token = GenerateToken(user);

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

        private string GenerateToken(UserDto user)
        {
            var claims = new List<Claim>
            {
                new Claim(nameof(UserDto.UserId), user.UserId),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            if (user.FacilityId.HasValue)
            {

                claims.Add(new Claim(nameof(UserDto.FacilityId), user.FacilityId.Value.ToString()));
            }

            if (user.DoctorId.HasValue)
            {
                claims.Add(new Claim(nameof(UserDto.DoctorId), user.DoctorId.Value.ToString()));
            }

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    AuthenticationOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
