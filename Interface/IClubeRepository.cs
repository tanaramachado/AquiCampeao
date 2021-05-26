using CampeonatoAquiCampeao.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampeonatoAquiCampeao.Interface;
using CampeonatoAquiCampeao.Model;

namespace CampeonatoAquiCampeao.Interface
{
    public interface IClubeRepository
    {
        List<Clube> Listar();
        void Inserir(Clube Clube);
        Clube Obter(int Id);
        void Atualizar(Clube clube);
        void Deletar(int Id);
        Clube ObterPorNome(string Nome);

    }
}
