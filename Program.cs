using System;
using System.Collections.Generic;

class VacunacionCovid
{
    static void Main()
    {
        // Crear objeto Random para seleccionar ciudadanos aleatoriamente
        Random random = new Random();

        // ===============================
        // 1. CREAR UNIVERSO DE 500 CIUDADANOS
        // ===============================
        HashSet<string> universo = new HashSet<string>(); // HashSet para evitar duplicados
        for (int i = 1; i <= 500; i++)
        {
            universo.Add($"Ciudadano {i}"); // Se agregan ciudadanos con numeración
        }

        // ===============================
        // 2. CREAR CONJUNTO DE 75 VACUNADOS CON PFIZER
        // ===============================
        HashSet<string> pfizer = GenerarVacunados(universo, 75, random);

        // ===============================
        // 3. CREAR CONJUNTO DE 75 VACUNADOS CON ASTRAZENECA
        // ===============================
        HashSet<string> astraZeneca = GenerarVacunados(universo, 75, random);

        // ===============================
        // 4. OPERACIONES DE TEORÍA DE CONJUNTOS
        // ===============================

        // a) Unión: todos los vacunados (Pfizer + AstraZeneca)
        HashSet<string> vacunados = new HashSet<string>(pfizer);
        vacunados.UnionWith(astraZeneca);

        // b) Intersección: ciudadanos que recibieron ambas dosis
        HashSet<string> ambas = new HashSet<string>(pfizer);
        ambas.IntersectWith(astraZeneca);

        // c) Diferencia: ciudadanos que solo recibieron Pfizer
        HashSet<string> soloPfizer = new HashSet<string>(pfizer);
        soloPfizer.ExceptWith(astraZeneca);

        // d) Diferencia: ciudadanos que solo recibieron AstraZeneca
        HashSet<string> soloAstra = new HashSet<string>(astraZeneca);
        soloAstra.ExceptWith(pfizer);

        // e) Complemento: ciudadanos que no se han vacunado
        HashSet<string> noVacunados = new HashSet<string>(universo);
        noVacunados.ExceptWith(vacunados);

        // ===============================
        // 5. REPORTE GENERAL (totales)
        // ===============================
        Console.WriteLine("======================================");
        Console.WriteLine("        REPORTE CAMPAÑA VACUNACIÓN");
        Console.WriteLine("======================================");
        Console.WriteLine($"Total ciudadanos: {universo.Count}");
        Console.WriteLine($"Vacunados Pfizer: {pfizer.Count}");
        Console.WriteLine($"Vacunados AstraZeneca: {astraZeneca.Count}");
        Console.WriteLine($"Ambas dosis: {ambas.Count}");
        Console.WriteLine($"Solo Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Solo AstraZeneca: {soloAstra.Count}");
        Console.WriteLine($"No vacunados: {noVacunados.Count}");

        // ===============================
        // 6. LISTADOS DETALLADOS
        // ===============================
        MostrarListado("CIUDADANOS SOLO PFIZER", soloPfizer);
        MostrarListado("CIUDADANOS SOLO ASTRAZENECA", soloAstra);
        MostrarListado("CIUDADANOS CON AMBAS DOSIS", ambas);
        MostrarListado("CIUDADANOS NO VACUNADOS", noVacunados);

        Console.WriteLine("\nProceso finalizado correctamente.");
    }

    // ===============================
    // MÉTODO PARA GENERAR VACUNADOS ALEATORIOS
    // ===============================
    static HashSet<string> GenerarVacunados(HashSet<string> universo, int cantidad, Random random) 
    {
        List<string> lista = new List<string>(universo); // Convertir HashSet a lista para indexar
        HashSet<string> conjunto = new HashSet<string>(); // Para almacenar los vacunados sin duplicados

        while (conjunto.Count < cantidad) // Se repite hasta completar la cantidad requerida
        {
            int indice = random.Next(lista.Count); // Selección aleatoria
            conjunto.Add(lista[indice]); // Agregar ciudadano al conjunto de vacunados
        }

        return conjunto; // Retornar conjunto generado
    }

    // ===============================
    // MÉTODO PARA MOSTRAR LISTADOS CON NUMERACIÓN
    // ===============================
    static void MostrarListado(string titulo, HashSet<string> conjunto)
    {
        Console.WriteLine($"\n===== {titulo} =====");
        int contador = 1;

        // Recorrer cada ciudadano en el conjunto
        foreach (var ciudadano in conjunto)
        {
            Console.WriteLine($"{contador}. {ciudadano}");
            contador++;
        }
    }
}
