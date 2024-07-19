using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysGestionGym.AccesoADatos;
using SysGestionGym.EntidadDeNegocio;

namespace SysGestionGym.WebAPI.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        [HttpGet(Name = "GetClientes")]
        public async Task<List<Cliente>> Get()
        {
            var listaroles = await ClienteDAL.ObtenerTodosAsync();
            if (listaroles.Count >= 1)
            {
                return listaroles;
            }
            else
            {
                return new List<Cliente>();
            }

        }


        [HttpPost(Name = "PostCliente")]
        public async Task<int> Post(Cliente pCliente)
        {
            if (pCliente.IdCliente >= 0)
            {
                int resultado = await ClienteDAL.CrearAsync(pCliente);
                return resultado;

            }
            else
            {
                return 0;
            }
        }



    }
}
