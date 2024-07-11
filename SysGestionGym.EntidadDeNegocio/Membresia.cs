using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGestionGym.EntidadDeNegocio;

public partial class Membresia
{
    [Key]
    public int IdMembresia { get; set; }

    [Required(ErrorMessage = "Tipo de membresia es obligatorio")]
    [StringLength(50, ErrorMessage = "La descripción de membresia debe tener menos de 50 caracteres.")]
    public string TipoDeMembresia { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    [Required(ErrorMessage = "Precio es obligatorio")]
    public decimal Precio { get; set; }

    [Required(ErrorMessage = "La duración de la membrecia es obligatorio")]
    public int DuracionDias { get; set; }

    [NotMapped]
    public int Top_Aux { get; set; }

    [InverseProperty("IdMembresiaNavigation")]
    public List<Pago> Pago { get; set; }}
