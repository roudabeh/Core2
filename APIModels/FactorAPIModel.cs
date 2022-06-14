
namespace Tamrin.APIModels
{
    public class FactorAPIModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ContactId { get; set; }
        public List<FactorDetailAPIModel> FactorDetails { get; set; }
    }
}
