Console.WriteLine("Agenda Saul");
Console.WriteLine("Bienvenido a tu lista de contactos");

Dictionary<int, string> nombres = new Dictionary<int, string>();
Dictionary<int, string> telefonos = new Dictionary<int, string>();
Dictionary<int, string> correos = new Dictionary<int, string>();
List<string> direcciones = new List<string>();
List<int> ids = new List<int>();

bool ejecutando = true;
while (ejecutando)
{
    Console.Write("1. Agregar Contacto      ");
    Console.Write("2. Ver Contactos     ");
    Console.Write("3. Buscar Contacto      ");
    Console.Write("4. Modificar Contacto        ");
    Console.Write("5. Eliminar Contacto     ");
    Console.WriteLine("6. Salir");
    Console.WriteLine("......................................");
    Console.Write("Elige una opción: ");

    int opcion = Convert.ToInt32(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            AgregarContacto(ref nombres, ref telefonos, ref correos, ref direcciones, ref ids);
            break;
        case 2:
            VerContactos(ref nombres, ref telefonos, ref correos, ref direcciones, ref ids);
            break;
        case 3:
            BuscarContacto(ref nombres, ref telefonos, ref correos, ref direcciones, ref ids);
            break;
        case 4:
            EditarContacto(ref nombres, ref telefonos, ref correos, ref direcciones, ref ids);
            break;
        case 5:
            EliminarContacto(ref nombres, ref telefonos, ref correos, ref direcciones, ref ids);
            break;
        case 6:
            ejecutando = false;
            break;
        default:
            Console.WriteLine("Opción no válida");
            break;
    }
}

static void AgregarContacto(ref Dictionary<int, string> nombres, ref Dictionary<int, string> telefonos, ref Dictionary<int, string> correos, ref List<string> direcciones, ref List<int> ids)
{
    Console.WriteLine("Nuevo Contacto");

    int id = ids.Count() + 1;
    ids.Add(id);

    Console.Write("Digite el Nombre: ");
    var nombre = Console.ReadLine();
    nombres.Add(id, nombre);

    Console.Write("Digite el Teléfono: ");
    var telefono = Console.ReadLine();
    telefonos.Add(id, telefono);

    Console.Write("Digite el Correo Electrónico: ");
    var correo = Console.ReadLine();
    correos.Add(id, correo);

    Console.Write("Digite la Dirección: ");
    var direccion = Console.ReadLine();
    direcciones.Add(direccion);

    Console.WriteLine();
}

static void VerContactos(ref Dictionary<int, string> nombres, ref Dictionary<int, string> telefonos, ref Dictionary<int, string> correos, ref List<string> direcciones, ref List<int> ids)
{
    Console.WriteLine("[Id] [Nombre] [Teléfono] [Correo] [Dirección]");
    Console.WriteLine("_____________________________________________");

    foreach (var id in ids)
    {
        Console.WriteLine($"{id}    {nombres[id]}      {telefonos[id]}      {correos[id]}     {direcciones[id - 1]}");
    }
}

static void EditarContacto(ref Dictionary<int, string> nombres, ref Dictionary<int, string> telefonos, ref Dictionary<int, string> correos, ref List<string> direcciones, ref List<int> ids)
{
    VerContactos(ref nombres, ref telefonos, ref correos, ref direcciones, ref ids);
    Console.WriteLine("Digite el ID del contacto que desea editar: ");
    int idSeleccionado = Convert.ToInt32(Console.ReadLine());

    if (!nombres.ContainsKey(idSeleccionado))
    {
        Console.WriteLine("ERROR: El ID ingresado no existe.");
        return;
    }

    Console.Write($"El nombre es: {nombres[idSeleccionado]}, Digite el Nuevo Nombre: ");
    nombres[idSeleccionado] = Console.ReadLine();

    Console.Write($"El Teléfono es: {telefonos[idSeleccionado]}, Digite el Nuevo Teléfono: ");
    telefonos[idSeleccionado] = Console.ReadLine();

    Console.Write($"El Correo es: {correos[idSeleccionado]}, Digite el Nuevo Correo: ");
    correos[idSeleccionado] = Console.ReadLine();

    Console.Write($"La dirección es: {direcciones[idSeleccionado - 1]}, Digite la nueva dirección: ");
    direcciones[idSeleccionado - 1] = Console.ReadLine();
}

static void BuscarContacto(ref Dictionary<int, string> nombres, ref Dictionary<int, string> telefonos, ref Dictionary<int, string> correos, ref List<string> direcciones, ref List<int> ids)
{
    VerContactos(ref nombres, ref telefonos, ref correos, ref direcciones, ref ids);
    Console.WriteLine("Digite el ID del contacto que desea buscar: ");
    int idSeleccionado = Convert.ToInt32(Console.ReadLine());

    if (!nombres.ContainsKey(idSeleccionado))
    {
        Console.WriteLine("ERROR: El ID ingresado no existe.");
        return;
    }

    Console.WriteLine($"El nombre es: {nombres[idSeleccionado]}");
    Console.WriteLine($"El Teléfono es: {telefonos[idSeleccionado]}");
    Console.WriteLine($"El Correo es: {correos[idSeleccionado]}");
    Console.WriteLine($"La Dirección es: {direcciones[idSeleccionado - 1]}");
}

static void EliminarContacto(ref Dictionary<int, string> nombres, ref Dictionary<int, string> telefonos, ref Dictionary<int, string> correos, ref List<string> direcciones, ref List<int> ids)
{
    VerContactos(ref nombres, ref telefonos, ref correos, ref direcciones, ref ids);
    Console.WriteLine("Digite el ID del contacto que desea eliminar: ");
    int idSeleccionado = Convert.ToInt32(Console.ReadLine());

    if (!nombres.ContainsKey(idSeleccionado))
    {
        Console.WriteLine("ERROR: El ID ingresado no existe.");
        return;
    }

    Console.WriteLine("Está a punto de eliminar el contacto?");
    Console.WriteLine("¿Seguro que desea eliminarlo? 1. Sí, 2. No");

    int opcion = Convert.ToInt32(Console.ReadLine());
    if (opcion == 1)
    {
        nombres.Remove(idSeleccionado);
        telefonos.Remove(idSeleccionado);
        correos.Remove(idSeleccionado);
        direcciones.RemoveAt(idSeleccionado - 1);
        ids.Remove(idSeleccionado);

        Console.WriteLine("Contacto eliminado con éxito.");
    }
    else
    {
        Console.WriteLine("Eliminación cancelada.");
    }
}

