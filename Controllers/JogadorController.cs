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
    public class JogadorController
    {
        private IJogadorService _jogardorService;

        public JogadorController(IJogadorService jogadorService)
        {
            _jogardorService = jogadorService;

        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            var response = _jogardorService.Listar();
            return new ObjectResult(response) { StatusCode = 200 };
        }

        [HttpPost("Inserir")]

        public IActionResult Inserir([FromBody] JogadorRequest request)
        {
           _jogardorService.Inserir(request);
            return new ObjectResult(new { }) { StatusCode = 201 };
        }

        [HttpGet("obter")]

        public IActionResult Obter([FromQuery]int id)
        {
            var response = _jogardorService.Obter(id);
            return new ObjectResult(response) { StatusCode = 200 };
        }

        [HttpPut("atualizar")]

        public IActionResult Atualizar([FromBody] JogadorRequest request)
        {
            var response = _jogardorService.Atualizar(request);
            return new ObjectResult(response) { StatusCode = response.StatusCode};
        }

        [HttpDelete("deletar")]

        public IActionResult Deletar([FromQuery] int Id)
        {
            var response = _jogardorService.Deletar(Id);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}

