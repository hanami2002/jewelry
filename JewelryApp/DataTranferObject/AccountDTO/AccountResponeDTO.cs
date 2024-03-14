using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace DataTranferObject.AccountDTO
{
    public class AccountResponeDTO
    {
        public string UserName {  get; set; }
        public string Hashpass { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
        public string Address { get; set; }
        public string Fullname { get; set; }
        
        public string Phone { get; set; }
       
        public AccountResponeDTO ToDTO(Account account)
        {
            return new AccountResponeDTO
            {
                UserName = account.UserName,
                Hashpass = account.PasswordHash,
                Email = account.Email,
                Dob = account.Dob,
                Address = account.Address,
                Fullname = account.Fulllname,
                Phone = account.PhoneNumber
            };
        }
         
    }
}
