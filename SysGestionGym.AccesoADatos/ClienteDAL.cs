using Microsoft.EntityFrameworkCore;
using SysGestionGym.EntidadDeNegocio;
using SysGestionGym.EntidadDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGestionGym.AccesoADatos
{
    public class ClienteDAL
    {
        #region CRUD
        public static async Task<int> CrearAsync(Cliente pCliente)
        {
            int result = 0;
            using (var bdContexto = new BDContext())
            {
                pCliente.FechaRegistro = DateTime.Now;
                bdContexto.Add(pCliente);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Cliente pCliente)
        {
            int result = 0;
            using (var bdContexto = new BDContext())
            {
                var cliente = await bdContexto.Cliente.FirstOrDefaultAsync(s => s.IdCliente == pCliente.IdCliente);
                if (cliente != null)
                {
                    cliente.Nombre = pCliente.Nombre;
                    cliente.Apellido = pCliente.Apellido;
                    cliente.Peso = pCliente.Peso;
                    cliente.Altura = pCliente.Altura;
                    bdContexto.Update(cliente);
                    result = await bdContexto.SaveChangesAsync();
                }
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Cliente pCliente)
        {
            int result = 0;
            using (var bdContexto = new BDContext())
            {
                var cliente = await bdContexto.Cliente.FirstOrDefaultAsync(s => s.IdCliente == pCliente.IdCliente);
                if (cliente != null)
                {
                    bdContexto.Cliente.Remove(cliente);
                    result = await bdContexto.SaveChangesAsync();
                }
            }
            return result;
        }

        public static async Task<Cliente> ObtenerPorIdAsync(int idCliente)
        {
            Cliente cliente = null;
            using (var bdContexto = new BDContext())
            {
                cliente = await bdContexto.Cliente.FirstOrDefaultAsync(s => s.IdCliente == idCliente);
            }
            return cliente;
        }

        public static async Task<List<Cliente>> ObtenerTodosAsync()
        {
            List<Cliente> clientes;
            using (var bdContexto = new BDContext())
            {
                clientes = await bdContexto.Cliente.ToListAsync();
            }
            return clientes;
        }

        internal static IQueryable<Cliente> QuerySelect(IQueryable<Cliente> pQuery, Cliente pCliente)
        {
            if (pCliente.IdCliente > 0)
                pQuery = pQuery.Where(s => s.IdCliente == pCliente.IdCliente);
            if (!string.IsNullOrWhiteSpace(pCliente.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pCliente.Nombre));
            if (!string.IsNullOrWhiteSpace(pCliente.Apellido))
                pQuery = pQuery.Where(s => s.Apellido.Contains(pCliente.Apellido));
            if (pCliente.Peso > 0)
                pQuery = pQuery.Where(s => s.Peso == pCliente.Peso);
            if (pCliente.Altura > 0)
                pQuery = pQuery.Where(s => s.Altura == pCliente.Altura);
            if (pCliente.FechaRegistro.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pCliente.FechaRegistro.Year, pCliente.FechaRegistro.Month, pCliente.FechaRegistro.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.FechaRegistro >= fechaInicial && s.FechaRegistro <= fechaFinal);
            }
            pQuery = pQuery.OrderByDescending(s => s.IdCliente).AsQueryable();
            if (pCliente.Top_Aux > 0)
                pQuery = pQuery.Take(pCliente.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Cliente>> BuscarAsync(Cliente pCliente)
        {
            List<Cliente> clientes;
            using (var bdContexto = new BDContext())
            {
                var select = bdContexto.Cliente.AsQueryable();
                select = QuerySelect(select, pCliente);
                clientes = await select.ToListAsync();
            }
            return clientes;
        }
        #endregion

    }
}
