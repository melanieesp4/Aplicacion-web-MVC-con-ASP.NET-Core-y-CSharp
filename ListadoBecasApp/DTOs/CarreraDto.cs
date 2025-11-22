using Microsoft.AspNetCore.Mvc;

namespace ListadoBecasApp.DTOs
{
    public class CarreraDto
    {
        public int IdCarrera { get; set; }
        public string NombreCarrera { get; set; } = null!;
    }
}
