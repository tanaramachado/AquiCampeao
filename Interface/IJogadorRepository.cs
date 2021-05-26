using CampeonatoAquiCampeao.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampeonatoAquiCampeao.Interface;
using CampeonatoAquiCampeao.Model;

namespace CampeonatoAquiCampeao.Interface
{
    public interface IJogadorRepository
    {
        List<Jogador> Listar();
        void Inserir(Jogador jogador);
        Jogador Obter(int Id);
        void Atualizar(Jogador jogador);
        void Deletar(int Id);


    }

    
    
}
