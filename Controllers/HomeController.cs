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

    public IActionResult AbrirSobre(){
        ViewBag.Sobre = BD.AbrirSobre();
        return View("Paquete");
    }
    
    public IActionResult PegarFigus(int id1, int id2, int id3, int id4, int id5){
        List<int> Ids = new List<int>{id1, id2, id3, id4, id5};
        BD.PegarFigusXId(Ids);
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
