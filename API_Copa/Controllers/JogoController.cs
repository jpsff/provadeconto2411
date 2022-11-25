using System.Collections.Generic;
using System.Linq;
using api.Models;
using API_Copa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/jogo")]
    public class JogoController : ControllerBase
    {
        private readonly Context _context;
        public JogoController(Context context) =>
            _context = context;

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Jogo jogo)
        {
            jogo.SelecaoA = _context.Selecoes.Find(jogo.SelecaoA.Id);
            jogo.SelecaoB = _context.Selecoes.Find(jogo.SelecaoB.Id);
            _context.Jogos.Add(jogo);
            _context.SaveChanges();
            return Created("Jogo Criado com Sucesso", jogo);
        }

        [HttpPost]
        [Route("palpitar")]
        public IActionResult Palpitar([FromBody] Jogo palpite)
        {
            Jogo jogo = _context.Jogos.Find(palpite.Id);
            jogo.PlacarA = palpite.PlacarA;
            jogo.PlacarB = palpite.PlacarB;
            _context.Jogos.Update(jogo);
            _context.SaveChanges();
            return Created("Palpite registrado", jogo);
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            List<Jogo> jogos = _context.Jogos.ToList();
            return jogos.Count != 0 ? Ok(jogos) : NotFound();
        }
    }
}