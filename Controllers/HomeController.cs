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
        ViewBag.utilizadas = Ahorcado.fallos;
        ViewBag.intentos = Ahorcado.intentos;
        ViewBag.letrasFalladas = Ahorcado.letrasFalladas;
        ViewBag.perdio = Ahorcado.perdio;
        ViewBag.gano = Ahorcado.gano;
        return View("juego");
    }

    public IActionResult verificar(char letraAdivinada, string palabraAdivinada){
        string devuelta = "";
        if(Ahorcado.finalizar == false){
            if(palabraAdivinada == null){
                devuelta = Ahorcado.adivinarLetra(letraAdivinada);
                ViewBag.mensaje = devuelta;
                return View("juego");
            }
            else{
                devuelta = Ahorcado.arriesgarPalabraCompleta(palabraAdivinada);
                ViewBag.mensaje = devuelta;
                return View("juego");
            }
        }
        else{
            
        }
        
    }
}
