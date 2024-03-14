using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranferObject.MaterialDTO
{
    public class MaterialRequestDTO
    {
        public int MaterialId { get; set; }
        public string Name { get; set; }
        public Material ToEntity()
        {
            return new Material { MaterialId = MaterialId, Name = Name };
        }
    }
}
