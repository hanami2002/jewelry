using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranferObject.CategoryDTO
{
    public class CategoryResponeDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int NumberProduct {  get; set; }
        public string? Image { get; set; }
    }
}
