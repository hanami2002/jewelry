using API;
using DataTranferObject.AccountDTO;
using DataTranferObject.RoleDTO;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.AccountRepository
{
    public class AccountRepository : IAccountRepository
    {
        UserManager<Account> _userManager;
        SignInManager<Account> _signInManager;
        IConfiguration _config;
        RoleManager<IdentityRole> _roleManager;

        public AccountRepository(UserManager<Account> userManager, SignInManager<Account> signInManager, IConfiguration config, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _roleManager = roleManager;
        }

        public async Task<string> SignIn(SignIn model)
        {
            var user= await _userManager.FindByNameAsync(model.Username);
            var checkPass= await _userManager.CheckPasswordAsync(user, model.Password);
            if(user == null || !checkPass)
            {
                return string.Empty;
            }

            //var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password,  false,false);
            //if (!result.Succeeded) {
            //return string.Empty;
            //    }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,model.Username),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var userRoles= await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(authenKey,SecurityAlgorithms.HmacSha256)
             );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUp(SignUpModel model)
        {

            var acc = new Account
            {
                UserName = model.Username,
                Dob = model.Dob,
                Fulllname=model.FirstName+" "+model.LastName,
                PhoneNumber=model.Phone,
                Address = model.Address
            };
             var result= await _userManager.CreateAsync(acc, model.Password);
            if (result.Succeeded)
            {
                if(!await _roleManager.RoleExistsAsync(Role.Customer))
                {
                    await _roleManager.CreateAsync(new IdentityRole(Role.Customer));
                }
                await _userManager.AddToRoleAsync(acc, Role.Customer);
            }
            return result;
        }
    }
}
