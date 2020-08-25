using System;
using System.Collections.Generic;

namespace Biblioteka.Database.Models
{
    public partial class NaslovModel
    {
        public NaslovModel()
        {
            EvidencijaDugovanjaModel = new HashSet<EvidencijaDugovanjaModel>();
        }

        public int IdNaslov { get; set; }
        public string Naziv { get; set; }
        public double? CenaPoDanu { get; set; }
        public string Autor { get; set; }
        public int IdVrsta { get; set; }
        public int IdJezik { get; set; }

        public virtual JezikModel IdJezikNavigation { get; set; }
        public virtual VrstaModel IdVrstaNavigation { get; set; }
        public virtual ICollection<EvidencijaDugovanjaModel> EvidencijaDugovanjaModel { get; set; }
    }
}
