using Dominio;
using LB_API.DAO.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LB_API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class SegmentoController : ControllerBase
    {
        private readonly ISegmento _query;
        public SegmentoController(ISegmento query) { _query = query; }

        [HttpGet, Route("GetAllAsync")]
        public async Task<ActionResult<Segmento>> Get()
        {
            try
            {
                var retorno = await _query.GetAsync(String.Empty);
                return Ok(retorno);
            }
            catch { return NotFound(); }
        }
        [HttpGet, Route("GetAsync")]
        public async Task<IEnumerable<Segmento>?> Get(string Ds_segmento)
        {
            try
            {
                var retorno = await _query.GetAsync(Ds_segmento);
                return retorno;
            }
            catch { return null; }
        }
        [HttpPost, Route("GravarAsync")]
        public async Task<ActionResult<bool>> GravarAsync(Segmento segmento)
        {
            try
            {
                var retorno = await _query.UpersertAsync(segmento);
                return Ok(retorno);
            }
            catch { return NotFound(); }
        }
        [HttpDelete, Route("DeleteAsync")]
        public async Task<ActionResult<bool>> DeleteAsync(int Id_segmento)
        {
            try
            {
                var retorno = await _query.DeleteAsync(Id_segmento);
                return Ok(retorno);
            }
            catch { return NotFound(); }
        }
    }
}
