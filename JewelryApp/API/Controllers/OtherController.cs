using DataTranferObject.Paging;
using DataTranferObject.ProductDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.PagingRepository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherController : ControllerBase
    {
        private readonly PagingRepository pagingRepository;

        public OtherController(PagingRepository pagingRepository)
        {
            this.pagingRepository = pagingRepository;
        }
       
        //public PagingRequest<ProductResponeDTO> GetPaging()
        //{
        //    return pagingRepository.GetPagingRequest();
        //}
    }
}
