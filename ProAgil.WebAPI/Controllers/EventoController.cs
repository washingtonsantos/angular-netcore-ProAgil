using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.WebAPI.Data;
using System.Threading.Tasks;

namespace ProAgil.WebAPI.Controllers
{
    [ApiController]
    [Route("evento")]
    public class EventoController : ControllerBase
    {
        public readonly DataContext _context;
        public EventoController(DataContext contexto)
        {
           _context = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                 var results = await _context.Eventos.ToListAsync();

                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }                
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
             try
            {
                 var results = await _context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);

                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }  
        }
    }
}