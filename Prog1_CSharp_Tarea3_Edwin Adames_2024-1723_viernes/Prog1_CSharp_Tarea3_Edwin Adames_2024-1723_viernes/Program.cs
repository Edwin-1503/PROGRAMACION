var ids = new List<int>();


var nombres = new Dictionary<int, string>();
var apellidos = new Dictionary<int, string>();
var telefonos = new Dictionary<int, string>();
var direcciones = new Dictionary<int, string>();
var edades = new Dictionary<int, int>();
var contactosDeEmergencia = new Dictionary<int, bool>();
var opcionSeleccionada = 1;
var ejecutandose = true;
Console.WriteLine("Bienvenido a mi agenda");

while (ejecutandose)
{
    Console.WriteLine("1. Agregar Contacto, 2. Ver listado de contactos, 3. Actualizar un contacto, 4. Eliminar un Contacto. 5. Salir");

    opcionSeleccionada = int.Parse(Console.ReadLine());


    if (opcionSeleccionada <= 0 || opcionSeleccionada >= 5)
    {
        Console.WriteLine("A ti te dejaron caer cuando pequeño, verdad? ");
    }
    else if (opcionSeleccionada == 5)
    {
        ejecutandose = false;
    }
    else
    {
        switch (opcionSeleccionada)
        {
            case 1:
                {
                    AgregarContacto(ids, nombres, apellidos, telefonos, direcciones, edades, contactosDeEmergencia);
                    break;
                }
            case 2:
                {
                    Console.WriteLine("Digite el Id, del contacto que desea Visualizar");
                    var idSeleccionado = int.Parse(Console.ReadLine());

                    MostrarContacto(idSeleccionado, ids, nombres, apellidos, telefonos, direcciones, edades, contactosDeEmergencia);

                    break;
                }
            case 3:
                {
                    break;
                }
            case 4:
                {
                    ejecutandose = false;
                    break;
                }
        }



    }


}

Console.WriteLine("Cerrando el PRograma");
Console.ReadKey();

static int GeneradorDeId(List<int> ids)
{
    var id = ids.Count();
    id++;
    return id;
}

static bool DeterminarSiEsContactoDeEmergencia()
{
    Console.Write("Es un contacto de emergencia? 1. Si, 2. No: ");

    int contactoDeEmergenciaDigitado = int.Parse(Console.ReadLine());

    return contactoDeEmergenciaDigitado == 1 ? true : false;
}

static void MostrarContacto(int idIndicado, List<int> ids, Dictionary<int, string> nombres, Dictionary<int, string> apellidos, Dictionary<int, string> telefonos, Dictionary<int, string> direcciones, Dictionary<int, int> edades, Dictionary<int, bool> contactosDeEmergencia)
{
    string nombre, apellido, telefono, direccion, esContactoDeEmergencia;
    int edad;

    BuscarContacto(idIndicado, nombres, apellidos, telefonos, direcciones, edades, contactosDeEmergencia, out nombre, out apellido, out telefono, out edad, out direccion, out esContactoDeEmergencia);

    MostrarValoresEnPantallaDeContactoSeleccionado(nombre, apellido, telefono, direccion, edad, esContactoDeEmergencia, idIndicado);

}

static void BuscarContacto(int idIndicado, Dictionary<int, string> nombres, Dictionary<int, string> apellidos, Dictionary<int, string> telefonos, Dictionary<int, string> direcciones, Dictionary<int, int> edades, Dictionary<int, bool> contactosDeEmergencia, out string nombre, out string apellido, out string telefono, out int edad, out string direccion, out string esContactoDeEmergencia)
{
    nombre = nombres[idIndicado];
    apellido = apellidos[idIndicado];
    telefono = telefonos[idIndicado];
    edad = edades[idIndicado];
    direccion = direcciones[idIndicado];
    esContactoDeEmergencia = contactosDeEmergencia[idIndicado] ? "Si" : "No";
}

static void MostrarValoresEnPantallaDeContactoSeleccionado(string? nombre, string? apellido, string? tel, string? dir, int edad, string contactoDeEmergencia, int id)
{
    Console.WriteLine($"El contacto seleccionado con el ID: {id} es, ");
    Console.WriteLine($"Nombre: {nombre}");
    Console.WriteLine($"Apellido: {apellido}");
    Console.WriteLine($"Tel: {tel}");
    Console.WriteLine($"Dirección: {dir}");
    Console.WriteLine($"Edad: {edad}");
    Console.WriteLine($"Es Contacto de Emergencia?: {contactoDeEmergencia}");
}

static void AgregarContacto(List<int> ids, Dictionary<int, string> nombres, Dictionary<int, string> apellidos, Dictionary<int, string> telefonos, Dictionary<int, string> direcciones, Dictionary<int, int> edades, Dictionary<int, bool> contactosDeEmergencia)
{
    Console.Write("Digite un nombre: ");
    var nombre = Console.ReadLine();
    Console.Write("Digite un apellido: ");
    var apellido = Console.ReadLine();
    Console.Write("Digite un Telefono: ");
    var tel = Console.ReadLine();
    Console.Write("Digite una Direccion: ");
    var dir = Console.ReadLine();
    Console.Write("Digite una Edad: ");
    var edad = int.Parse(Console.ReadLine());

    bool contactoDeEmergencia = DeterminarSiEsContactoDeEmergencia();

    var id = GeneradorDeId(ids);
    ids.Add(id);
    AgregandoValoresALosDiccionarios(nombres, apellidos, telefonos, direcciones, edades, contactosDeEmergencia, nombre, apellido, tel, dir, edad, contactoDeEmergencia, id);
}

static void AgregandoValoresALosDiccionarios(Dictionary<int, string> nombres, Dictionary<int, string> apellidos, Dictionary<int, string> telefonos, Dictionary<int, string> direcciones, Dictionary<int, int> edades, Dictionary<int, bool> contactosDeEmergencia, string? nombre, string? apellido, string? tel, string? dir, int edad, bool contactoDeEmergencia, int id)
{
    nombres.Add(id, nombre);
    apellidos.Add(id, apellido);
    telefonos.Add(id, tel);
    direcciones.Add(id, dir);
    edades.Add(id, edad);
    contactosDeEmergencia.Add(id, contactoDeEmergencia);
}

