using System;

namespace Biblioteka.Domain.Dto
{
    public class EvidencijaDugovanjaDto
    {
        public int Id { get; set; }
        public DateTime DatumZaduzivanja { get; set; }
        public DateTime? DatumRazduzivanja { get; set; }
        public NaslovDto Naslov { get; set; }
        public ClanDto Clan { get; set; }
        public float UkupnaCena { get; set; }
    }//class
}//namespace
