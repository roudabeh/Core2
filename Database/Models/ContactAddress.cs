namespace Tamrin.Database.Models
{
    public class ContactAddress
    {
        public int id { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public string Address { get; set; }
    }
}
