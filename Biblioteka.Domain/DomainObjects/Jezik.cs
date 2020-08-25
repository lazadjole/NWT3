using Biblioteka.Domain.Repository;

namespace Biblioteka.Domain.DomainObjects
{
    public class Jezik : IAssetId
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
    }//class
}//namespace
