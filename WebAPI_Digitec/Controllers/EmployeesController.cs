using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Digitec.Business;
using WebAPI_Digitec.Extension;
using WebAPI_Digitec.Models;

namespace WebAPI_Digitec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IComputationHelper _computationHelper;

        public EmployeesController(IComputationHelper computationHelper)
        {
            _computationHelper = computationHelper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeM>>> GetItems()
        {
            var employees = await _computationHelper.GetEmployees();
            var listOfEmployeeM = new List<EmployeeM>();
            foreach (var employee in employees)
            {
                EmployeeM employeeM = new EmployeeM();
                employeeM = employee.ToModel();
                listOfEmployeeM.Add(employeeM);
            }

            return Ok(listOfEmployeeM);
        }
    }
}
