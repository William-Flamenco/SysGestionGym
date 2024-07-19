using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysGestionGym.AccesoADatos;
using SysGestionGym.EntidadDeNegocio;

namespace SysGestionGym.WebAPI.Controllers
{
    [Route("api/rol")]
    [ApiController]
    public class RolController : ControllerBase
    {


        [HttpGet(Name = "GetRoles")]
        public async Task<List<Rol>> Get()
        {
            var listaroles = await RolDAL.ObtenerTodosAsync();
            if (listaroles.Count >= 1)
            {
                return listaroles;
            }
            else
            {
                return new List<Rol>();
            }

        }


        [HttpPost(Name = "PostRol")]
        public async Task<int> Post(Rol pRol)
        {
            if (pRol.IdRol >= 0)
            {
                int resultado = await RolDAL.CrearAsync(pRol);
                return resultado;

            }
            else
            {
                return 0;
            }
        }






    }
}
