using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranferObject.MaterialDTO
{
    public class MaterialResponeDTO
    {
        public int MaterialId { get; set; }
        public string Name { get; set; }
        public MaterialResponeDTO ToDTO(Material material )
        {
            return new MaterialResponeDTO { MaterialId = material.MaterialId, Name = material.Name };
        }
    }
}
