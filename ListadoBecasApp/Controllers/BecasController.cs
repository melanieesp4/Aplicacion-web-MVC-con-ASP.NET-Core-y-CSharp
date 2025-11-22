
using ListadoBecasApp.DTOs;
using ListadoBecasApp.Services;
using Microsoft.AspNetCore.Mvc;

public class BecasController : Controller
{
    private readonly IBecaService _service;

    private readonly ICarreraService _carreraService;

    public BecasController(IBecaService service, ICarreraService carreraService)
    {
        _service = service;
        _carreraService = carreraService;
    }

    public async Task<IActionResult> Index(int? carreraId)
    {
        // Cargar carreras
        ViewBag.Carreras = await _carreraService.GetAllAsync();

        // Cargar becas filtradas
        var becas = await _service.GetAllAsync(carreraId);

        // Si hay carrera, mostrar el porcentaje
        if (carreraId.HasValue)
        {
            var beca = becas.FirstOrDefault();
            if (beca != null)
                ViewBag.PorcentajeBeca = beca.PorcentajeBeca;
        }

        return View(becas);
    }
    // GET: Becas/Administrations
    [HttpGet]
    public async Task<IActionResult> Administrations(string sortOrder)
    {
        // Configurar opciones de ordenamiento
        ViewBag.NombreSort = sortOrder == "nombre_asc" ? "nombre_desc" : "nombre_asc";
        ViewBag.PorcentajeSort = sortOrder == "porcentaje_asc" ? "porcentaje_desc" : "porcentaje_asc";
        ViewBag.CarreraSort = sortOrder == "carrera_asc" ? "carrera_desc" : "carrera_asc";

        // Obtener todas las becas (sin filtro)
        var becas = await _service.GetAllAsync(null);

        // Aplicar orden
        switch (sortOrder)
        {
            case "nombre_desc":
                becas = becas.OrderByDescending(b => b.NombreBeca).ToList();
                break;
            case "nombre_asc":
                becas = becas.OrderBy(b => b.NombreBeca).ToList();
                break;
            case "porcentaje_desc":
                becas = becas.OrderByDescending(b => b.PorcentajeBeca).ToList();
                break;
            case "porcentaje_asc":
                becas = becas.OrderBy(b => b.PorcentajeBeca).ToList();
                break;
            case "carrera_desc":
                becas = becas
                    .OrderByDescending(b => b.NombreCarrera ?? "")
                    .ToList();
                break;
            case "carrera_asc":
                becas = becas
                    .OrderBy(b => b.NombreCarrera ?? "")
                    .ToList();
                break;
        }

        return View(becas);
    }

    public async Task<IActionResult> Details(int id)
    {
        var beca = await _service.GetByIdAsync(id);
        if (beca == null)
            return NotFound();

        return View(beca);
    }

    // GET Create
    public async Task<IActionResult> Create()
    {
        ViewBag.Carreras = await _carreraService.GetAllAsync();
        return View();
    }

    // POST Create
    [HttpPost]
    public async Task<IActionResult> Create(BecaDto dto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Carreras = await _carreraService.GetAllAsync();
            return View(dto);
        }

        await _service.AddAsync(dto);
        return RedirectToAction(nameof(Administrations));
    }

    // GET Edit
    public async Task<IActionResult> Edit(int id)
    {
        var beca = await _service.GetByIdAsync(id);
        if (beca == null)
            return NotFound();

        ViewBag.Carreras = await _carreraService.GetAllAsync();

        return View(beca);
    }

    // POST Edit
    [HttpPost]
    public async Task<IActionResult> Edit(BecaDto dto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Carreras = await _carreraService.GetAllAsync();
            return View(dto);
        }

        await _service.UpdateAsync(dto);
        return RedirectToAction(nameof(Administrations));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var beca = await _service.GetByIdAsync(id);
        if (beca == null)
            return NotFound();

        return View(beca);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Administrations));
    }
}