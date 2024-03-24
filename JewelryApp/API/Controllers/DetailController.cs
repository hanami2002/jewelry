using DataTranferObject.DetailDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DetailRepository;
using Services.OderRepository;
using Services.ProductRepository;
using static API.Controllers.DetailController;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IDetailRepository _detailRepository;
        private readonly IProductRepository _productRepository;

        public DetailController(IOrderRepository orderRepository, IDetailRepository detailRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _detailRepository = detailRepository;
            _productRepository = productRepository;
        }
        public class DetailResquet
        {
            public string username { get; set; }
            public int productId { get; set; }
        }
        [HttpPost]
        public IActionResult AddOrder(DetailResquet detailResquet)
        {
            var order = _orderRepository.CheckOrder(detailResquet.username);
            if (order == null)
            {
                order = _orderRepository.AddNewOrder(detailResquet.username);
            }
            var _detail = _detailRepository.GetDetailByOidAndPid(order.OrderId, detailResquet.productId);
            if (_detail == null)
            {
                var detail = new DetailRequestDTO
                {
                    DetailId = 0,
                    ProductId = detailResquet.productId,
                    Quantity = 1,
                    OrderId = order.OrderId,
                    Price = _productRepository.GetByid(detailResquet.productId).SellPrice
                };

                _detailRepository.CreateDetail(detail);
            }
            else
            {
                var detail = new DetailRequestDTO
                {
                    DetailId = _detail.DetailId,
                    ProductId = detailResquet.productId,
                    Quantity = _detail.Quantity + 1,
                    OrderId = order.OrderId,
                    Price = _productRepository.GetByid(detailResquet.productId).SellPrice
                };

                _detailRepository.UpdateDetail(detail);

            }

            return Ok(detailResquet);

        }
        [HttpGet("GetByUser/{username}")]
        public IActionResult GetByUser(string username)
        {
            var order = _orderRepository.CheckOrder(username);
            if (order == null)
            {
                return NotFound();
            }
            var _detail = _detailRepository.GetAllDetailByOrderID(order.OrderId);
            return Ok(_detail);
        }
        [HttpPut]
        public IActionResult Update(DetailRequestDTO detailResquet)
        {
            try
            {
                _detailRepository.UpdateDetail(detailResquet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok(detailResquet);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _detailRepository.DeleteDetail(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(id);
        }
        [HttpGet("{OrderId}")]
        public IActionResult GetDetailsByOrderId(int OrderId)
        {
            try
            {
                return Ok(_detailRepository.GetDetailByOrderId(OrderId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
