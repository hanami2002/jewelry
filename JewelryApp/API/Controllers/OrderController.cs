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
        public IActionResult AddOrder(string name)
        {
            try
            {
                var result = _orderRepository.AddNewOrder(name);
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
        public class ChangeOrder
        {
            public string Userid { get; set; }
            public double Total { get; set; }
        }
        [HttpPut]
        public IActionResult PutOrder(ChangeOrder changeOrder)
        {
            try
            {
                _orderRepository.UpdateOrder(changeOrder.Userid, changeOrder.Total);
                return Ok(changeOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("GetAllOrder")]
        public IActionResult GetAllOrders([FromBody] SearchOrderRequestDTO request)
        {
            try
            {
                return Ok(_orderRepository.GetAllOrders(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
