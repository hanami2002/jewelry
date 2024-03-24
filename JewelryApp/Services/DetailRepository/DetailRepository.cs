using DataTranferObject.DetailDTO;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DetailRepository
{
    public class DetailRepository : IDetailRepository
    { 
        private JewelryContext _jewelryContext;

        public DetailRepository(JewelryContext jewelryContext)
        {
            _jewelryContext = jewelryContext;
        }

        public void CreateDetail(DetailRequestDTO detail)
        {           

            var newDetail = new Detail
            {
                OrderId = detail.OrderId,
                Quantity = detail.Quantity,
                Price = detail.Price,
                ProductId = detail.ProductId
            };

            _jewelryContext.Details.Add(newDetail);
            _jewelryContext.SaveChanges();
        }

        public void DeleteDetail(int id)
        {
            var detailToDelete = _jewelryContext.Details.Find(id);
            if (detailToDelete == null)
            {
                throw new ArgumentException($"Detail with id {id} not found");
            }
            _jewelryContext.Details.Remove(detailToDelete);
            _jewelryContext.SaveChanges();
        }

        public IEnumerable<DetailResponeDTO> GetAllDetailByOrderID(int Id)
        {
            return _jewelryContext.Details.Include(x => x.Product).Select(x=> new DetailResponeDTO
            {
                DetailId = x.DetailId,
                OrderId = x.OrderId,
                Quantity = x.Quantity,
                Price = x.Price,
                ProductId = x.ProductId,
                Name = x.Product.Name
            }).Where(x=>x.OrderId==Id).ToList();
        }

        public IEnumerable<DetailResponeDTO> GetAllDetails()
        {
            return _jewelryContext.Details.Include(x => x.Product).Select(x => new DetailResponeDTO
            {
                DetailId = x.DetailId,
                OrderId = x.OrderId,
                Quantity = x.Quantity,
                Price = x.Price,
                ProductId = x.ProductId,
                Name = x.Product.Name
            }).ToList();
        }

        public DetailResponeDTO GetDetailById(int detailId)
        {
            var detail = _jewelryContext.Details.Include(x=>x.Product).FirstOrDefault(d => d.DetailId == detailId);
            if (detail == null)
            {
                return null; // Hoặc có thể throw exception nếu không tìm thấy
            }

            return new DetailResponeDTO
            {
                DetailId = detail.DetailId,
                OrderId = detail.OrderId,
                Quantity = detail.Quantity,
                Price = detail.Price,
                ProductId = detail.ProductId,
                Name = detail.Product?.Name // Assuming there's a Product navigation property
            };
        }

        public DetailResponeDTO GetDetailByOidAndPid(int oid, int pid)
        {
            var detail = _jewelryContext.Details.Include(x => x.Product).FirstOrDefault(d => d.OrderId == oid&&d.ProductId==pid);
            if (detail == null)
            {
                return null; // Hoặc có thể throw exception nếu không tìm thấy
            }

            return new DetailResponeDTO
            {
                DetailId = detail.DetailId,
                OrderId = detail.OrderId,
                Quantity = detail.Quantity,
                Price = detail.Price,
                ProductId = detail.ProductId,
                Name = detail.Product?.Name // Assuming there's a Product navigation property
            };
        }

        public void UpdateDetail(DetailRequestDTO detail)
        {
            var detailToUpdate = _jewelryContext.Details.FirstOrDefault(d => d.DetailId == detail.DetailId);
            if (detailToUpdate == null)
            {
                throw new ArgumentException($"Detail with id {detail.DetailId} not found");
            }

            detailToUpdate.OrderId = detail.OrderId;
            detailToUpdate.Quantity = detail.Quantity;
            detailToUpdate.Price = detail.Price;
            detailToUpdate.ProductId = detail.ProductId;
            _jewelryContext.Details.Update(detailToUpdate);
            _jewelryContext.SaveChanges();
        }
        public List<DetailResponeDTO> GetDetailByOrderId(int id)
        {
            var existOrder = _jewelryContext.Orders
                .Include(x => x.Details).ThenInclude(x => x.Product)
                .SingleOrDefault(o => o.OrderId == id);

            if (existOrder == null)
                throw new Exception("Order not found!");

            return existOrder.Details.Select(x => new DetailResponeDTO
            {
                DetailId = x.DetailId,
                OrderId = x.OrderId,
                Price = x.Price,
                ProductId = x.ProductId,
                Name = x.Product?.Name,
                Image = x.Product?.ImageLink,
                Quantity = x.Quantity,
                Total = x.Quantity * x.Price
            }).ToList();
        }


    }
}
