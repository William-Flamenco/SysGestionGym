using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGestionGym.EntidadDeNegocio;

public partial class Pago
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

    [InverseProperty("Pago")]
    public Cliente Cliente { get; set; }

    [InverseProperty("Pago")]
    public Membresia Membresia { get; set; }

    [InverseProperty("Pago")]
    public Usuario Usuario { get; set; }
}
