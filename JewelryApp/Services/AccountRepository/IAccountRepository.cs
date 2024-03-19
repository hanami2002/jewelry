using API;
using DataTranferObject.AccountDTO;
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
        public Task<string> SignIn(SignIn model);
    }
}
