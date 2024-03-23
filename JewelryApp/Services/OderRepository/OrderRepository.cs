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

        public OrderRepository(JewelryContext context)
        {
            this.context = context;
        }
        public OrderResponeDTO CheckOrder(string userId)
        {
            var order = context.Orders.FirstOrDefault(x=>x.Userid.Equals(userId)&&x.Status==false);
            if (order != null)
            {
                return new OrderResponeDTO
                {
                    OrderId=order.OrderId,
                    Type = order.Type,
                    Userid = order.Userid,
                    DateOrder=order.DateOrder,
                    Total=order.Total,
                };
            }
            else
            {
                return null;
            }
        }
        public OrderResponeDTO AddNewOrder(OrderRequestDTO orderRequestDTO)
        {
            var responseDTO = new OrderResponeDTO();
            try
            {
                var order = new Order
            {
                OrderId = orderRequestDTO.OrderId,
                Type = orderRequestDTO.Type,
                Userid = orderRequestDTO.Name,
                DateOrder = orderRequestDTO.DateOrder,
                Total = 0,
                Status = false                
            };
            context.Orders.Add(order);
            context.SaveChanges();
            responseDTO.DateOrder = orderRequestDTO.DateOrder;
            responseDTO.Total = orderRequestDTO.Total;
            responseDTO.Userid = orderRequestDTO.Name;
            responseDTO.OrderId = orderRequestDTO.OrderId;
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

        public OrderResponeDTO UpdateOrder(OrderRequestDTO orderRequestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
