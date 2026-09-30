using AccesoDatos.Models;
using AccesoDatos.Repositories;

IGenericRepository<Artista> artistaRepository = new GenericRepository<Artista>();
CancionRepository cancionRepository = new CancionRepository();

bool continuar = true;

while (continuar)
{
Console.WriteLine(" SISTEMA DE MÚSICA ");
Console.WriteLine("1. Alta Artista");
Console.WriteLine("2. Alta Canicion");
Console.WriteLine("3. Ver Canciones");
Console.WriteLine("4. Mostrar canciones más largas");
Console.Write("5.Mostrar total de canciones:");
Console.WriteLine("6. Mostrar canciones ordenadas alfabéticamente");
Console.WriteLine("7. Verificar si existen caciones registardas");
Console.WriteLine("0. Salir");
Console.WriteLine();

Console.Write("Seleccione una opción: ");
string opcion = Console.ReadLine();

Console.Clear();

switch (opcion)
{
    case "1":
        AltaArtista();
        break;

case "2":
     AltaCancion();
     break;

case "3": 
      VerCanciones(); 
      break;

case "4": 
     MostrarCancionesMasLargas(); 
     break;
        
case "5": 
     CantidadTotalCanciones(); 
     break;
        
case "6": 
     MostrarCancionesOrdenadas(); 
     break;
        
case "7": 
     VerificarCancionesRegistradas();
     break;
        
case "0":
    continuar = false;
    Console.WriteLine("Aplicación finalizada.");
    break;
default:
    Console.WriteLine("Opción inválida.");
    PresioneParaContinuar();
    break;
    }
}

// Artistas

void AltaArtista()
{
    Console.Write("Nombre del artista: ");
    var nombre = Console.ReadLine();

    Artista artista = new Artista
    {
        Nombre = nombre
    };

    artistaRepository.Agregar(artista);

    Console.WriteLine("Artista registrado correctamente.");

    PresioneParaContinuar();
}

void AltaCancion()
{
    Console.Write("Título: ");
    string titulo = Console.ReadLine();

    Console.Write("Duración en segundos: ");
    int duracion = int.Parse(Console.ReadLine());

    Console.WriteLine();
    Console.WriteLine("Artistas disponibles:");

    foreach (var artista in artistaRepository.ObtenerTodos())
    {
        Console.WriteLine($"ID: {artista.Id} - {artista.Nombre}");
    }

    Console.Write("Seleccione el ID del artista: ");
    int artistaId = int.Parse(Console.ReadLine());

    if (artistaRepository.ObtenerPorId(artistaId) == null)
    {
        Console.WriteLine("Artista no encontrado.");
        PresioneParaContinuar();
        return;
    }

    Cancion cancion = new Cancion
    {
        Titulo = titulo,
        DuracionSegundos = duracion,
        ArtistaId = artistaId
    };

    cancionRepository.Agregar(cancion);

    Console.WriteLine("Canción registrada correctamente.");

    PresioneParaContinuar();
}

void VerCanciones()
{
    Console.WriteLine("Canciones:");

    var canciones = cancionRepository.ObtenerTodosCon("Artista");

    if (!canciones.Any())
    {
        Console.WriteLine("No existen canciones registradas.");
    }
    else
    {
        MostrarLista(canciones);
    }

    PresioneParaContinuar();
}

void MostrarCancionesMasLargas()
{
    Console.WriteLine("Canciones mas largas");

    var canciones = cancionRepository.ObtenerMasLargas();

    if (!canciones.Any())
    {
        Console.WriteLine("No existen canciones registradas.");
    }
    else
    {
        MostrarLista(canciones);
    }

    PresioneParaContinuar();
}

void CantidadTotalCanciones()
{
    int cantidad = cancionRepository.ObtenerCantidadTotal();

    Console.WriteLine($"Cantidad total de canciones: {cantidad}");

    PresioneParaContinuar();
}

void MostrarCancionesOrdenadas()
{
    Console.WriteLine("Canciones ordenadas por título");

    var canciones = cancionRepository.ObtenerOrdenadasPorTitulo();

    if (!canciones.Any())
    {
        Console.WriteLine("No existen canciones registradas.");
    }
    else
    {
        MostrarLista(canciones);
    }

    PresioneParaContinuar();
}

void VerificarCancionesRegistradas()
{
    if (cancionRepository.ExistenCanciones())
    {
        Console.WriteLine("Existen canciones registradas.");
    }
    else
    {
        Console.WriteLine("No existen canciones registradas.");
    }

    PresioneParaContinuar();
}

void MostrarLista(List<Cancion> canciones)
{
    foreach (var cancion in canciones)
    {
        Console.WriteLine(
            $"ID: {cancion.Id} | " +
            $"Título: {cancion.Titulo} | " +
            $"Duración: {cancion.DuracionSegundos} seg | " +
            $"Artista: {cancion.Artista.Nombre}");
    }
}

void PresioneParaContinuar()
{
    Console.WriteLine();
    Console.WriteLine("Presione una tecla para continuar...");
    Console.ReadKey();
    Console.Clear();
}


