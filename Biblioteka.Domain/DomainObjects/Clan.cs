using Biblioteka.Domain.Repository;

namespace Biblioteka.Domain.DomainObjects
{
    public class Clan : IAssetId
    {
        public int Id { get; set; }
        public string ImePrezime { get; set; }
        public string JMBG { get; set; }
    }//class
}//namespace
