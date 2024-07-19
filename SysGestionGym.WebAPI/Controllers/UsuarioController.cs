using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysGestionGym.AccesoADatos;
using SysGestionGym.EntidadDeNegocio;

namespace SysGestionGym.WebAPI.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuarios")]
        public async Task<List<Usuario>> Get()
        {
            var listausuarios = await UsuarioDAL.ObtenerTodosAsync();
            if (listausuarios.Count >= 1)
            {
                return listausuarios;
            }
            else
            {
                return new List<Usuario>();
            }

        }


        [HttpPost(Name = "PostUsuario")]
        public async Task<int> Post(Usuario pUsuario)
        {
            if (pUsuario.IdUsuario >= 0)
            {
                int resultado = await UsuarioDAL.CrearAsync(pUsuario);
                return resultado;

            }
            else
            {
                return 0;
            }
        }








    }
}
