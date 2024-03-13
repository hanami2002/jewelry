using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranferObject.AccountDTO
{
    public class AccountResponeDTO
    {
        public string UserName {  get; set; }
        public string Hashpass { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string Phone { get; set; }
       
    }
}
