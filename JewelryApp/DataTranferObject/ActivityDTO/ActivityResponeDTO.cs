using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranferObject.ActivityDTO
{
    public class ActivityResponeDTO
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public ActivityResponeDTO ToDTO(Activity activity)
        {
            return new ActivityResponeDTO {  ActivityId = activity.ActivityId, Name = activity.Name };        

        }
    }
}
