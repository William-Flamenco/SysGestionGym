
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGestionGym.EntidadDeNegocio
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Nombre debe tener menos de 30 caracteres.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "Apellido es obligatorio")]
        [StringLength(30, ErrorMessage = "Apellido debe tener menos de 30 caracteres.")]
        public string Apellido { get; set; } = null!;

        [Column(TypeName = "decimal(5, 2)")]
        [Required(ErrorMessage = "Peso es obligatorio")]
        public decimal Peso { get; set; }
        [Required(ErrorMessage = "Altura es obligatorio")]
        public int Altura { get; set; }
        [Required(ErrorMessage = "Fecha de registro es obligatorio")]
        public DateTime FechaRegistro { get; set; }


        [NotMapped]
        public int Top_Aux { get; set; }

        public List<Pago> Pago { get; set; }


    }
}
