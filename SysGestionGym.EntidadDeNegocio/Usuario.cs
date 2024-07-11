using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGestionGym.EntidadDeNegocio;

public partial class Usuario
{
    [Key]
    public int IdUsuario { get; set; }

    [ForeignKey("IdRol")]
    [Required(ErrorMessage = "Rol es obligatorio")]
    [Display(Name = "Rol")]
    public int IdRol { get; set; }

    [Required(ErrorMessage = "Nombre es obligatorio")]
    [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "Apellido es obligatorio")]
    [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
    public string Apellido { get; set; } = null!;


    [NotMapped]
    public int Top_Aux { get; set; }

    [InverseProperty("Usuario")]
    public Rol Rol { get; set; }

    //public virtual Rol IdRolNavigation { get; set; } = null!;

    //[InverseProperty("IdUsuarioNavigation")]
    //public virtual ICollection<Pago> Pago { get; set; } = new List<Pago>();
}
