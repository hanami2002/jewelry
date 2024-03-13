using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace API
{
    public class AccountRepository
    {
        UserManager<Account> _userManager;
        SignInManager<Account> _signInManager;
        IConfiguration _config;

        public AccountRepository(UserManager<Account> userManager, SignInManager<Account> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        
        public async Task<IdentityResult> SignUp(SignUpModel model)
        {
            var acc = new Account
            {
                UserName=model.Username
            };
            return await _userManager.CreateAsync(acc,model.Password);
        }
    }
}
