using MVC_PrintPayment.Models;

namespace MVC_PrintPayment.Services
{
    public interface IPrintPaymentServices
    {
        Task<string> AddQuotaByUidAsync(AddQuotaByUidM model);

        Task<List<StudentQuotaM>> GetAllStudentsAsync();

        Task AddQuotaToStudentsAsync(FacultyQuotaM model);

        Task<StudentQuotaM?> GetBalanceAsync(BalanceQueryM model);
    }
}
