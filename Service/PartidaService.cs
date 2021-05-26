using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampeonatoAquiCampeao.Interface;
using CampeonatoAquiCampeao.Entity;
using CampeonatoAquiCampeao.Model;
using CampeonatoAquiCampeao.Repository;

namespace CampeonatoAquiCampeao.Service
{
    public class PartidaService : IPartidaService
    {
        private IPartidaRepository _partidaRepository;
        public PartidaService(IPartidaRepository partidaRepository)
        {
            _partidaRepository = partidaRepository;
        }
        public List<PartidaResponse> Listar()
        {
            var partidas = _partidaRepository.Listar();


            List<PartidaResponse> response = new List<PartidaResponse>();

            partidas.ForEach(p =>
            {
                response.Add(new PartidaResponse()
                {
                    Id = p.Id,
                    IdMandante = p.IdMandante,
                    IdVisitante = p.IdVisitante,
                    Data = p.Data,
                    GolsMandante = p.GolsMandante,
                    GolsVisitante = p.GolsVisitante,

                });


            });

            return response;
        }
        public BaseResponse Inserir(PartidaRequest request)
        {
            if (request.IdMandante == 0)
                return new BaseResponse() { StatusCode = 400, Mensagem = "IdMandante precisa ser preenchido" };

            if (request.IdVisitante == 0)
                return new BaseResponse() { StatusCode = 400, Mensagem = "IdVisitante precisa ser preenchido" };

            if (request.IdMandante == request.IdVisitante)
                return new BaseResponse() { StatusCode = 400, Mensagem = "Clube mandante não pode ser igual clube visitante" };

            Partida partida = new Partida();

            partida.Id = request.Id;
            partida.IdMandante = request.IdMandante;
            partida.IdVisitante = request.IdVisitante;
            partida.Data = request.Data;
            partida.GolsVisitante = request.GolsVisitante;
            partida.GolsMandante = request.GolsMandante;

            _partidaRepository.Inserir(partida);

            return new BaseResponse() { StatusCode = 201 };

        }
        public PartidaResponse Obter(int id)
        {
            var entity = _partidaRepository.Obter(id);

            PartidaResponse response = new PartidaResponse();

            response.Id = entity.Id;
            response.IdMandante = entity.IdMandante;
            response.IdVisitante = entity.IdVisitante;
            response.Data = entity.Data;
            response.GolsMandante = entity.GolsMandante;
            response.GolsVisitante = entity.GolsVisitante;

            return response;
        }
        public BaseResponse Atualizar(PartidaRequest request)
        {
            if (request.IdMandante == 0)
                return new BaseResponse() { StatusCode = 400, Mensagem = "IdMandante precisa ser preenchido" };

            if (request.IdVisitante == 0)
                return new BaseResponse() { StatusCode = 400, Mensagem = "IdVisitante precisa ser preenchido" };


            Partida partida = new Partida();

            partida.Id = request.Id;
            partida.IdMandante = request.IdMandante;
            partida.IdVisitante = request.IdVisitante;
            partida.Data = request.Data;
            partida.GolsMandante = request.GolsMandante;
            partida.GolsVisitante = request.GolsVisitante;

            _partidaRepository.Atualizar(partida);

            return new BaseResponse() { StatusCode = 200 };


        }
        public BaseResponse Deletar(int Id)
        {
            if (Id == 0)
                return new BaseResponse() { StatusCode = 400, Mensagem = "Id Precisa ser preenchido" };
            _partidaRepository.Deletar(Id);
            return new BaseResponse() { StatusCode = 200 };
        }
    }
}
