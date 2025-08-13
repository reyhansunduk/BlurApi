namespace BlurApi.Models
{

    public class Enterprices : BaseEntity
    {
        public string Title {get; set;} 
        public string Phone {get; set;} 
        public string Email {get; set;} 
        public float Balance {get; set;} 
        public bool Verified {get; set;} = true;
        public string Address {get; set;} 
        public long TaxNumber {get; set;} 
        public TaxAddress TaxAddress {get; set;} 
        public DateTime CreatedAt {get; set;} 
        public bool Disabled {get; set;} 
    }
}