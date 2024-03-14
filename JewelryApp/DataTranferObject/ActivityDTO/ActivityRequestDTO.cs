using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranferObject.ActivityDTO
{
    public class ActivityRequestDTO
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public Activity ToEntity()
        {
            return new Activity { ActivityId = ActivityId, Name = Name };
        }
    }
}
