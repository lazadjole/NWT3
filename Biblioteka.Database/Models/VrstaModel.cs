using System;
using System.Collections.Generic;

namespace Biblioteka.Database.Models
{
    public partial class VrstaModel
    {
        public VrstaModel()
        {
            NaslovModel = new HashSet<NaslovModel>();
        }

        public int IdVrsta { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<NaslovModel> NaslovModel { get; set; }
    }
}
