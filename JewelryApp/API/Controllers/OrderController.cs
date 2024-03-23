using DataTranferObject.OrderDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.OderRepository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpPost]
        public IActionResult AddOrder(OrderRequestDTO orderRequestDTO)
        {
            try
            {
                var result = _orderRepository.AddNewOrder(orderRequestDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{userid}")]
        public IActionResult GetOrder(string userid)
        {
            try
            {
                var result = _orderRepository.CheckOrder(userid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
