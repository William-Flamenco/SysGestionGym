using SysGestionGym.AccesoADatos;
using SysGestionGym.EntidadDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGestionGym.LogicaDeNegocio
{
    public class PagoBL
    {
        public async Task<int> CrearAsync(Pago pPago)
        {
            return await PagoDAL.CrearAsync(pPago);
        }

        public async Task<int> ModificarAsync(Pago pPago)
        {
            return await PagoDAL.ModificarAsync(pPago);
        }

        public async Task<int> EliminarAsync(Pago pPago)
        {
            return await PagoDAL.EliminarAsync(pPago);
        }

        public async Task<Pago> ObtenerPorIdAsync(int idPago)
        {
            return await PagoDAL.ObtenerPorIdAsync(idPago);
        }

        public async Task<List<Pago>> ObtenerTodosAsync()
        {
            return await PagoDAL.ObtenerTodosAsync();
        }

        public async Task<List<Pago>> BuscarAsync(Pago pPago)
        {
            return await PagoDAL.BuscarAsync(pPago);
        }
    }
}
