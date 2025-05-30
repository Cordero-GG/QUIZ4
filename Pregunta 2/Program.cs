using System;
using System.Collections.Generic;

class DiccionarioSimple
{
    private List<Tuple<char, int>> conteoCaracteres;

    public DiccionarioSimple()
    {
        conteoCaracteres = new List<Tuple<char, int>>();
    }

    // Agrega una clave o incrementa su conteo si ya existe
    public void Agregar(char clave)
    {
        for (int i = 0; i < conteoCaracteres.Count; i++)
        {
            if (conteoCaracteres[i].Item1 == clave)
            {
                conteoCaracteres[i] = Tuple.Create(clave, conteoCaracteres[i].Item2 + 1);
                return;
            }
        }
        // Si no existe, la agregamos con conteo = 1
        conteoCaracteres.Add(Tuple.Create(clave, 1));
    }

    // Remueve una clave o decrementa su conteo si existe
    public void Remover(char clave)
    {
        for (int i = 0; i < conteoCaracteres.Count; i++)
        {
            if (conteoCaracteres[i].Item1 == clave)
            {
                conteoCaracteres[i] = Tuple.Create(clave, conteoCaracteres[i].Item2 - 1);
                return;
            }
        }
        // Si no existe, la agregamos con conteo = -1
        conteoCaracteres.Add(Tuple.Create(clave, -1));
    }

    // Verifica si todos los conteos son cero
    public bool TodosCeros()
    {
        foreach (var par in conteoCaracteres)
        {
            if (par.Item2 != 0)
                return false;
        }
        return true;
    }
}

class Program
{
    static bool SonAnagramas(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            return false;

        DiccionarioSimple diccionario = new DiccionarioSimple();

        // Contamos las letras del primer string
        foreach (char c in s1)
        {
            diccionario.Agregar(c);
        }

        // Restamos las letras del segundo string
        foreach (char c in s2)
        {
            diccionario.Remover(c);
        }

        // Si todos los conteos son cero, son anagramas
        return diccionario.TodosCeros();
    }

    static void Main()
    {
        string palabra1 = "listen";
        string palabra2 = "silent";

        if (SonAnagramas(palabra1, palabra2))
        {
            Console.WriteLine("¡Son anagramas!");
        }
        else
        {
            Console.WriteLine("No son anagramas.");
        }
    }
}