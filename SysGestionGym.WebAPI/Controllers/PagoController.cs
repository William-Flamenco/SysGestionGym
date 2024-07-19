using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysGestionGym.AccesoADatos;
using SysGestionGym.EntidadDeNegocio;

namespace SysGestionGym.WebAPI.Controllers
{
    [Route("api/pago")]
    [ApiController]
    public class PagoController : ControllerBase
    {

        [HttpGet(Name = "GetPagos")]
        public async Task<List<Pago>> Get()
        {
            var listapagos = await PagoDAL.ObtenerTodosAsync();
            if (listapagos.Count >= 1)
            {
                return listapagos;
            }
            else
            {
                return new List<Pago>();
            }

        }


        [HttpPost(Name = "PostPago")]
        public async Task<int> Post(Pago pPago)
        {
            if (pPago.IdPago >= 0)
            {
                int resultado = await PagoDAL.CrearAsync(pPago);
                return resultado;

            }
            else
            {
                return 0;
            }
        }


    }
}
