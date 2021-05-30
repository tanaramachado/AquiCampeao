using CampeonatoAquiCampeao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoAquiCampeao.Interface
{
    public interface IPartidaService
    {
        List<PartidaResponse> Listar();
        BaseResponse Inserir(PartidaRequest request);
        PartidaResponse Obter(int id);
        BaseResponse Atualizar(PartidaRequest request);
        BaseResponse Deletar(int Id);
        List<ClassificacaoResponse> Classificacao();

    }
}
