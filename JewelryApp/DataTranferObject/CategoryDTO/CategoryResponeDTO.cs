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
        public CategoryResponeDTO ToDTO(Category category)
        {
            return new CategoryResponeDTO { CategoryId = category.CategoryId, Name = category.Name };
        }
    }
}
