namespace Tamrin.Database.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public IEnumerable<ContactAddress> Addresses { get; set; }
        public IEnumerable<Factor> Factors { get; set; }
    }
}
