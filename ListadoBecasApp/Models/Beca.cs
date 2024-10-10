using System;
using System.Collections.Generic;

namespace ListadoBecasApp.Models;

public partial class Beca
{
    public int IdBeca { get; set; }

    public string NombreBeca { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int PorcentajeBeca { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public int IdCarrera { get; set; }

    public virtual Carrera? IdCarreraNavigation { get; set; } 

}
