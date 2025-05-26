namespace WebAPI_PrintPayment.Models
{
    public class PrintQuotaM
    {
        public int Id { get; set; }
        public string? UID { get; set; }
        public string? Username { get; set; }
        public int NbPages { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
