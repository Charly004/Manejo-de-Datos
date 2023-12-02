public static class Printer
{
    public static void MainMenu(int tamaño)
    {
        Console.WriteLine("".PadLeft(tamaño,'-')+" Menu Principal "+"".PadRight(tamaño,'-')+"\n");
    }

    public static void CapitalList(int tamaño)
    {
        Console.WriteLine("".PadLeft(tamaño,'-')+" Listado Departamentos "+"".PadRight(tamaño,'-')+"\n");
    }

    public static void CharactersQuantity(int tamaño)
    {
        Console.WriteLine("".PadLeft(tamaño,'-')+" Cantidad Caracteres Por Letra "+"".PadRight(tamaño,'-')+"\n");
    }

    public static void AddDepartment(int tamaño)
    {
        Console.WriteLine("".PadLeft(tamaño,'-')+" Ingresar Departamento "+"".PadRight(tamaño,'-')+"\n");
    }

    public static void LengthDefined(int tamaño)
    {
        Console.WriteLine("".PadLeft(tamaño,'-')+" Longitud Definida "+"".PadRight(tamaño,'-'));
    }

    public static void CapitalLongDefinida(int tamaño)
    {
        Console.WriteLine("".PadLeft(tamaño,'-')+" Capital Por Longitud Definida "+"".PadRight(tamaño,'-')+"\n");
    }

    public static void CaracteresPorLetra(int tamaño)
    {
        Console.WriteLine("".PadLeft(tamaño,'-')+" Caracteres Por Letra y Departamento "+"".PadRight(tamaño,'-')+"\n");
    }

    public static void FinPrograma(int tamaño)
    {
        Console.WriteLine("".PadLeft(tamaño,'-')+" Fin del Programa "+"".PadRight(tamaño,'-')+"\n");
    }

    public static void ResultadoDiccionario(int tamaño, char letra)
    {
        Console.WriteLine("".PadLeft(tamaño,'-')+$" Resultado Busqueda por letra '{letra}' "+"".PadRight(tamaño,'-')+"\n");
    }

    public static void BuscarPorDepartamento(int tamaño)
    {
        Console.WriteLine("".PadLeft(tamaño,'-')+" Busqueda Por Departamento "+"".PadRight(tamaño,'-')+"\n");
    }

    public static void MostrarDepartamentoPorLetraInicial (int tamaño)
    {
        Console.WriteLine("\n"+"".PadLeft(tamaño,'-')+" Mostrar Departamento Por Letra Inicial "+ "".PadRight(tamaño,'-'));
    }

    public static void BusquedaPorNombreDepartamento (int tamaño)
    {
        Console.WriteLine("\n"+"".PadLeft(tamaño,'-')+" Busqueda Por Nombre Departamento "+ "".PadRight(tamaño,'-')+"\n");
    }
}