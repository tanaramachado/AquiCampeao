using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampeonatoAquiCampeao.Interface;
using CampeonatoAquiCampeao.Model;
using Microsoft.AspNetCore.Mvc;

namespace CampeonatoAquiCampeao.Controllers
{
    [Route("[controller]")]
    public class PartidaController
    {
        private IPartidaService _partidaService;

        public PartidaController(IPartidaService partidaService)
        {
            _partidaService = partidaService;

        }
        [HttpGet("listar")]
        public IActionResult Listar()
        {
            var response = _partidaService.Listar();
            return new ObjectResult(response) { StatusCode = 200 };
        }
        [HttpPost("Inserir")]

        public IActionResult Inserir([FromBody] PartidaRequest request)
        {
            var response = _partidaService.Inserir(request);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
        [HttpGet("obter")]

        public IActionResult Obter([FromQuery] int id)
        {
            var response = _partidaService.Obter(id);
            return new ObjectResult(response) { StatusCode = 200 };
        }

        [HttpPut("atualizar")]

        public IActionResult Atualizar([FromBody] PartidaRequest request)
        {
            var response = _partidaService.Atualizar(request);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
        [HttpDelete("deletar")]

        public IActionResult Deletar([FromQuery] int Id)
        {
            var response = _partidaService.Deletar(Id);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
        [HttpGet("listarClassificacao")]
        public IActionResult Classificacao()
        {
            var response = _partidaService.Classificacao();
            return new ObjectResult(response) { StatusCode = 200 };
        }
    }
}
