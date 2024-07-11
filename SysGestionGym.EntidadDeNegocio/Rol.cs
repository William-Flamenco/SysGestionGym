using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGestionGym.EntidadDeNegocio;

public partial class Rol
{
    [Key]
    public int IdRol { get; set; }

    [Required(ErrorMessage = "Descripción es obligatorio")]
    [StringLength(30, ErrorMessage ="La descripción debe tener menos de 30 caracteres.")]
    public string DescripcionRol { get; set; } = null!;

    [NotMapped]
    public int Top_Aux { get; set; }
    public List<Usuario>? Usuarios { get; set; }

    //[InverseProperty("IdRolNavigation")]
    //public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
