using System;
using System.Collections.Generic;

class Contacto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }

    public Contacto(int id, string nombre, string telefono, string email, string direccion)
    {
        Id = id;
        Nombre = nombre ?? "";
        Telefono = telefono ?? "";
        Email = email ?? "";
        Direccion = direccion ?? "";
    }
}

class Program
{
    static List<Contacto> contactos = new List<Contacto>();

    static void Main()
    {
        Console.WriteLine("Mi Agenda Perrón");
        Console.WriteLine("Bienvenido a tu lista de contactos");

        // Agregar un contacto inicial con los valores proporcionados
        contactos.Add(new Contacto(1, "Saul", "809-555-1234", "saul@email.com", "Calle Alejandro Ibarra #25"));

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n1. Agregar Contacto");
            Console.WriteLine("2. Ver Contactos");
            Console.WriteLine("3. Buscar Contacto");
            Console.WriteLine("4. Modificar Contacto");
            Console.WriteLine("5. Eliminar Contacto");
            Console.WriteLine("6. Salir");
            Console.Write("Elige una opción: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        AgregarContacto();
                        break;
                    case 2:
                        VerContactos();
                        break;
                    case 3:
                        BuscarContacto();
                        break;
                    case 4:
                        ModificarContacto();
                        break;
                    case 5:
                        EliminarContacto();
                        break;
                    case 6:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingresa un número válido.");
            }
        }
    }

    static void AgregarContacto()
    {
        Console.WriteLine("\nVamos a agregar un nuevo contacto.");

        int id = contactos.Count + 1;

        Console.Write("Ingrese el Nombre: ");
        string nombre = Console.ReadLine() ?? "";
        while (string.IsNullOrWhiteSpace(nombre))
        {
            Console.Write("El nombre no puede estar vacío. Ingrese nuevamente: ");
            nombre = Console.ReadLine() ?? "";
        }

        Console.Write("Ingrese el Teléfono: ");
        string telefono = Console.ReadLine() ?? "";

        Console.Write("Ingrese el Email: ");
        string email = Console.ReadLine() ?? "";

        Console.Write("Ingrese la Dirección: ");
        string direccion = Console.ReadLine() ?? "";

        contactos.Add(new Contacto(id, nombre, telefono, email, direccion));
        Console.WriteLine("Contacto agregado con éxito.");
    }

    static void VerContactos()
    {
        Console.WriteLine("\nLista de Contactos:");
        Console.WriteLine("ID   Nombre       Teléfono       Email        Dirección");
        Console.WriteLine("----------------------------------------------------------");

        foreach (var c in contactos)
        {
            Console.WriteLine($"{c.Id}   {c.Nombre}   {c.Telefono}   {c.Email}   {c.Direccion}");
        }
    }

    static void BuscarContacto()
    {
        Console.Write("\nIngrese el ID del contacto a buscar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var contacto = contactos.Find(c => c.Id == id);
            if (contacto != null)
            {
                Console.WriteLine($"Nombre: {contacto.Nombre}");
                Console.WriteLine($"Teléfono: {contacto.Telefono}");
                Console.WriteLine($"Email: {contacto.Email}");
                Console.WriteLine($"Dirección: {contacto.Direccion}");
            }
            else
            {
                Console.WriteLine("No se encontró un contacto con ese ID.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    static void ModificarContacto()
    {
        Console.Write("\nIngrese el ID del contacto a modificar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var contacto = contactos.Find(c => c.Id == id);
            if (contacto != null)
            {
                Console.Write($"Nuevo nombre ({contacto.Nombre}): ");
                string nombre = Console.ReadLine() ?? contacto.Nombre;

                Console.Write($"Nuevo teléfono ({contacto.Telefono}): ");
                string telefono = Console.ReadLine() ?? contacto.Telefono;

                Console.Write($"Nuevo email ({contacto.Email}): ");
                string email = Console.ReadLine() ?? contacto.Email;

                Console.Write($"Nueva dirección ({contacto.Direccion}): ");
                string direccion = Console.ReadLine() ?? contacto.Direccion;

                contacto.Nombre = nombre;
                contacto.Telefono = telefono;
                contacto.Email = email;
                contacto.Direccion = direccion;

                Console.WriteLine("Contacto modificado con éxito.");
            }
            else
            {
                Console.WriteLine("No se encontró un contacto con ese ID.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    static void EliminarContacto()
    {
        Console.Write("\nIngrese el ID del contacto a eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var contacto = contactos.Find(c => c.Id == id);
            if (contacto != null)
            {
                Console.Write("¿Seguro que quieres eliminar este contacto? (S/N): ");
                string confirmacion = Console.ReadLine()?.ToUpper() ?? "N";
                if (confirmacion == "S")
                {
                    contactos.Remove(contacto);
                    Console.WriteLine("Contacto eliminado con éxito.");
                }
                else
                {
                    Console.WriteLine("Eliminación cancelada.");
                }
            }
            else
            {
                Console.WriteLine("No se encontró un contacto con ese ID.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }
}
