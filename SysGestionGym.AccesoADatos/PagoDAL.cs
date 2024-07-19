using Microsoft.EntityFrameworkCore;
using SysGestionGym.EntidadDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGestionGym.AccesoADatos
{
    public class PagoDAL
    {
        #region CRUD
        public static async Task<int> CrearAsync(Pago pPago)
        {
            int result = 0;
            using (var bdContexto = new BDContext())
            {
                bdContexto.Add(pPago);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Pago pPago)
        {
            int result = 0;
            using (var bdContexto = new BDContext())
            {
                var pago = await bdContexto.Pago.FirstOrDefaultAsync(s => s.IdPago == pPago.IdPago);
                if (pago != null)
                {
                    pago.IdUsuario = pPago.IdUsuario;
                    pago.IdCliente = pPago.IdCliente;
                    pago.IdMembresia = pPago.IdMembresia;
                    pago.FechaPago = pPago.FechaPago;
                    pago.FechaCaducidad = pPago.FechaCaducidad;
                    bdContexto.Update(pago);
                    result = await bdContexto.SaveChangesAsync();
                }
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Pago pPago)
        {
            int result = 0;
            using (var bdContexto = new BDContext())
            {
                var pago = await bdContexto.Pago.FirstOrDefaultAsync(s => s.IdPago == pPago.IdPago);
                if (pago != null)
                {
                    bdContexto.Pago.Remove(pago);
                    result = await bdContexto.SaveChangesAsync();
                }
            }
            return result;
        }

        public static async Task<Pago> ObtenerPorIdAsync(int idPago)
        {
            Pago pago = null;
            using (var bdContexto = new BDContext())
            {
                pago = await bdContexto.Pago.FirstOrDefaultAsync(s => s.IdPago == idPago);
            }
            return pago;
        }

        public static async Task<List<Pago>> ObtenerTodosAsync()
        {
            List<Pago> pagos;
            using (var bdContexto = new BDContext())
            {
                pagos = await bdContexto.Pago.ToListAsync();
            }
            return pagos;
        }

        internal static IQueryable<Pago> QuerySelect(IQueryable<Pago> pQuery, Pago pPago)
        {
            if (pPago.IdPago > 0)
                pQuery = pQuery.Where(s => s.IdPago == pPago.IdPago);
            if (pPago.IdUsuario > 0)
                pQuery = pQuery.Where(s => s.IdUsuario == pPago.IdUsuario);
            if (pPago.IdCliente > 0)
                pQuery = pQuery.Where(s => s.IdCliente == pPago.IdCliente);
            if (pPago.IdMembresia > 0)
                pQuery = pQuery.Where(s => s.IdMembresia == pPago.IdMembresia);
            if (pPago.FechaPago.Year > 1000)
            {
                DateOnly fechaInicial = pPago.FechaPago;
                DateOnly fechaFinal = fechaInicial.AddDays(1);
                pQuery = pQuery.Where(s => s.FechaPago >= fechaInicial && s.FechaPago < fechaFinal);
            }
            if (pPago.FechaCaducidad.Year > 1000)
            {
                DateOnly fechaInicial = pPago.FechaCaducidad;
                DateOnly fechaFinal = fechaInicial.AddDays(1);
                pQuery = pQuery.Where(s => s.FechaCaducidad >= fechaInicial && s.FechaCaducidad < fechaFinal);
            }
            pQuery = pQuery.OrderByDescending(s => s.IdPago).AsQueryable();
            if (pPago.Top_Aux > 0)
                pQuery = pQuery.Take(pPago.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Pago>> BuscarAsync(Pago pPago)
        {
            List<Pago> pagos;
            using (var bdContexto = new BDContext())
            {
                var select = bdContexto.Pago.AsQueryable();
                select = QuerySelect(select, pPago);
                pagos = await select.ToListAsync();
            }
            return pagos;
        }
        #endregion
    }
}
