using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.WebAPI.Data;
using ProAgil.WebAPI.Model;

namespace ProAgil.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DataContext _datacontext;
        public WeatherForecastController(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var r = await _datacontext.Eventos.ToListAsync(); 
                return Ok(r);    
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "falhou");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>  Get(int id)
        {
            try
            {
                var r = await _datacontext.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);
                return Ok(r);    
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "falhou");
            }
        }
    }
}
