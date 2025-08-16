namespace BlurApi.Models
{

    public class Enterprices : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty;
        public decimal Balance { get; set; } 
        public bool Verified { get; set; } = true; 
        public string Address { get; set; } = string.Empty;
        public long TaxNumber { get; set; } 
        public TaxAddress TaxAddress { get; set; } = new TaxAddress();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool Disabled { get; set; } = false;
    }
}