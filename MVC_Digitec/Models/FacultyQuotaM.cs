using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_PrintPayment.Models
{
    public class FacultyQuotaM
    {
        public float Amount { get; set; }

        public List<string> SelectedUsernames { get; set; } = new List<string>();

        public List<StudentQuotaM> Students { get; set; } = new List<StudentQuotaM>();
    }
}
