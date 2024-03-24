using DataTranferObject.ProductDTO;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductRepository
{
    public class ProductRepository : IProductRepository
    { 
        private readonly JewelryContext _context;
        public static int PageHome_size { get; set; } = 8;
        public static int PageShop_size { get; set; } = 9;

        public ProductRepository(JewelryContext context) {
            _context = context;
        }

        public void addProduct(ProductRequestDTO product)
        {
            var addProduct = new Product
            {
                Name = product.Name,
                SellPrice = product.SellPrice,
                CategoryId = product.CategoryId,
                InStock = product.InStock,
                Desciption = product.Desciption,
                Detail = product.Detail,
                ImageLink = product.ImageLink,
                MaterialId = product.MaterialId,
            };
            _context.Products.Add(addProduct);
            _context.SaveChanges();

            return;
        }
        public ProductResponeDTO GetByid(int id)
        {
            var item = _context.Products.Include(p => p.Category).Include(m => m.Material).Where(x => x.ProductId == id).ToList();
            return item.Select(x => new ProductResponeDTO
            {
                ProductId = x.ProductId,
                Name = x.Name,
                SellPrice = x.SellPrice,
                CategoryName = x.Category.Name,
                InStock = x.InStock,
                Desciption = x.Desciption,
                Detail = x.Detail,
                ImageLink = x.ImageLink,
                MaterialName = x.Material.Name
            }).FirstOrDefault();
        }
        public void DeleteProduct(int id)
        {
            var  item = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            if(item != null)
            {
                item.Enable=!item.Enable;
            }
            _context.Products.Update(item);
            _context.SaveChanges();
        }

        public List<ProductResponeDTO> GetProductPages(string pagename,string? search, decimal? from, decimal? to, int? categoryID, int? materialID, int page = 1)
        {
            //search
            var list = _context.Products.Include(p => p.Category).Include(m => m.Material).Where(x=>x.Enable==true).ToList().AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Name.Contains(search));
            }
            if (from.HasValue)
            {
                list = list.Where(x => x.SellPrice >= from);
            }
            if (to.HasValue)
            {
                list = list.Where(x => x.SellPrice <= to);
            }
            if (categoryID.HasValue)
            {
                list = list.Where(x => x.CategoryId == categoryID);
            }
            if (materialID.HasValue)
            {
                list = list.Where(x => x.MaterialId == materialID);
            }
            if(pagename.Equals("home"))
            {
                list = list.Skip((page - 1) * PageHome_size).Take(PageHome_size);
            }
            else
            {
                list = list.Skip((page - 1) * PageShop_size).Take(PageShop_size);
            }
          
            var result = list.Select(x => new ProductResponeDTO
            {
                ProductId = x.ProductId,
                Name = x.Name,
                SellPrice = x.SellPrice,
                CategoryName = x.Category.Name,
                InStock = x.InStock,
                Desciption = x.Desciption,
                Detail = x.Detail,
                ImageLink = x.ImageLink,
                MaterialName = x.Material.Name
            }).ToList();
            return result;
        }
        public List<ProductResponeDTO> GetProductPagesNew(string pagename, string? search, decimal? from, decimal? to, int? categoryID, int? materialID)
        {
            //search
            var list = _context.Products.Include(p => p.Category).Include(m => m.Material).Where(x => x.Enable == true).ToList().AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Name.Contains(search));
            }
            if (from.HasValue)
            {
                list = list.Where(x => x.SellPrice >= from);
            }
            if (to.HasValue)
            {
                list = list.Where(x => x.SellPrice <= to);
            }
            if (categoryID.HasValue)
            {
                list = list.Where(x => x.CategoryId == categoryID);
            }
            if (materialID.HasValue)
            {
                list = list.Where(x => x.MaterialId == materialID);
            }
            

            var result = list.Select(x => new ProductResponeDTO
            {
                ProductId = x.ProductId,
                Name = x.Name,
                SellPrice = x.SellPrice,
                CategoryName = x.Category.Name,
                InStock = x.InStock,
                Desciption = x.Desciption,
                Detail = x.Detail,
                ImageLink = x.ImageLink,
                MaterialName = x.Material.Name
            }).ToList();
            return result;
        }

        public void UpdateProduct(ProductRequestDTO product)
        {
            var Uproduct = _context.Products.SingleOrDefault(x => x.ProductId == product.ProductId);
            if (Uproduct == null)
            {
                return;
            }
            Uproduct.Name = product.Name;
            Uproduct.SellPrice = product.SellPrice;
            Uproduct.CategoryId = product.CategoryId;
            Uproduct.InStock = product.InStock;
            Uproduct.Desciption = product.Desciption;
            Uproduct.Detail = product.Detail;
            Uproduct.ImageLink = product.ImageLink;
            Uproduct.MaterialId = product.MaterialId;

            _context.SaveChanges();
        }
        public ProductResponeDTO getProductById(int id)
        {
            var product = _context.Products
                .Include(x => x.Category)
                .Include(x => x.Material)
                .SingleOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                throw new Exception();
            }
            return new ProductResponeDTO
            {
                ProductId = product.ProductId,
                Name = product.Name,
                SellPrice = product.SellPrice,
                CategoryName = product.Category?.Name,
                InStock = product.InStock,
                Desciption = product.Desciption,
                Detail = product.Detail,
                MaterialName = product.Material?.Name,
                ImageLink = product.ImageLink,
            };
        }
    }
}
