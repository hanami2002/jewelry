using API;
using DataTranferObject.AccountDTO;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AccountRepository
{
    public interface IAccountRepository
    { public Task<IdentityResult> SignUp(SignUpModel model);
        public Task<LoginResponeDTO> SignIn(SignIn model);
        AccountResponeDTO GetAccountById(string accountId);
        Task<bool> UpdateAccountInfo(string accountId, string fullname,string email, DateTime dob, string address, string phone);
        Task<bool> ChangePassword(string accountId, string oldPassword, string newPassword);
        Task<bool> Reset(string accountId, string email, string newPassword);
    }
}
