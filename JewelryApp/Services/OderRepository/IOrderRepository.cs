using DataTranferObject.OrderDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OderRepository
{
    public interface IOrderRepository
    {
        public List<OrderResponeDTO> GetAll();
        public List<OrderResponeDTO> GetByFilter(string? userId,DateTime? date);
        public OrderResponeDTO CheckOrder(string userId);
        public OrderResponeDTO AddNewOrder(OrderRequestDTO orderRequestDTO);
        public OrderResponeDTO UpdateOrder(OrderRequestDTO orderRequestDTO);

    }
}
