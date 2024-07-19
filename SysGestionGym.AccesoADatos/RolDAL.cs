using Microsoft.EntityFrameworkCore;
using SysGestionGym.EntidadDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGestionGym.AccesoADatos
{
    public class RolDAL
    {
        public static async Task<int> CrearAsync(Rol pRol)
        {
            int result = 0;
            using (var bdContexto = new BDContext())
            {
                bdContexto.Add(pRol);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Rol pRol)
        {
            int result = 0;
            using (var bdContexto = new BDContext())
            {
                var rol = await bdContexto.Rol.FirstOrDefaultAsync(s => s.IdRol == pRol.IdRol);
                if (rol != null)
                {
                    rol.DescripcionRol = pRol.DescripcionRol;
                    bdContexto.Update(rol);
                    result = await bdContexto.SaveChangesAsync();
                }
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Rol pRol)
        {
            int result = 0;
            using (var bdContexto = new BDContext())
            {
                var rol = await bdContexto.Rol.FirstOrDefaultAsync(s => s.IdRol == pRol.IdRol);
                if (rol != null)
                {
                    bdContexto.Rol.Remove(rol);
                    result = await bdContexto.SaveChangesAsync();
                }
            }
            return result;
        }

        public static async Task<Rol> ObtenerPorIdAsync(int idRol)
        {
            Rol rol = null;
            using (var bdContexto = new BDContext())
            {
                rol = await bdContexto.Rol.FirstOrDefaultAsync(s => s.IdRol == idRol);
            }
            return rol;
        }

        public static async Task<List<Rol>> ObtenerTodosAsync()
        {
            List<Rol> roles;
            using (var bdContexto = new BDContext())
            {
                roles = await bdContexto.Rol.ToListAsync();
            }
            return roles;
        }

        internal static IQueryable<Rol> QuerySelect(IQueryable<Rol> pQuery, Rol pRol)
        {
            if (pRol.IdRol > 0)
                pQuery = pQuery.Where(s => s.IdRol == pRol.IdRol);
            if (!string.IsNullOrWhiteSpace(pRol.DescripcionRol))
                pQuery = pQuery.Where(s => s.DescripcionRol.Contains(pRol.DescripcionRol));
            pQuery = pQuery.OrderByDescending(s => s.IdRol).AsQueryable();
            if (pRol.Top_Aux > 0)
                pQuery = pQuery.Take(pRol.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Rol>> BuscarAsync(Rol pRol)
        {
            List<Rol> roles;
            using (var bdContexto = new BDContext())
            {
                var select = bdContexto.Rol.AsQueryable();
                select = QuerySelect(select, pRol);
                roles = await select.ToListAsync();
            }
            return roles;
        }

        //------------------------------------------------------------------------------------
        public static async Task<Rol> ObtenerPorIdAsync(Rol pRol)
        {
            throw new NotImplementedException();
        }
    }
}
