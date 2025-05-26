using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_PrintPayment.Business
{
    public class PrintPaymentHelper : IPrintPaymentHelper
    {
        private readonly PrintPaymentContext _context;

        public PrintPaymentHelper(PrintPaymentContext context)
        {
            _context = context;
        }

        private int ConvertCHFToPages(float amountCHF)
        {
            const float pricePerPage = 0.08f;
            return (int)(amountCHF / pricePerPage);
        }

        public async Task<PrintQuota> AddQuotaByUidAsync(string uid, float amountCHF)
        {
            var pages = ConvertCHFToPages(amountCHF);

            var quota = new PrintQuota
            {
                UID = uid,
                NbPages = pages,
                CreatedAt = DateTime.Now
            };

            _context.PrintQuotas.Add(quota);
            await _context.SaveChangesAsync();
            return quota;
        }

        public async Task<PrintQuota> AddQuotaByUsernameAsync(string username, float amountCHF)
        {
            var pages = ConvertCHFToPages(amountCHF);

            var quota = new PrintQuota
            {
                Username = username,
                NbPages = pages,
                CreatedAt = DateTime.Now
            };

            _context.PrintQuotas.Add(quota);
            await _context.SaveChangesAsync();
            return quota;
        }

        public async Task<List<PrintQuota>> GetQuotasByStudentAsync(string uidOrUsername)
        {
            return await _context.PrintQuotas
                .Where(q => q.UID == uidOrUsername || q.Username == uidOrUsername)
                .ToListAsync();
        }

        public async Task<List<PrintQuota>> GetAllQuotasAsync()
        {
            return await _context.PrintQuotas.ToListAsync();
        }
    }
}
