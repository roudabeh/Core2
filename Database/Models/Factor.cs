namespace Tamrin.Database.Models
{
    public class Factor
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public IEnumerable<FactorDetail> FactorDetails { get; set; }
    }
}
