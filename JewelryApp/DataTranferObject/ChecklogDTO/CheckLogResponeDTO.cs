using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranferObject.ChecklogDTO
{
    public class CheckLogResponeDTO
    {
        public int LogId { get; set; }
        public string? Username { get; set; }
        public int? ActivityId { get; set; }
    }
}
