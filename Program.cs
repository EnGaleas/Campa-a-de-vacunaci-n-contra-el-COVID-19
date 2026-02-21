using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        /*
        ============================================================
        CAMPAÑA NACIONAL DE VACUNACIÓN COVID-19
        ============================================================

        El programa crea un conjunto de 500 ciudadanos.
        Luego se generan dos subconjuntos:
        - 75 vacunados con Pfizer
        - 75 vacunados con AstraZeneca

        Se aplican operaciones de teoría de conjuntos:
        - Unión
        - Intersección
        - Diferencia
        - Complemento

        Finalmente se muestran los listados solicitados.
        ============================================================
        */

        // ===============================
        // 1. CONJUNTO TOTAL DE CIUDADANOS
        // ===============================

        HashSet<string> ciudadanos = new HashSet<string>();

        string[] nombres = {
            "Martha","Hector","Carlos","Andrea","Luis","Sofia","Daniel","Maria","Jose","Camila",
            "Fernando","Lucia","Miguel","Valeria","Pedro","Diana","Jorge","Paola","Ricardo","Elena",
            "Manuel","Gabriela","Andres","Rosa","Julian","Natalia","Diego","Patricia","Raul","Monica",
            "Eduardo","Carmen","Francisco","Angela","Roberto","Mariana","Victor","Lorena","Alberto","Claudia"
        };

        string[] apellidos = {
            "Pozo","Galeas","Perez","Gomez","Rodriguez","Sanchez","Torres","Flores","Vargas","Castro",
            "Herrera","Mendoza","Romero","Ortega","Medina","Silva","Rojas","Bravo","Suarez","Ibarra",
            "Navarro","Campos","Lopez","Paredes","Acosta","Delgado","Vega","Reyes","Espinoza","Rivera",
            "Morales","Alvarez","Cabrera","Salinas","Calderon","Benitez","Guerrero","Zambrano","Chavez","Cordova"
        };

        int contador = 1;

        // Genera combinaciones únicas hasta completar 500 ciudadanos
        foreach (var nombre in nombres)
        {
            foreach (var apellido in apellidos)
            {
                if (contador <= 500)
                {
                    ciudadanos.Add(contador + ". " + nombre + " " + apellido);
                    contador++;
                }
            }
        }

        // ===============================
        // 2. SUBCONJUNTOS DE VACUNACIÓN (MEZCLADOS)
        // ===============================

        Random rnd = new Random();

        HashSet<string> pfizer = ciudadanos.OrderBy(x => rnd.Next()).Take(75).ToHashSet();
        HashSet<string> astraZeneca = ciudadanos.OrderBy(x => rnd.Next()).Take(75).ToHashSet();

        // ===============================
        // 3. OPERACIONES DE CONJUNTOS
        // ===============================

        var ambasDosis = pfizer.Intersect(astraZeneca).ToHashSet();
        var soloPfizer = pfizer.Except(astraZeneca).ToHashSet();
        var soloAstra = astraZeneca.Except(pfizer).ToHashSet();
        var vacunados = pfizer.Union(astraZeneca).ToHashSet();
        var noVacunados = ciudadanos.Except(vacunados).ToHashSet();

        // ===============================
        // 4. RESULTADOS SOLICITADOS
        // ===============================

        Console.WriteLine("\nCIUDADANOS QUE NO SE HAN VACUNADO:\n");
        foreach (var c in noVacunados)
            Console.WriteLine(c);

        Console.WriteLine("\nCIUDADANOS QUE HAN RECIBIDO AMBAS DOSIS:\n");
        foreach (var c in ambasDosis)
            Console.WriteLine(c);

        Console.WriteLine("\nCIUDADANOS QUE SOLO HAN RECIBIDO PFIZER:\n");
        foreach (var c in soloPfizer)
            Console.WriteLine(c);

        Console.WriteLine("\nCIUDADANOS QUE SOLO HAN RECIBIDO ASTRAZENECA:\n");
        foreach (var c in soloAstra)
            Console.WriteLine(c);
    }
}
