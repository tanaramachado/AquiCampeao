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
    public class ClubeService : IClubeService
    {
        private IClubeRepository _clubeRepository;

        public ClubeService(IClubeRepository ClubeRepository)
        {
            _clubeRepository = ClubeRepository;
        }
        public List<ClubeResponse> Listar()
        {
            var clubes = _clubeRepository.Listar();


            List<ClubeResponse> response = new List<ClubeResponse>();

            clubes.ForEach(p =>
            {
                response.Add(new ClubeResponse()
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    NomeEstadio = p.NomeEstadio,
                    AnoFundacao = p.AnoFundacao,
                    Cidade = p.Cidade,


                });


            });

            return response;
        }
        public BaseResponse Inserir(ClubeRequest request)
        {
            if (request.Nome == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "Nome precisa ser preenchido" };

            var clubeExiste = _clubeRepository.ObterPorNome(request.Nome);

            if (clubeExiste != null)
                return new BaseResponse() { StatusCode = 400, Mensagem = "Clube já cadastrado" };

            Clube clube = new Clube();
            clube.Id = request.Id;
            clube.Nome = request.Nome;
            clube.NomeEstadio = request.NomeEstadio;
            clube.AnoFundacao = request.AnoFundacao;
            clube.Cidade = request.Cidade;

            _clubeRepository.Inserir(clube);

            return new BaseResponse() { StatusCode = 201 };

        }
        public ClubeResponse Obter(int id)
        {
            var entity = _clubeRepository.Obter(id);

            ClubeResponse response = new ClubeResponse();

            response.Id = entity.Id;
            response.Nome = entity.Nome;
            response.AnoFundacao = entity.AnoFundacao;
            response.NomeEstadio = entity.NomeEstadio;
            response.Cidade = entity.Cidade;

            return response;
        }
        public BaseResponse Atualizar(ClubeRequest request)
        {
            if (request.Nome == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "Nome precisa ser preenchido" };



            Clube clube = new Clube();

            clube.Id = request.Id;
            clube.Nome = request.Nome;
            clube.NomeEstadio = request.NomeEstadio;
            clube.AnoFundacao = request.AnoFundacao;
            clube.Cidade = request.Cidade;

            _clubeRepository.Atualizar(clube);

            return new BaseResponse() { StatusCode = 200 };


        }
        public BaseResponse Deletar(int Id)
        {
            if (Id == 0)
                return new BaseResponse() { StatusCode = 400, Mensagem = "Id Precisa ser preenchido" };
            _clubeRepository.Deletar(Id);
            return new BaseResponse() { StatusCode = 200 };
        }
    }
}


