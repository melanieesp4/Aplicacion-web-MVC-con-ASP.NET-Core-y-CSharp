
using System;

namespace ListadoBecasApp.DTOs;

public class BecaDto
{
    public int IdBeca { get; set; }

    public string NombreBeca { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int PorcentajeBeca { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public int IdCarrera { get; set; }

    public string? NombreCarrera { get; set; }
}
