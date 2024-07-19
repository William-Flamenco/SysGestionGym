using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGestionGym.EntidadDeNegocio
{
    public class Pago
    {

        [Key]
        public int IdPago { get; set; }
        [ForeignKey("IdUsuario")]
        [Required(ErrorMessage = "Id Usuario es obligatorio")]
        public int IdUsuario { get; set; }
        [ForeignKey("IdCliente")]
        [Required(ErrorMessage = "Id Cliente es obligatorio")]
        public int IdCliente { get; set; }
        [ForeignKey("IdMembresia")]
        [Required(ErrorMessage = "Id Membresia es obligatorio")]
        public int IdMembresia { get; set; }

        [Required(ErrorMessage = "Fecha de pago es obligatorio")]
        public DateOnly FechaPago { get; set; }
        [Required(ErrorMessage = "Fecha caducidad es obligatorio")]
        public DateOnly FechaCaducidad { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

 
        public Cliente Cliente { get; set; }

        public Membresia Membresia { get; set; }

        public Usuario Usuario { get; set; }
    }
}
