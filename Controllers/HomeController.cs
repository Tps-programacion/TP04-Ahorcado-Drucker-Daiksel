using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04_Drcuker_Daiksel.Models;

namespace TP04_Drcuker_Daiksel.Controllers;

public class HomeController : Controller
{
    
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Ahorcado.inicializarAhorcado();
        return View();
    }

    public IActionResult jugar(){
        
        ViewBag.palabraAdivinar = Ahorcado.letrasAdivinadas;
        ViewBag.fallos = Ahorcado.fallos;
        ViewBag.intentos = Ahorcado.intentos;
        ViewBag.letrasFalladas = Ahorcado.letrasFalladas;
        ViewBag.perdio = Ahorcado.perdio;
        ViewBag.gano = Ahorcado.gano;
        ViewBag.cantidadLetras = Ahorcado.letras.Length;
        
        ViewBag.mensaje = "Aca se van a mostrar los mensajes de consola";
        return View("juego");
    }

    public IActionResult verificar(char letraAdivinada, string palabraAdivinada)
    {

        string devuelta = "";
        if (Ahorcado.finalizar == false)
        {
            if (palabraAdivinada == null)
            {
                devuelta = Ahorcado.adivinarLetra(letraAdivinada);
                ViewBag.mensaje = devuelta;
            }
            else
            {
                devuelta = Ahorcado.arriesgarPalabraCompleta(palabraAdivinada);
                ViewBag.mensaje = devuelta;
            }
        }

        ViewBag.palabraAdivinar = Ahorcado.letrasAdivinadas;
        ViewBag.fallos = Ahorcado.fallos;
        ViewBag.intentos = Ahorcado.intentos;
        ViewBag.letrasFalladas = Ahorcado.letrasFalladas;
        ViewBag.perdio = Ahorcado.perdio;
        ViewBag.gano = Ahorcado.gano;
        ViewBag.cantidadLetras = Ahorcado.letras.Length;

        if (Ahorcado.finalizar == false)
        {
            return View("Juego");
        }
        else
        {
            if (Ahorcado.gano == true)
            {
                return View("vistaGanador");
            }
            else
            {
                return View("vistaPerdedor");
            }
        }
    }
}
