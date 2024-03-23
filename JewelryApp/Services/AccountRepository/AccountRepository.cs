using API;
using DataTranferObject.AccountDTO;
using DataTranferObject.RoleDTO;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository;
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
        private readonly JewelryContext jewelryContext;

        public AccountRepository(UserManager<Account> userManager, SignInManager<Account> signInManager, IConfiguration config, RoleManager<IdentityRole> roleManager, JewelryContext jewelryContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _roleManager = roleManager;
            this.jewelryContext = jewelryContext;
        }

        public async Task<bool> ChangePassword(string username, string newPassword)
        {
            var account = await  _userManager.FindByNameAsync(username);
            if (account == null)
            {
                return false;
            }
                

            // Update the password hash with the new password
            var token = await _userManager.GeneratePasswordResetTokenAsync(account);
            var result = await _userManager.ResetPasswordAsync(account, token, newPassword);

            return true;
        }

        public  AccountResponeDTO GetAccountById(string username)
        {
            var account  = jewelryContext.Accounts.Where(x=>x.UserName.Equals(username)).FirstOrDefault();
            if (account != null)
            {
                var respone= new AccountResponeDTO()
                {
                    Id= account.Id,
                    UserName=account.UserName,
                    Dob=account.Dob,
                    Address=account.Address,
                    Phone=account.PhoneNumber,
                    Email=account.Email,
                    Fullname=account.Fulllname
                };
                return  respone;
            }
            return null;
        }

        public async Task<LoginResponeDTO> SignIn(SignIn model)
        {
            var user= await _userManager.FindByNameAsync(model.Username);
            var checkPass= await _userManager.CheckPasswordAsync(user, model.Password);
            if(user == null || !checkPass)
            {
                return null;
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
            var result = new LoginResponeDTO
            {
                Username = model.Username,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Role = userRoles[0]
            };
            return result;
        }

        public async Task<IdentityResult> SignUp(SignUpModel model)
        {
            var existingUser = await _userManager.FindByNameAsync(model.Username);
            if (existingUser != null)
            {
                // Return an error message indicating that the username already exists
                var _result = IdentityResult.Failed(new IdentityError { Description = "Username already exists." });
                return _result;
            }

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

        public async Task<bool> UpdateAccountInfo(string username, string fullname, string email, DateTime dob, string address, string phone)
        {
            var account = await jewelryContext.Accounts.Where(x=>x.UserName.Equals(username)).FirstOrDefaultAsync();
            if (account == null)
            {
                return false;
            }
                

            account.Fulllname = fullname;
            account.Dob = dob;
            account.Address = address;
            account.PhoneNumber = phone;

            jewelryContext.Accounts.Update(account);
            await jewelryContext.SaveChangesAsync();

            return true;
        }
    }
}
