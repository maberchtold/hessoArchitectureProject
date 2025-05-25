using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Digitec.Models;
using MVC_Digitec.Services;
using System.Reflection;

namespace MVC_Digitec.Controllers
{
    public class DigitecAccessController : Controller
    {
        private IDigitecServices _digitecServices;

        public DigitecAccessController(IDigitecServices digitecServices)
        {
            _digitecServices = digitecServices;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _digitecServices.GetItems();
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> AddItem()
        {
            //step 0
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(ItemM item)
        {
            // step 1
            await _digitecServices.PostItem(item);
            return View(item);

        }

        [HttpGet]
        public async Task<IActionResult> EditItem(int id)
        {
            var item = await _digitecServices.GetItem(id);
            var employees = await _digitecServices.GetEmployees();

            //Build ViewModel
            var viewModel = new ItemViewModel
            {
                Item = item,
                Employees = employees.Select(e => new SelectListItem
                {
                    Value = e.EmployeeId.ToString(),
                    Text = e.Firstname + " " + e.Lastname,
                    Selected = e.EmployeeId == item.employeeId
                })
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditItem(ItemViewModel itemViewModel)
        {
            if (!ModelState.IsValid)
            {
                // Reload Employees for redisplay
                var employees = await _digitecServices.GetEmployees();
                itemViewModel.Employees = employees.Select(e => new SelectListItem
                {
                    Value = e.EmployeeId.ToString(),
                    Text = e.Firstname + " " + e.Lastname,
                    Selected = e.EmployeeId == itemViewModel.Item.employeeId
                });

                return View(itemViewModel);
            }

            await _digitecServices.PutItem(itemViewModel.Item);
            return RedirectToAction("Index");
        }
    }
}
