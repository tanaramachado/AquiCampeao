using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoAquiCampeao.Model
{
    public class JogadorRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Posicao { get; set; }
        public int IdClube { get; set; }
        public string PeBom { get; set; }
    }
}
