using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04_Drcuker_Daiksel.Models;
using Newtonsoft.Json;

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
      

        return View();
    }


    public static class Objeto{
        public static string ObjectToString<T>(T? obj){
            return JsonConvert.SerializeObject(obj);
        }
        public static T? StringToObject<T>(string txt){
            if(string.IsNullOrEmpty(txt)){
                return default;
            }
            else{
                return JsonConvert.DeserializeObject<T>(txt);
            }
        }
    }

    public IActionResult jugar(){
        Ahorcado Juego =  new Ahorcado();
        Juego.inicializarAhorcado();
        HttpContext.Session.SetString("Juego", Objeto.ObjectToString(Juego));


        ViewBag.palabraAdivinar = Juego.letrasAdivinadas;
        ViewBag.fallos = Juego.fallos;
        ViewBag.intentos = Juego.intentos;
        ViewBag.letrasFalladas = Juego.letrasFalladas;
        ViewBag.perdio = Juego.perdio;
        ViewBag.gano = Juego.gano;
        ViewBag.cantidadLetras = Juego.letras.Length;
        
        ViewBag.mensaje = "Aca se van a mostrar los mensajes de consola";
        return View("juego");
    }

    public IActionResult verificar(char letraAdivinada, string palabraAdivinada)
    {
        Ahorcado Juego = Objeto.StringToObject<Ahorcado>(HttpContext.Session.GetString("Juego"));;
        string devuelta = "";
        if (Juego.finalizar == false)
        {
            if (palabraAdivinada == null)
            {
                devuelta = Juego.adivinarLetra(letraAdivinada);
                ViewBag.mensaje = devuelta;
            }
            else
            {
                devuelta = Juego.arriesgarPalabraCompleta(palabraAdivinada);
                ViewBag.mensaje = devuelta;
            }
        }

        HttpContext.Session.SetString("Juego", Objeto.ObjectToString(Juego));

        ViewBag.palabraAdivinar = Juego.letrasAdivinadas;
        ViewBag.fallos = Juego.fallos;
        ViewBag.intentos = Juego.intentos;
        ViewBag.letrasFalladas = Juego.letrasFalladas;
        ViewBag.perdio = Juego.perdio;
        ViewBag.gano = Juego.gano;
        ViewBag.cantidadLetras = Juego.letras.Length;

        if (Juego.finalizar == false)
        {
            return View("Juego");
        }
        else
        {
            if (Juego.gano == true)
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
