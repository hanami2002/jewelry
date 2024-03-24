using DataTranferObject.AccountDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services.AccountRepository;
using System.Text;
using System;
using Microsoft.AspNetCore.Identity;
using Entities.Models;
using Utilities;

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
        public class ChangePassword
        {
            public string Username { get; set; }
            public string OldPassword { get; set; }
            public string NewPassword { get; set; }

        }
        [HttpPut("ChangePass")]
        public async Task<IActionResult> ChangePass(ChangePassword changePassword)
        {
            try
            {
                var check = await _accountRepository.ChangePassword(changePassword.Username, changePassword.OldPassword, changePassword.NewPassword);
                return Ok(check);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest();

        }
        public class ResetPassword
        {
            public string Username { get; set; }
            public string Email { get; set; }

        }

        [HttpPost("ResetPass")]
        public async Task<ActionResult> ResetPass(ResetPassword resetPasswordModel)
        {
            try
            {
                // Generate a random password
                string newPassword = GenerateRandomString(8);

                // Reset the password
                bool resetSuccessful = await _accountRepository.Reset(resetPasswordModel.Username, resetPasswordModel.Email, newPassword);

                if (resetSuccessful)
                {
                    EmailServices emailServices = new EmailServices();
                    EmailMessage emailSetting= new EmailMessage();
                    emailSetting.Content = "Mat khau cua ban duoc reset la: " + newPassword;
                    emailSetting.To = resetPasswordModel.Email;
                    emailSetting.Subject = "Thay doi mat khau";
                    await emailServices.SendAsync(emailSetting);
                    return Ok($"Password reset successfully. New password: {newPassword}");
                }
                else
                {
                    return BadRequest("Failed to reset password. Please check your username and email.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        private string GenerateRandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }
            return result.ToString();
        }

    }
}
