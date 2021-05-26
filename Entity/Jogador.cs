using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace CampeonatoAquiCampeao.Entity
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Posicao { get; set; }
        public int IdClube { get; set; }
        public string PeBom { get; set; }
    }
}
