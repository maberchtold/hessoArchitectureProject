using Microsoft.AspNetCore.Mvc;
using MVC_PrintPayment.Models;
using MVC_PrintPayment.Services;

namespace MVC_PrintPayment.Controllers
{
    public class PrintAccessController : Controller
    {
        private readonly IPrintPaymentServices _service;

        public PrintAccessController(IPrintPaymentServices service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Student Quota Top-Up View (UID + Amount)
        [HttpGet]
        public IActionResult AddQuotaByUid()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddQuotaByUid(AddQuotaByUidM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _service.AddQuotaByUidAsync(model);
            ViewBag.Result = result;
            return View();
        }

        // Faculty Quota Distribution View
        [HttpGet]
        public async Task<IActionResult> FacultyAddQuota()
        {
            var students = await _service.GetAllStudentsAsync();
            var model = new FacultyQuotaM
            {
                Students = students
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> FacultyAddQuota(FacultyQuotaM model)
        {
            if (!ModelState.IsValid)
            {
                model.Students = await _service.GetAllStudentsAsync();
                return View(model);
            }

            await _service.AddQuotaToStudentsAsync(model);
            ViewBag.Result = "Quota successfully added for selected students.";

            model.Students = await _service.GetAllStudentsAsync();
            return View(model);
        }

        // Student Balance View (Query by UID or Username)
        [HttpGet]
        public IActionResult ViewBalance()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ViewBalance(BalanceQueryM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _service.GetBalanceAsync(model);
            ViewBag.Balance = result;
            return View();
        }
    }
}
