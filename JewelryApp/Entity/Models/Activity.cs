using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Activity
    {
        public Activity()
        {
            CheckLogs = new HashSet<CheckLog>();
        }

        public int ActivityId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<CheckLog> CheckLogs { get; set; }
    }
}
