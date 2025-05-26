using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI_PrintPayment.Business;

namespace WebAPI_PrintPayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IPrintPaymentHelper _helper;

        public StudentsController(IPrintPaymentHelper helper)
        {
            _helper = helper;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<PrintQuota>>> GetAll()
        {
            var quotas = await _helper.GetAllQuotasAsync();
            return Ok(quotas);
        }

        [HttpGet("{uidOrUsername}")]
        public async Task<ActionResult<List<PrintQuota>>> GetByStudent(string uidOrUsername)
        {
            try
            {
                var quotas = await _helper.GetQuotasByStudentAsync(uidOrUsername);
                return Ok(quotas);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
