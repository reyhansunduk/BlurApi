namespace BlurApi.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; } 
        public string InsertedBy { get; set; } 
        public DateTime InsertedDate { get; set; }
        public DateTime ChangedDate { get; set; } 
        public string ChangedBy { get; set; } 
    }
}