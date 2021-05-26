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
    public class JogadorService : IJogadorService
    {
        private IJogadorRepository _jogadorRepository;

        public JogadorService(IJogadorRepository jogadorRepository)
        {
            _jogadorRepository = jogadorRepository;
        }
        public List<JogadorResponse> Listar()
        {
            var jogadores = _jogadorRepository.Listar();
            

            List<JogadorResponse> response = new List<JogadorResponse>();

            jogadores.ForEach(p =>
            {
                response.Add(new JogadorResponse() 
                {
                     Id = p.Id,
                     Nome = p.Nome,
                     Posicao = p.Posicao,
                     IdClube = p.IdClube,
                     PeBom = p.PeBom,


                });
                
             
            });

            return response;
        }


        public BaseResponse Inserir(JogadorRequest request)
        {
            if (request.Nome == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "Nome precisa ser preenchido" };

      

            Jogador jogador = new Jogador();

            jogador.Id = request.Id;
            jogador.Nome = request.Nome;
            jogador.Posicao = request.Posicao;
            jogador.IdClube = request.IdClube;
            jogador.PeBom = request.PeBom;

            _jogadorRepository.Inserir(jogador);

            return new BaseResponse() { StatusCode = 201 };

        }

        public JogadorResponse Obter(int id)
        {
            var entity = _jogadorRepository.Obter(id);

            JogadorResponse response = new JogadorResponse();

            response.Id = entity.Id;
            response.Nome = entity.Nome;
            response.Posicao = entity.Posicao;
            response.IdClube = entity.IdClube;
            response.PeBom = entity.PeBom;

            return response;
        }
        public BaseResponse Atualizar(JogadorRequest request)
        {
            if (request.Nome == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "Nome precisa ser preenchido" };



            Jogador jogador = new Jogador();

            jogador.Id = request.Id;
            jogador.Nome = request.Nome;
            jogador.Posicao = request.Posicao;
            jogador.IdClube = request.IdClube;
            jogador.PeBom = request.PeBom;
            
            _jogadorRepository.Atualizar(jogador);

            return new BaseResponse() { StatusCode = 200 };


        } 
        public BaseResponse Deletar (int Id)
        {
            if (Id == 0)
                return new BaseResponse() { StatusCode = 400, Mensagem = "Id Precisa ser preenchido" };
            _jogadorRepository.Deletar(Id);
            return new BaseResponse() { StatusCode = 200 };
        }
    
    

    }



}
