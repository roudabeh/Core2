namespace Tamrin.Database.Models
{
    public class FactorDetail
    {
        public int Id { get; set; }
        public int FactorId { get; set; }
        public Factor Factor { get; set; }
        public string Item { get; set; }
        public int Value { get; set; }
        public decimal Price { get; set; }
    }
}
