using CampeonatoAquiCampeao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoAquiCampeao.Interface
{
    public interface IClubeService 
    {
        List<ClubeResponse> Listar();
        BaseResponse Inserir(ClubeRequest request);
        ClubeResponse Obter(int id);
        BaseResponse Atualizar(ClubeRequest request);
        BaseResponse Deletar(int Id);

    }
}
