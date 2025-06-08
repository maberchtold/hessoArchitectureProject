using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI_PrintPayment.Business;
using WebAPI_PrintPayment.Extension;
using WebAPI_PrintPayment.Models;

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
        public async Task<ActionResult<List<StudentQuotaM>>> GetAllSummaries()
        {
            var summaries = await _helper.GetStudentQuotaSummariesAsync();
            return Ok(summaries);
        }


        [HttpGet("{uidOrUsername}")]
        public async Task<ActionResult<StudentQuotaM>> GetStudentSummary(string uidOrUsername)
        {
            try
            {
                var student = await _helper.GetStudentQuotaSummaryAsync(uidOrUsername);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
