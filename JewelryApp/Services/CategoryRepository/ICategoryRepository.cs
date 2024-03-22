using DataTranferObject.CategoryDTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CategoryRepository
{
    public interface ICategoryRepository
    {
        public List<CategoryResponeDTO> GetAll(string code);

        public CategoryResponeDTO GetById(int id);
        public void Create(CategoryRequestDTO category);
        public void Update(CategoryRequestDTO category);
        public void Delete(int id);

    }
}
