using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class CheckLog
    {
        public int LogId { get; set; }
        public string? Username { get; set; }
        public int? ActivityId { get; set; }
        public string? Description { get; set; }
        public virtual Activity? Activity { get; set; }
        public virtual Account? UsernameNavigation { get; set; }
    }
}
