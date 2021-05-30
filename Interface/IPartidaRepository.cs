using CampeonatoAquiCampeao.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoAquiCampeao.Interface
{
    public interface IPartidaRepository
    {
        List<Partida> Listar();
        void Inserir(Partida partida);
        Partida Obter(int Id);
        void Atualizar(Partida partida);
        void Deletar(int Id);
        List<Partida> ListarClassificacao(int IdClube);
    }
}
