using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using web2REST.Model;
using web2REST.Business;
using web2REST.Dto;

namespace web2REST.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("RestAPIFurb/[controller]/v{version:apiVersion}")]
    public class ComandaController : ControllerBase
    {

        private readonly ILogger<ComandaController> _logger;
        private IComandasBusiness _comandaBusiness;

        public ComandaController(ILogger<ComandaController> logger, IComandasBusiness comandaBusiness)
        {
            _logger = logger;
            _comandaBusiness = comandaBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = _comandaBusiness.FindAll();
            var dtoList = list.Select(x => new ComandaDto
            {
                IdUsuario = x.IdUsuario,
                NomeUsuario = x.NomeUsuario,
                TelefoneUsuario = x.TelefoneUsuario
            });
            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _comandaBusiness.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Comanda comanda)
        {
            if (comanda == null) return BadRequest();
            return Ok(_comandaBusiness.Create(comanda));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Comanda comanda)
        {
            if (comanda == null) return BadRequest();
            return Ok(_comandaBusiness.Update(comanda));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _comandaBusiness.Delete(id);
            return NoContent();
        }
    }
}
