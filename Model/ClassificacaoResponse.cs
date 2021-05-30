using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoAquiCampeao.Model
{
    public class ClassificacaoResponse
    {
        public int IdClube{ get; set; }
        public string NomeClube { get; set; }
        public int Pontos { get; set; }
        public int Vitoria { get; set; }
        public int Empate { get; set; }
        public int Derrota { get; set; }
        public int SaldoGols { get; set; }
      


    }
}
