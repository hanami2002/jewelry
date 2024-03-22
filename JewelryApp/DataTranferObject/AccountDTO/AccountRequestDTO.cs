﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranferObject.AccountDTO
{
    public class AccountRequestDTO
    {
        public string UserName { get; set; }
        public string Hashpass { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
        public string Address { get; set; }
        public string Fullname { get; set; }

        public string Phone { get; set; }
    }
}
