namespace BlurApi.Models
{

    public class TaxAddress : BaseEntity
    {
        public string Province { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
    }
}