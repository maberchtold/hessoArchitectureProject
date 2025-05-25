using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_Digitec.Models
{
    public class ItemViewModel
    {
        public ItemM Item { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> Employees { get; set; }
    }
}
