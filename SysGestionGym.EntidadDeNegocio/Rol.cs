using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGestionGym.EntidadDeNegocio
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "Descripción es obligatorio")]
        [StringLength(30, ErrorMessage = "La descripción debe tener menos de 30 caracteres.")]
        public string? DescripcionRol { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        public List<Usuario>? Usuario { get; set; }
    }
}
