﻿using DataTranferObject.AccountDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services.AccountRepository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        //private readonly IProductRepository _productRepository;
        private readonly JewelryContext jewelryContext;

        public AccountController(IAccountRepository accountRepository, JewelryContext jewelryContext)
        {
            _accountRepository = accountRepository;
            this.jewelryContext = jewelryContext;
        }

        

        [HttpPost("SignUp")]
        
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            var result = await _accountRepository.SignUp(signUpModel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return StatusCode(500);
        }

        [HttpPost("SignIn")]

        public async Task<IActionResult> SignIn(SignIn signInModel)
        {
            var result = await _accountRepository.SignIn(signInModel);
            if (string.IsNullOrEmpty(result.Token))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}