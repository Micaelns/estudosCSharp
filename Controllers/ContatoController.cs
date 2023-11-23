using Microsoft.AspNetCore.Mvc;
using moduloApi.Context;
using moduloApi.Entities;

namespace ModuloApi.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return Ok(contato);
        }

        [HttpGet("{Id}")]
        public IActionResult ObterPorId(int Id)
        {
            var contato = _context.Contatos.Find(Id);
            if ( contato == null)
            {
                return NotFound();
            }
            return Ok(contato);
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            var contatos = _context.Contatos.ToList();
            return Ok(contatos);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(String nome)
        {
            var contatos = _context.Contatos.Where(c => c.Nome.Contains(nome));
            return Ok(contatos);
        }

        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id, Contato contato)
        {
            var contatoAtual = _context.Contatos.Find(Id);
            if ( contatoAtual == null)
            {
                return NotFound();
            }
            contatoAtual.Nome = contato.Nome;
            contatoAtual.Telefone = contato.Telefone;
            contatoAtual.Ativo = contato.Ativo;
            _context.Contatos.Update(contatoAtual);
            _context.SaveChanges();

            return Ok(contatoAtual);
        }

        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            var contato = _context.Contatos.Find(Id);
            if ( contato == null)
            {
                return NotFound();
            }
            _context.Contatos.Remove(contato);
            _context.SaveChanges();
            return NoContent();
        }
    }
}