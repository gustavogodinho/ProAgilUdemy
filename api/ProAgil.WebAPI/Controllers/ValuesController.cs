using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.Repository.Context;

namespace ProAgil.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly ProAgilContext _datacontext;
        public ValuesController(ProAgilContext datacontext)
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
                var r = await _datacontext.Eventos.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(r);    
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "falhou");
            }
        }
    }
}
