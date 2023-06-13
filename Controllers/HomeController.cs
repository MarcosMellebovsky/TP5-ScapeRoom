using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP5SALA.Models;

namespace TP5SALA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SobreNosotros()
        {
            return View("SobreNosotros");
        }

        public IActionResult Tutorial()
        {
            return View("Tutorial");
        }

        public IActionResult Comenzar()
        {
            return View("habitacion" + Escape.GetEstadoJuego());
        }

        public IActionResult Habitacion(int sala, string clave)
        {
            if (sala != Escape.GetEstadoJuego())
            {
                return View("habitacion" + Escape.GetEstadoJuego());
            }
            else
            {
                bool ok = Escape.ResolverSala(sala, clave);
                if (ok)
                {
                    if (sala == 4)
                    {
                        Escape.Reiniciar();
                        return View("Victoria");
                        
                    }
                    else
                    {
                        Escape.AvanzarEstadoJuego();
                        return View("habitacion" + Escape.GetEstadoJuego());
                    }
                }
                else
                {
                    ViewBag.Error = "Contraseña Incorrecta, volve a intentarlo!";
                    return View("habitacion" + Escape.GetEstadoJuego());    
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}