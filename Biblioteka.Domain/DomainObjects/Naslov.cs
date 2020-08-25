using Biblioteka.Domain.Repository;

namespace Biblioteka.Domain.DomainObjects
{
    public class Naslov : IAssetId
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Autor { get; set; }
        public float CenaPoDanu { get; set; }
        public Jezik Jezik { get; set; }
        public Vrsta Vrsta { get; set; }
    }//class
}//namespace
