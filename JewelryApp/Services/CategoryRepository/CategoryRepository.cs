using DataTranferObject.CategoryDTO;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly JewelryContext context;

        public CategoryRepository(JewelryContext context)
        {
            this.context = context;
        }

        public void Create(CategoryRequestDTO category)
        {
            var newCategory = new Category
            {CategoryId=category.CategoryId,
                Name = category.Name,
                Enable=true,
                Image=category.Image
                
            };

            context.Categories.Add(newCategory);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var categoryToDelete = context.Categories.FirstOrDefault(x=>x.CategoryId==id);
            if (categoryToDelete != null)
            {
                categoryToDelete.Enable=!categoryToDelete.Enable;
                context.Categories.Update(categoryToDelete);
                context.SaveChanges();
            }
        }

        public List<CategoryResponeDTO> GetAll(string code)
        {
            if(code.Equals("all"))
            {
                return context.Categories.Include(x=>x.Products).Select(x => new CategoryResponeDTO
                {
                    CategoryId = x.CategoryId,
                    Name = x.Name,
                    Image=x.Image,
                    NumberProduct=x.Products.Count()
                }).ToList();
            }else {
                return context.Categories.Select(x => new CategoryResponeDTO
                {
                    CategoryId = x.CategoryId,
                    Name = x.Name,
                    Image = x.Image,
                    NumberProduct = x.Products.Count()
                }).Take(6).ToList();
            }
            
        }

        public CategoryResponeDTO GetById(int id)
        {
            var category = context.Categories.Select(x=>new CategoryResponeDTO
            {
                CategoryId = x.CategoryId,
                Name = x.Name
            }
           ).Where(x=>x.CategoryId==id).FirstOrDefault();
            return category;
        }
     

        public void Update(CategoryRequestDTO category)
        {
            var existingCategory = context.Categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);

            if (existingCategory == null)
            {
                // Handle the case where the category with the specified ID is not found
                throw new InvalidOperationException("Category not found");
            }

            // Update the existing category entity with the values from the CategoryRequestDTO
            existingCategory.Name = category.Name;
            existingCategory.Image = category.Image;
            context.Categories.Update(existingCategory);
 
            context.SaveChanges();
        }
    }
}
