using System;
using System.Collections.Generic;

namespace Biblioteka.Database.Models
{
    public partial class ClanModel
    {
        public ClanModel()
        {
            EvidencijaDugovanjaModel = new HashSet<EvidencijaDugovanjaModel>();
        }

        public int IdClan { get; set; }
        public string ImePrezime { get; set; }
        public string Jmbg { get; set; }

        public virtual ICollection<EvidencijaDugovanjaModel> EvidencijaDugovanjaModel { get; set; }
    }
}
