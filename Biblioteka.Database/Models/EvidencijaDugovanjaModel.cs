using System;
using System.Collections.Generic;

namespace Biblioteka.Database.Models
{
    public partial class EvidencijaDugovanjaModel
    {
        public int IdEvidencija { get; set; }
        public DateTime DatumZaduzivanja { get; set; }
        public DateTime? DatumRazduzivanja { get; set; }
        public int IdNaslov { get; set; }
        public int IdClan { get; set; }
        public double? UkupnaCena { get; set; }

        public virtual ClanModel IdClanNavigation { get; set; }
        public virtual NaslovModel IdNaslovNavigation { get; set; }
    }
}
