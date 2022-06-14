using Tamrin.Database.Models;

namespace Tamrin.APIModels
{
    public class ContactAPIModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public List<string> Addresses { get; set; }
        public List<string> Factors { get; set; }
    }
}
