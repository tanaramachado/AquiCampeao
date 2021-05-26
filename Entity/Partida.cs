using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoAquiCampeao.Entity
{
    public class Partida
    {
        public int Id { get; set; }
        public int IdVisitante { get; set; }
        public int IdMandante { get; set; }
        public DateTime Data { get; set; }
        public int GolsMandante{ get; set; }
        public int GolsVisitante { get; set; }
    }
}
