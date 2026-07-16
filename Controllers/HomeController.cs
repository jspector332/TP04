using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04.Models;

namespace TP04.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    BD BD = new BD();

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AbrirSobre(){
        ViewBag.Sobre = BD.AbrirSobre();
        return View("Paquete");
    }
    [HttpPost]
    public IActionResult PegarFigus(List<int> ids){
        BD.PegarFigusXId(ids);
        return RedirectToAction("Index");
    }

    public IActionResult VerAlbum(){
        ViewBag.Figuritas = BD.ObtenerFiguritas();
        ViewBag.Jugadores = BD.ObtenerJugadores();
        ViewBag.Selecciones = BD.ObtenerSelecciones();
        return View("Album");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}