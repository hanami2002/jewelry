using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranferObject.CategoryDTO
{
    public class CategoryRequestDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public Category ToEntity()
        {
            return new Category { CategoryId = CategoryId, Name = Name };
        }
    }
}
