using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Repository.Context;
using ProAgil.Repository.Interface;
using ProAgil.WebAPI.Dtos;

namespace ProAgil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PrivateController : ControllerBase
    {

        private readonly IProAgilRepository _repo;
        private readonly IMapper _mapper;

        public PrivateController(IProAgilRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get(PRV_CONTROLE pRV)
        {
            try
            {
                var prv = new PRV_CONTROLE();

                return Ok(prv);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpGet("ExecutaProcessamentoCorretora")]
        [AllowAnonymous]
        public IActionResult ExecutaProcessamentoCorretora(int x)
        {
            try
            {
                Task<int> q;

                bool processoLiberado = false;

                while (!processoLiberado)
                {
                    Thread.Sleep(2000);
                    q = _repo.CountControle();
                        

                    if (q.Result > 0)
                    {
                        processoLiberado = true;
                        System.Console.WriteLine("Processo liberado");
                    }
                    else
                    {
                        System.Console.WriteLine("Processo não liberado");
                    }
                }


                return Ok("ok");
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }




    }

}