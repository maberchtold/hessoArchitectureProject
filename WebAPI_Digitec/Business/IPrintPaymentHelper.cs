using DAL.Models;
using WebAPI_PrintPayment.Models;

namespace WebAPI_PrintPayment.Business
{
    public interface IPrintPaymentHelper
    {
        Task<PrintQuota> AddQuotaByUidAsync(string uid, float amountCHF);
        Task<PrintQuota> AddQuotaByUsernameAsync(string username, float amountCHF);
        Task<List<PrintQuota>> GetQuotasByStudentAsync(string uidOrUsername);
        Task<List<PrintQuota>> GetAllQuotasAsync();
        Task<List<StudentQuotaM>> GetStudentQuotaSummariesAsync();
        Task<StudentQuotaM> GetStudentQuotaSummaryAsync(string uidOrUsername);


    }
}
