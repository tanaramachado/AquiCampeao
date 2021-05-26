using CampeonatoAquiCampeao.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampeonatoAquiCampeao.Interface;
using CampeonatoAquiCampeao.Model;

namespace CampeonatoAquiCampeao.Interface
{
    public interface IJogadorService
    {
        List<JogadorResponse> Listar();
        JogadorResponse Obter(int id);
        BaseResponse Inserir(JogadorRequest request);
        BaseResponse Atualizar(JogadorRequest request);
        BaseResponse Deletar(int Id);
        
    }
}
