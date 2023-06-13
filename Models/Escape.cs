public static class Escape
{
    private static string[] incognitasSalas = { "8", "141", "16", "146" };
    private static int estadoJuego = 1;

    public static int GetEstadoJuego()
    {
        return estadoJuego;
    }

    public static void AvanzarEstadoJuego()
    {
        estadoJuego++;
        
    }

    public static bool ResolverSala(int Sala, string Incognita)
    {
        if (Sala != estadoJuego)
        {
            return false;
        }
        else
        {
            if (Incognita == incognitasSalas[estadoJuego - 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public static void Reiniciar()
    {
        estadoJuego = 1;
        
    }
}