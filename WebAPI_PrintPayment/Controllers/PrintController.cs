using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI_PrintPayment.Business;
using WebAPI_PrintPayment.Extension;

namespace WebAPI_PrintPayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintController : ControllerBase
    {
        private readonly IPrintPaymentHelper _helper;

        public PrintController(IPrintPaymentHelper helper)
        {
            _helper = helper;
        }

        [HttpPost("uid/{uid}")]
        public async Task<ActionResult<PrintQuota>> AddQuotaByUid(string uid, [FromBody] float amount)
        {
            try
            {
                var quota = await _helper.AddQuotaByUidAsync(uid, amount);
                return Ok(quota.ToModel());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("username/{username}")]
        public async Task<ActionResult<PrintQuota>> AddQuotaByUsername(string username, [FromBody] float amount)
        {
            try
            {
                var quota = await _helper.AddQuotaByUsernameAsync(username, amount);
                return Ok(quota.ToModel());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
