using DAL.Models;
using WebAPI_PrintPayment.Models;

namespace WebAPI_PrintPayment.Extension
{
    public static class ConverterExtensions
    {
        public static PrintQuotaM ToModel(this PrintQuota quota)
        {
            return new PrintQuotaM
            {
                Id = quota.Id,
                UID = quota.Student.UID,
                Username = quota.Student.Username,
                NbPages = quota.NbPages,
                CreatedAt = quota.CreatedAt
            };
        }

        public static PrintQuota ToDAL(this PrintQuotaM quotaM)
        {
            return new PrintQuota
            {
                Id = quotaM.Id,
                Student = new Student
                {
                    UID = quotaM.UID,
                    Username = quotaM.Username
                },
                NbPages = quotaM.NbPages,
                CreatedAt = quotaM.CreatedAt
            };
        }
    }
}
