using System;
using System.Collections.Generic;

namespace Biblioteka.Database.Models
{
    public partial class JezikModel
    {
        public JezikModel()
        {
            NaslovModel = new HashSet<NaslovModel>();
        }

        public int IdJezik { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<NaslovModel> NaslovModel { get; set; }
    }
}
