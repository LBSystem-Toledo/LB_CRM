using Dominio;
using LB_API.DAO.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LB_API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class UFController : ControllerBase
    {
        private readonly IUF _UF;
        public UFController(IUF uf) { _UF = uf; }

        [HttpGet, Route("GetAllAsync")]
        public async Task<ActionResult<UF>> Get()
        {
            try
            {
                var retorno = await _UF.GetAsync();
                return Ok(retorno);
            }
            catch { return NotFound(); }
        }
        [HttpGet, Route("GetAsync")]
        public async Task<IEnumerable<UF>?> Get(string ds_uf)
        {
            try
            {
                var retorno = await _UF.GetAsync(ds_uf);
                return retorno;
            }
            catch { return null; }
        }
        [HttpPost, Route("GravarAsync")]
        public async Task<ActionResult<bool>> GravarAsync(UF uf)
        {
            try
            {
                var retorno = await _UF.GravarAsync(uf);
                return Ok(retorno);
            }
            catch { return NotFound(); }
        }
        [HttpDelete, Route("DeleteAsync")]
        public async Task<ActionResult<bool>> DeleteAsync(string cd_uf)
        {
            try
            {
                var retorno = await _UF.DeleteAsync(cd_uf);
                return Ok(retorno);
            }
            catch { return NotFound(); }
        }
    }
}
