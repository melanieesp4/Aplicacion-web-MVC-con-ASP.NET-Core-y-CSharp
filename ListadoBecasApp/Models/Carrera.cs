using System;
using System.Collections.Generic;

namespace ListadoBecasApp.Models;

public partial class Carrera
{
    public int IdCarrera { get; set; }

    public string NombreCarrera { get; set; } = null!;

    public virtual ICollection<Beca> Becas { get; set; } = new List<Beca>();
}
