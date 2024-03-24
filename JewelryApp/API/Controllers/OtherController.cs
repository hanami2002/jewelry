using DataTranferObject.Paging;
using DataTranferObject.ProductDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.PagingRepository;
using Utilities;

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
        [HttpPost]
        public async Task<ActionResult> SendEmail(EmailMessage emailSetting)
        {
            EmailServices emailServices = new EmailServices();
           await emailServices.SendAsync(emailSetting);
            return  Ok();
        }     
    }
}
