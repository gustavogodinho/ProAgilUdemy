using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain.Model;
using ProAgil.Repository.Interface;

namespace ProAgil.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        public readonly IProAgilRepository _repository;
        public EventoController(IProAgilRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var r = await _repository.GetAllEventoAsync(true);
                return Ok(r);    
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "falhou");
            }
        }

        [HttpGet("GetById/{EventoId}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var r = await _repository.GetAllEventoAsyncById(id, true);
                return Ok(r);    
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "falhou");
            }
        }

        [HttpGet("getByTema/{Tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var r = await _repository.GetAllEventoAsyncByTema(tema, true);
                return Ok(r);    
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "falhou");
            }
        }

        [HttpPost("Adicionar")]
        public async Task<IActionResult> Adicionar(Evento evento)
        {
            try
            {
                 _repository.Add(evento);

                 if(await _repository.SaveChangesAsync())
                 {
                   return Created($"/evento/{evento.Id}", evento);
                 }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "falhou");
            }
            return BadRequest();
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> Atualizar(int eventoId, Evento evento)
        {
            try
            {
               if (await _repository.GetAllEventoAsyncById(eventoId, false) == null)
                return NotFound();

                _repository.Update(evento);

                 if(await _repository.SaveChangesAsync())
                 {
                   return Created($"/evento/{evento.Id}", evento);
                 }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "falhou");
            }

            return BadRequest();
        }

        [HttpDelete("Deletar")]
        public async Task<IActionResult> Deletar(int eventoId)
        {
            try
            {
               var r = await _repository.GetAllEventoAsyncById(eventoId, false);
               if ( r == null)
                return NotFound();

                _repository.Delete(r);

                 if(await _repository.SaveChangesAsync())
                 {
                   return Created($"/evento/{r.Id}", r);
                 }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "falhou");
            }

            return BadRequest();
        }


    }
}