namespace WebAPI_PrintPayment.Extension
{
    public static class ConverterExtensions
    {
        public static DAL.Models.PrintQuota ToDAL(this WebAPI_PrintPayment.Models.PrintQuotaM quotaM)
        {
            return new DAL.Models.PrintQuota
            {
                Id = quotaM.Id,
                UID = quotaM.UID,
                Username = quotaM.Username,
                NbPages = quotaM.NbPages,
                CreatedAt = quotaM.CreatedAt
            };
        }

        public static WebAPI_PrintPayment.Models.PrintQuotaM ToModel(this DAL.Models.PrintQuota quota)
        {
            return new WebAPI_PrintPayment.Models.PrintQuotaM
            {
                Id = quota.Id,
                UID = quota.UID,
                Username = quota.Username,
                NbPages = quota.NbPages,
                CreatedAt = quota.CreatedAt
            };
        }
    }
}
