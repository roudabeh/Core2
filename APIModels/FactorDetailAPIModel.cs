namespace Tamrin.APIModels
{
    public class FactorDetailAPIModel
    {
        public int Id { get; set; }
        public int FactorId { get; set; }
        public string Item { get; set; }
        public int Value { get; set; }
        public decimal Price { get; set; }
    }
}
