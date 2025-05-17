namespace TP04_Drcuker_Daiksel.Models;


public static class Ahorcado
{
    public static int intentos { get; private set; }
    public static int fallos { get; private set; }
    public static char[] letras { get; private set; }
    public static char[] letrasAdivinadas { get; private set; }
    public static List<char> letrasFalladas { get; private set; }
    public static string PALABRA { get; private set; }
    public static bool finalizar { get; private set; }
    public static bool gano { get; private set; }
    public static bool perdio { get; private set; }
    public static void inicializarAhorcado()
    {
        PALABRA = "COINCIDENCIA";
        intentos = 0;
        finalizar = false;
        letras = PALABRA.ToCharArray();
        letrasAdivinadas = new char[letras.Length];
        for (int i = 0; i < letrasAdivinadas.Length; i++)
        {
            letrasAdivinadas[i] = '_';
        }
        letrasFalladas = new List<char>();
        fallos = 0;
        gano = false;
        perdio = false;
    }

    public static string adivinarLetra(char letra)
    {
        string devolver;
        char letraEntrada = char.ToUpper(letra);
        intentos++;

        if (letrasFalladas.Contains(letraEntrada) || letrasAdivinadas.Contains(letraEntrada))
        {
            devolver = "Ya intentaste con esta letra";
        }
        else if (letras.Contains(letraEntrada))
        {
            for (int i = 0; i < letras.Length; i++)
            {
            if (letras[i] == letraEntrada)
            {
                letrasAdivinadas[i] = letraEntrada;
            }
            }
            devolver = "Adivinaste!";
        }
        else
        {
            fallos++;
            letrasFalladas.Add(letraEntrada);
            devolver = "Incorrecto!";
        }

        
        if (new string(letrasAdivinadas) == new string(letras))
        {
            finalizar = true;
            gano = true;
        }

        if(fallos == 5){
            finalizar = true;
            perdio = true;
            devolver = "Llegaste a 5 fallos, panfletovich";
        }

        return devolver;
        }


        static public string arriesgarPalabraCompleta(string palabra)
        {
            string devolver = "";
            palabra = palabra.ToUpper(); 
            finalizar = true;
            if (palabra == PALABRA)
            {
            gano = true;
            devolver = "Le pegaste, crack";
            }
            else
            {
            devolver = "No le pegaste, panflin";
            perdio = true;
            }

            return devolver;
        }

}