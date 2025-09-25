using Alice.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alice.Shared.Entities;

public class City : IEntityWithName
{
    public int Id { get; set; }

    [Display(Name = "Ciudad")]
    [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
    [MinLength(3, ErrorMessage = "El campo {0} debe tener al menos {1} caracteres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Name { get; set; } = string.Empty;

    public int StateId { get; set; }

    public State? State { get; set; }
}