using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain.Model;
using ProAgil.Repository.Interface;

namespace ProAgil.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PalestranteController : ControllerBase
    {
        private readonly IProAgilRepository _repository;

        public PalestranteController(IProAgilRepository repository)
        {
            _repository = repository;
        }
  
       [HttpGet("GetById/{PalestranteId}")]
       public async Task<IActionResult> GetById(int palestranteId)
        {
            try
            {
                var r = await _repository.GetAllPalestrantesAsyncById(palestranteId, true);
                return Ok(r);    
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "falhou");
            }
        }

        [HttpGet("ByName/{nome}")]
        public async Task<IActionResult> GetById(string nome)
        {
            try
            {
                var r = await _repository.GetAllPalestrantesAsyncByName(nome, true);
                return Ok(r);    
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "falhou");
            }
        }
    }
}