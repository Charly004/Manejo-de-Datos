// See https://aka.ms/new-console-template for more information

using System.Diagnostics.Contracts;

int MenuSelected = 0;
do
{
    MenuSelected = MenuPrincipal();
    if (MenuSelected == 1)
    {
        MostrarLista();
    }
    else if (MenuSelected == 2)
    {
        MostrarDepartamento();
    }
    else if (MenuSelected == 3)
    {
        LongitudDefinida();
    }
    else if (MenuSelected == 4)
    {
        BuscarPorLetra();
    }
    else if (MenuSelected == 5)
    {
        BuscarPorDepartamento();
    }
    else if (MenuSelected == 6)
    {
        IngresarCapital();
    }
} while (MenuSelected <= 6);
Console.WriteLine("\nGracias por su tiempo\n");
Printer.FinPrograma(30);

int MenuPrincipal()
{
    int Seleccion = 0;
    Printer.MainMenu(15);
    Console.WriteLine("1- Mostrar Lista");
    Console.WriteLine("2- Mostrar Caracteres Por Letra y Departamento");
    Console.WriteLine("3- Mostrar Capital Por Longitud Definida");
    Console.WriteLine("4- Mostrar Departamento Por Letra Inicial");
    Console.WriteLine("5- Mostrar Departamento Por Nombre");
    Console.WriteLine("6- Agregar Departamento");
    Console.WriteLine("7- Salir\n");
    Console.Write(">> ");
    Seleccion = int.Parse(Console.ReadLine());

    return Seleccion;
}

// Opción 1
void MostrarLista()
{
    Printer.CapitalList(28);
    Console.WriteLine("{0,-20}{1,15}{2,20}{3,25}\n", "Departamento", "Capital", "Superficie", "Municipios");
    foreach (var i in Listas.ListaDepartamentos)
    {
        Console.WriteLine("{0,-20}{1,15}{2,20}{3,25}", i.Departamento_, i.Capital, i.Superficie, i.Municipios);
    }
    Console.WriteLine("\n");
    Thread.Sleep(3000);
}

// Opción 2
void MostrarDepartamento()
{
    Printer.CaracteresPorLetra(10);
    char letra;
    Console.WriteLine("Ingrese la letra\n");
    Console.Write(">> ");
    letra = char.Parse(Console.ReadLine().ToLower());

    Printer.CharactersQuantity(20);
    Console.WriteLine("{0,-25}{1,10}\n", "Capital", $"Caracteres '{letra}'");

    foreach (var i in Listas.ListaDepartamentos)
    {
        int Cantidad = CantidadCaracteres(i.Capital, letra);
        Console.WriteLine("{0,-25}{1,10}", i.Capital, Cantidad);
    }
    Console.WriteLine("\n");
    Thread.Sleep(3000);
}

int CantidadCaracteres(string nombre, char letra)
{
    int contador = 0;

    foreach (char j in nombre.ToLower())
    {
        if (j == letra)
        {
            contador += 1;
        }
    }
    return contador;
}

// Opción 3
void LongitudDefinida()
{
    Printer.CapitalLongDefinida(20);

    Console.WriteLine("Ingrese la longitud\n");
    Console.Write(">> ");
    int longitud = int.Parse(Console.ReadLine());

    Printer.LengthDefined(28);
    Console.WriteLine($"\nLongitud ingresada por el usuario: {longitud}\n");
    ConsoleColor originalColor = Console.ForegroundColor;
    Console.Write("{0,-20}", "Capital");

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("{0,10}", "Longitud Definida");

    Console.ForegroundColor = originalColor;
    Console.WriteLine("{0,25}{1,26}\n", "Longitud Total", "Completo");

    foreach (var i in Listas.ListaDepartamentos)
    {
        bool Validacion = true;
        if (longitud >= i.Capital.Length)
        {
            Console.WriteLine("{0,-20}{1,10}{2,25}{3,30}", i.Capital, i.Capital.Length, i.Capital.Length, Validacion);
        }
        else
        {
            Validacion = ValidaEstado(i.Capital, longitud);
            Console.WriteLine("{0,-20}{1,10}{2,25}{3,30}", i.Capital.Substring(0, longitud), i.Capital.Substring(0, longitud).Length, i.Capital.Length, Validacion);
        }
        Listas.LongitudBool.Add(Validacion);
    }
    //Console.WriteLine("\n");
    //Listas.LongitudBool.ForEach(p => Console.WriteLine(p));
    //Listas.LongitudBool.Clear();

    //CuentaLista();

    int nValidacion = CuentaLista();

    Console.WriteLine($"\n{nValidacion} Capitales tienen el nombre completo según la longitud de caracteres ingresada\n");

    //CapitalesCondicion(nValidacion,longitud);

    string[] ArregloCapitales = CapitalesCondicion(nValidacion, longitud);

    int contador_n = 1;
    foreach (var i in ArregloCapitales)
    {
        Console.WriteLine($"{contador_n}- {i}");
        contador_n += 1;
    }

    Console.WriteLine("");
    Thread.Sleep(4000);

    Listas.LongitudBool.Clear();
}

int CuentaLista()
{
    int contador = 0;

    foreach (var i in Listas.LongitudBool)
    {
        int contadorf = 0;

        if (i == true)
        {
            contador += 1;
        }
    }
    //Listas.LongitudBool.Clear();
    //Console.WriteLine($"Existen {contador} true");
    return contador;
}


bool ValidaEstado(string nCapital, int nlongitud)
{
    bool EstadoCaracter = false;

    if (nCapital.Length == nlongitud)
    {
        EstadoCaracter = true;
    }
    else
    {
        EstadoCaracter = false;
    }
    return EstadoCaracter;
}

string[] CapitalesCondicion(int tamaño, int nvlongitud)
{
    int contador = 0;
    //int tamaño = n_longitud-1;

    string[] NuevoArreglo = new string[tamaño];

    foreach (var i in Listas.ListaDepartamentos)
    {
        //Console.WriteLine($"{i.Capital.Length}");
        int longitudPalabra = validalongitudnueva(i.Capital, nvlongitud);

        if (longitudPalabra >= i.Capital.Length)
        {
            NuevoArreglo[contador] = i.Capital;
            contador++;
        }
    }
    return NuevoArreglo;
}

int validalongitudnueva(string nPalabra, int nlongitud)
{
    int longitudreal = 0;
    string palabradevuelta;

    if (nPalabra.Length < nlongitud)
    {
        palabradevuelta = nPalabra;
        longitudreal = palabradevuelta.Length;
    }
    else
    {
        palabradevuelta = nPalabra.Substring(0, nlongitud);
        longitudreal = palabradevuelta.Length;
    }

    return longitudreal;
}

// Opción 4

void BuscarPorLetra()
{
    Printer.MostrarDepartamentoPorLetraInicial(20);
    char letra;
    Console.WriteLine("\nIngrese la letra a buscar\n");
    Console.Write(">> ");
    letra = char.Parse(Console.ReadLine().ToUpper());

    var diccionario = SeachForLetter(letra);

    if (!diccionario.Any())
    {
        Console.WriteLine("\nNo hay ninguna conincidencia");
    }
    else
    {
        Printer.ResultadoDiccionario(20,letra);
        int longitud_diccionario = Longitud_SeachForLetter(letra);
        Console.WriteLine($"\n{longitud_diccionario} resultado(s) encontrados\n");
        Console.WriteLine("{0,-20}{1,15}{2,20}{3,25}\n", "Departamento", "Capital", "Superficie", "Municipios");
        foreach (var i in diccionario)
        {
            Console.WriteLine("{0,-20}{1,15}{2,20}{3,25}", i.Departamento_, i.Capital, i.Superficie, i.Municipios);
        }
    }
    Console.WriteLine("");
    Thread.Sleep(3000);
}

IEnumerable<Departamento> SeachForLetter(char letra)
{
    var resultado = Listas.ListaDepartamentos.Where(p => p.Departamento_.StartsWith(letra));

    return resultado;
}

int Longitud_SeachForLetter(char letra)
{
    var resultado = SeachForLetter(letra);
    int contador = 0;

    foreach(var i in resultado)
    {
        contador+=1;
    }

    return contador;
}

// Opción 5
void BuscarPorDepartamento()
{
    int Longitud = 0;
    Printer.BusquedaPorNombreDepartamento(20);
    Console.WriteLine("\nIngrese el departamento a buscar\n");
    Console.Write(">> ");
    string nDepartamento = Console.ReadLine();
    Longitud = LongitudNombre(nDepartamento);
    nDepartamento= TransformaNombre(nDepartamento,Longitud);
    bool validasiExiste = ValidaExistencia(nDepartamento);

    if(validasiExiste==true)
    {

    var listaBuscarV = BuscarV(nDepartamento);
    Printer.BuscarPorDepartamento(20);
    Console.WriteLine("{0,-20}{1,15}{2,20}{3,25}\n", "Departamento", "Capital", "Superficie", "Municipios");
    foreach(var i in listaBuscarV)
    {
        Console.WriteLine("{0,-20}{1,15}{2,20}{3,25}",i.Departamento_,i.Capital,i.Superficie,i.Municipios);
    }
    Console.WriteLine("");
    }
    else
    {
        Console.WriteLine("\nEl departamento ingresado no existe\n");
    }
    Thread.Sleep(3000);
}

IEnumerable<Departamento> BuscarV(string nCapital)
{
    var ResultadoConsulta = Listas.ListaDepartamentos.Where(p=> p.Departamento_.StartsWith(nCapital));

    return ResultadoConsulta;// ResultadoConsulta.ToList().ForEach(p=> Console.WriteLine($"{p.Departamento_} - {p.Capital} - {p.Superficie} - {p.Municipios}"));
}

// Opción 6
void IngresarCapital()
{
    Departamento departamento = new Departamento();

    int cantidad = LongitudListaDepartamentos();
    int Longitud = 0;
    departamento.Codigo = cantidad + 1;
    string ValorNombre = "";

    Printer.AddDepartment(20);

    Console.WriteLine("Ingresa el nombre del departamento\n");
    Console.Write(">> ");
    
    ValorNombre = Console.ReadLine();
    Longitud = LongitudNombre(ValorNombre);
    
    departamento.Departamento_ = TransformaNombre(ValorNombre,Longitud);

    Console.WriteLine("\nIngresa el nombre de la capital\n");
    Console.Write(">> ");

    ValorNombre = Console.ReadLine();
    Longitud = LongitudNombre(ValorNombre);

    departamento.Capital = TransformaNombre(ValorNombre,Longitud);

    Console.WriteLine("\nIngresa la superficie\n");
    Console.Write(">> ");
    departamento.Superficie = double.Parse(Console.ReadLine());

    Console.WriteLine("\nIngresa los municipios\n");
    Console.Write(">> ");
    departamento.Municipios = int.Parse(Console.ReadLine());

    Boolean ValidaciondeExistencia = ValidaExistencia(departamento.Departamento_);

    if (ValidaciondeExistencia == true)
    {
        Console.WriteLine("\nEl departamento ingresado ya existe\n");
    }
    else
    {
        Listas.ListaDepartamentos.Add(departamento);
        Console.WriteLine("\nDepartamento agregado correctamente\n");
        Thread.Sleep(2000);
    }

}

int LongitudNombre(string nombre)
{
    int cantidad = 0;
    cantidad = nombre.Length;

    return cantidad;
}

string TransformaNombre(string nombre, int longitud)
{
    string InicialMayuscula =  nombre.Substring(0,1).ToUpper();
    string RestoNombre = nombre.Substring(1,longitud-1).ToLower();
    string NombreConcatenado = InicialMayuscula + RestoNombre;

    return NombreConcatenado;
}

Boolean ValidaExistencia(string departamento)
{
    Boolean Existe = false;

    foreach (var i in Listas.ListaDepartamentos)
    {
        if (i.Departamento_ == departamento)
        {
            Existe = true;
            break;
        }
    }
    return Existe;
}

int LongitudListaDepartamentos()
{
    int contador = 0;

    foreach (var i in Listas.ListaDepartamentos)
    {
        contador += 1;
    }
    return contador;
}



