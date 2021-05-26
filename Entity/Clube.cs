using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;



namespace CampeonatoAquiCampeao.Entity
{
    public class Clube
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeEstadio { get; set; }
        public string AnoFundacao { get; set; }
        public string Cidade { get; set; }
    }
}
