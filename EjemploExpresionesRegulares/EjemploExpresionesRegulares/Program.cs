using System;
using System.Text.RegularExpressions;

class PruebaExpresionesRegulares
{
    public static bool EsNumeroEntero(String cadena)
    {
        Regex patronNumerico = new Regex("[^0-9]");
        return !patronNumerico.IsMatch(cadena);
    }

    public static bool EsNumeroEntero2(String cadena)
    {
        Regex patronNumerico = new Regex(@"\A[0-9]*\z");
        return patronNumerico.IsMatch(cadena);
    }

    public static bool EsNumeroConDecimales(String cadena)
    {
        Regex patronNumerico = new Regex(@"\A[0-9]*,[0-9]+\z");
        return patronNumerico.IsMatch(cadena);
    }

    public static bool EsAlfabetico(String cadena)
    {
        Regex patronAlbafetico = new Regex("[^a-zA-Z]");
        return !patronAlbafetico.IsMatch(cadena);
    }

    public static bool EsAlfanumerico(String cadena)
    {
        Regex patronAlfanumerico = new Regex("[^a-zA-Z0-9]");
        return !patronAlfanumerico.IsMatch(cadena);
    }

    static void Main()
    {
        String ejemplo;
        ejemplo = "Hola";

        if(EsNumeroEntero(ejemplo))
        {
            Console.WriteLine("{0} SÍ es un número entero", ejemplo);
        }
        else
        {
            Console.WriteLine("{0} NO es un número entero", ejemplo);
        }

        ejemplo = "4589";

        if (EsNumeroEntero(ejemplo))
        {
            Console.WriteLine("{0} SÍ es un número entero", ejemplo);
        }
        else
        {
            Console.WriteLine("{0} NO es un número entero", ejemplo);
        }

        ejemplo = "9849321";

        if (EsNumeroEntero2(ejemplo))
        {
            Console.WriteLine("{0} SÍ es un número entero", ejemplo);
        }
        else
        {
            Console.WriteLine("{0} NO es un número entero", ejemplo);
        }

        ejemplo = "12,94,5";

        if (EsNumeroConDecimales(ejemplo))
        {
            Console.WriteLine("{0} SÍ es un número decimal", ejemplo);
        }
        else
        {
            Console.WriteLine("{0} NO es un número decimal", ejemplo);
        }

        ejemplo = "4589,32";

        if (EsNumeroConDecimales(ejemplo))
        {
            Console.WriteLine("{0} SÍ es un número decimal", ejemplo);
        }
        else
        {
            Console.WriteLine("{0} NO es un número decimal", ejemplo);
        }

        ejemplo = "12478";

        if (EsNumeroConDecimales(ejemplo))
        {
            Console.WriteLine("{0} SÍ es un número decimal", ejemplo);
        }
        else
        {
            Console.WriteLine("{0} NO es un número decimal", ejemplo);
        }

        ejemplo = "frase01";

        if (EsAlfabetico(ejemplo))
        {
            Console.WriteLine("{0} SÍ es un alfabética", ejemplo);
        }
        else
        {
            Console.WriteLine("{0} NO es alfabética", ejemplo);
        }

        ejemplo = "palabra";

        if (EsAlfabetico(ejemplo))
        {
            Console.WriteLine("{0} SÍ es alfabética", ejemplo);
        }
        else
        {
            Console.WriteLine("{0} NO es alfabética", ejemplo);
        }

        ejemplo = "frase01";

        if (EsAlfanumerico(ejemplo))
        {
            Console.WriteLine("{0} SÍ es alfanumérica", ejemplo);
        }
        else
        {
            Console.WriteLine("{0} NO es alfanumérica", ejemplo);
        }

        ejemplo = "palabra";

        if (EsAlfabetico(ejemplo))
        {
            Console.WriteLine("{0} SÍ es alfanumérica", ejemplo);
        }
        else
        {
            Console.WriteLine("{0} NO es alfanumérica", ejemplo);
        }

        Console.ReadKey();
    }
}

