
namespace TP04_Ahorcado_Drucker_Daiksel.Models;
static public class Juego
{
    public static string PALABRA { get; private set; } 
    public static bool finalizar { get; private set; }

    public static void inicializarJuego(string palabra){
        PALABRA = palabra;
        finalizar = false;
        Ahorcado ahorcado = new Ahorcado(PALABRA);
    }
}

