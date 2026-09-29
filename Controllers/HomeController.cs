using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAppPelda.Models;
using WebAppPelda.Services;

namespace WebAppPelda.Controllers;

public class HomeController : Controller {
    public IActionResult Index() {
        return View();
    }

    public IActionResult Privacy() {
        return View();
    }
    
    public IActionResult Sajat()
    {
        List<Vasarlo> vasarlok = new VasarloService().GetAllVasarlo();
        return View(vasarlok);
    }

    public IActionResult Vasarlo(int id)
    {
        Vasarlo kivalasztott = new VasarloService().GetById(id);
        return View(kivalasztott);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}