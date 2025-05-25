using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Digitec.Business;
using WebAPI_Digitec.Extension;
using WebAPI_Digitec.Models;

namespace WebAPI_Digitec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DigitecController : ControllerBase
    {
        private readonly IComputationHelper _computationHelper;

        public DigitecController(IComputationHelper computationHelper)
        {
            _computationHelper = computationHelper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemM>>> GetItems()
        {
            var items = await _computationHelper.GetItems();
            if (items == null)
                return NotFound();
            var ListOfItemM = new List<ItemM>();
            foreach (var item in items)
            {
                ItemM itemM = new ItemM();
                itemM = item.ToModel();
                ListOfItemM.Add(itemM);
            }
            
            return Ok(ListOfItemM);
        }

        [HttpGet("GetItem/{id}")]
        public async Task<ActionResult<ItemM>> GetItem(int id)
        {
            var item = await _computationHelper.GetItem(id);
            if (item == null)
                return NotFound();
            return Ok(item.ToModel());
        }

        [HttpPost]
        public async Task<ActionResult<ItemM>> PostItem(ItemM itemM)
        {
            // step 3
            // convert ItemM into item
            Item item = itemM.ToDAL();
            // call method in computationHelper to add in the contextdb
            var itemReturned = await _computationHelper.PostItem(item);
            //return ItemM
            return (itemReturned.ToModel());
        }

        [HttpPut]
        public async Task<ActionResult<ItemM>> PutItem(ItemM itemM)
        {
            // convert ItemM into item
            Item item = itemM.ToDAL();
            // call method in computationHelper to add in the contextdb
            var itemReturned = await _computationHelper.PutItem(item);
            //return ItemM
            return (itemReturned.ToModel());
        }




    }
}
