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
    public class ClubeController
    {
        private IClubeService _clubeService;

        public ClubeController(IClubeService clubeService)
        {
            _clubeService = clubeService;

        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            var response = _clubeService.Listar();
            return new ObjectResult(response) { StatusCode = 200 };
        }

        [HttpPost("Inserir")]

        public IActionResult Inserir([FromBody] ClubeRequest request)
        {
            var resultado = _clubeService.Inserir(request);
            return new ObjectResult(resultado) { StatusCode = resultado.StatusCode };
        }
        [HttpGet("obter")]

        public IActionResult Obter([FromQuery] int id)
        {
            var response = _clubeService.Obter(id);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
        [HttpPut("atualizar")]

        public IActionResult Atualizar([FromBody] ClubeRequest request)
        {
            var response = _clubeService.Atualizar(request);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
        [HttpDelete("deletar")]

        public IActionResult Deletar([FromQuery] int Id)
        {
            var response = _clubeService.Deletar(Id);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

    }


}
