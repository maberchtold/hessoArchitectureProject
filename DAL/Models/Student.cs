namespace DAL.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string UID { get; set; } = null!;
        public string Username { get; set; } = null!;

        public ICollection<PrintQuota> PrintQuotas { get; set; } = new List<PrintQuota>();
    }
}
