using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI_PrintPayment.Models;

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
            var student = await _context.Students.FirstOrDefaultAsync(s => s.UID == uid);

            if (student == null)
                throw new Exception("Student not found.");


            var pages = ConvertCHFToPages(amountCHF);

            var quota = new PrintQuota
            {
                StudentId = student.StudentId,
                NbPages = pages,
                CreatedAt = DateTime.Now
            };

            _context.PrintQuotas.Add(quota);
            await _context.SaveChangesAsync();
            return quota;
        }

        public async Task<PrintQuota> AddQuotaByUsernameAsync(string username, float amountCHF)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Username == username);

            if (student == null)
                throw new Exception("Student not found.");

            var pages = ConvertCHFToPages(amountCHF);

            var quota = new PrintQuota
            {
                StudentId = student.StudentId,
                NbPages = pages,
                CreatedAt = DateTime.Now
            };

            _context.PrintQuotas.Add(quota);
            await _context.SaveChangesAsync();
            return quota;
        }

        public async Task<List<PrintQuota>> GetQuotasByStudentAsync(string uidOrUsername)
        {
            var student = await _context.Students
                .Include(s => s.PrintQuotas)
                .FirstOrDefaultAsync(s => s.UID == uidOrUsername || s.Username == uidOrUsername);

            if (student == null)
                throw new Exception("Student not found.");

            return student.PrintQuotas.ToList();
        }

        public async Task<List<PrintQuota>> GetAllQuotasAsync()
        {
            return await _context.PrintQuotas
                .Include(q => q.Student)
                .ToListAsync();
        }

        public async Task<List<StudentQuotaM>> GetStudentQuotaSummariesAsync()
        {
            return await _context.Students
                .Select(s => new StudentQuotaM
                {
                    UID = s.UID,
                    Username = s.Username,
                    TotalPages = s.PrintQuotas.Sum(q => q.NbPages)
                })
                .ToListAsync();
        }

        public async Task<StudentQuotaM> GetStudentQuotaSummaryAsync(string uidOrUsername)
        {
            var student = await _context.Students
                .Include(s => s.PrintQuotas)
                .FirstOrDefaultAsync(s => s.UID == uidOrUsername || s.Username == uidOrUsername);

            if (student == null)
                throw new Exception("Student not found.");

            return new StudentQuotaM
            {
                UID = student.UID,
                Username = student.Username,
                TotalPages = student.PrintQuotas.Sum(q => q.NbPages)
            };
        }


    }
}
