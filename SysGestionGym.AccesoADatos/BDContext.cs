using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using SysGestionGym.EntidadDeNegocio;

namespace SysGestionGym.AccesoADatos
{
    public class BDContext : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
  
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cliente> Membresia { get; set;}
        public DbSet<Pago> Pago { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("workstation id=BDGym2024.mssql.somee.com;packet size=4096;user id=William904_SQLLogin_1;pwd=81arnctd8m;data source=BDGym2024.mssql.somee.com;persist security info=False;initial catalog=BDGym2024;TrustServerCertificate=True");
        }
    }
}
