namespace BlurApi.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? InsertedBy { get; set; } 
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public DateTime? ChangedDate { get; set; } 
        public string? ChangedBy { get; set; } 
    }
}