using Microsoft.AspNetCore.Identity;
using System;
    using System.Collections.Generic;

    namespace Entities.Models
    {
        public  class Account : IdentityUser
        {
            public Account()
            {
                CheckLogs = new HashSet<CheckLog>();
                Orders = new HashSet<Order>();
            }

            public DateTime? Dob { get; set; }
            public string? Address { get; set; }


            public virtual ICollection<CheckLog> CheckLogs { get; set; }
            public virtual ICollection<Order> Orders { get; set; }
        }
    }
