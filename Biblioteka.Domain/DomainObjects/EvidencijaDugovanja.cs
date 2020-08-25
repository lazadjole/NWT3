using System;
using Biblioteka.Domain.Repository;

namespace Biblioteka.Domain.DomainObjects
{
    public class EvidencijaDugovanja:IAssetId
    {
        public int Id { get; set; }
        public DateTime DatumZaduzivanja{ get; set; }
        public DateTime? DatumRazduzivanja { get; set; }
        public Naslov Naslov { get; set; }
        public Clan Clan { get; set; }
        public float UkupnaCena { get; set; }
    }//class
}//namespace
