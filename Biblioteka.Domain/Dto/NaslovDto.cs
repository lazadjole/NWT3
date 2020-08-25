using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Domain.Dto
{
    public class NaslovDto
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Autor { get; set; }
        public float CenaPoDanu { get; set; }
        public JezikDto Jezik { get; set; }
        public VrstaDto Vrsta { get; set; }
    }//class
}//namespace
