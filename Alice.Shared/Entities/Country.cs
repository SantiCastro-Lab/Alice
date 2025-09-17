﻿using System.ComponentModel.DataAnnotations;

namespace Alice.Shared.Entities;

public class Country
{
    public int Id { get; set; }

    [Display(Name = "País")]
    [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Name { get; set; } = string.Empty;
}