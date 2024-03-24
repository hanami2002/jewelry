using DataTranferObject.OrderDTO;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly JewelryContext context;
        private int PageSize = 9;
        public OrderRepository(JewelryContext context)
        {
            this.context = context;
        }
        public OrderResponeDTO CheckOrder(string userId)
        {
            var order = context.Orders.FirstOrDefault(x => x.Userid.Equals(userId) && x.Status == false);
            if (order != null)
            {
                return new OrderResponeDTO
                {
                    OrderId = order.OrderId,
                    Type = order.Type,
                    Userid = order.Userid,
                    DateOrder = order.DateOrder,
                    Total = order.Total,
                };
            }
            else
            {
                return null;
            }
        }
        public OrderResponeDTO AddNewOrder(string username)
        {
            var responseDTO = new OrderResponeDTO();
            try
            {
                var order = new Order
                {
                    OrderId = 0,
                    Type = "Mua",
                    Userid = username,
                    DateOrder = DateTime.Now,
                    Total = 0,
                    Status = false
                };
                context.Orders.Add(order);
                context.SaveChanges();
                responseDTO.DateOrder = order.DateOrder;
                responseDTO.Total = order.Total;
                responseDTO.Userid = order.Userid;
                responseDTO.OrderId = order.OrderId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return responseDTO;

        }

        public List<OrderResponeDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<OrderResponeDTO> GetByFilter(string? userId, DateTime? date)
        {
            throw new NotImplementedException();
        }

        public OrderResponeDTO UpdateOrder(string username,double total)
        {
            var order = context.Orders.FirstOrDefault(x => x.Userid.Equals(username) && x.Status == false);           
            if (order == null)
            {
                return null;
            }
            else
            {
                order.DateOrder = DateTime.Now;
                order.Status = true;
                order.Total = total;
                context.Orders.Update(order);
                context.SaveChanges();
                return  new OrderResponeDTO
                {
                    OrderId = order.OrderId,
                    Type = order.Type,
                    Userid = order.Userid,
                    DateOrder = order.DateOrder,
                    Total = order.Total,
                };

            }
        }
        public SearchOrderResponse GetAllOrders(SearchOrderRequestDTO request)
        {
            if (request.PageIndex == null || request.PageIndex <= 0)
            {
                request.PageIndex = 1;
            }

            var query = context.Orders
                .Where(x => (request.From == null || x.DateOrder >= request.From)
                    && (request.To == null || x.DateOrder <= request.To)
                    && (request.Type == null || x.Type == request.Type)
                    && (request.Status == null || x.Status == request.Status)
                )
                .Select(x => new OrderResponse
                {
                    OrderId = x.OrderId,
                    Type = x.Type,
                    DateOrder = x.DateOrder,
                    Total = x.Total,
                    Userid = x.Userid,
                    Status = x.Status
                }).AsQueryable();

            SearchOrderResponse response = new SearchOrderResponse();
            response.PageIndex = (int)request.PageIndex;
            response.PageSize = PageSize;
            response.PageCount = query.Count() % PageSize == 0 ? query.Count() / PageSize : query.Count() / PageSize + 1;
            response.Orders = query
                .Skip(((int)request.PageIndex - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            return response;
        }
    }
}
