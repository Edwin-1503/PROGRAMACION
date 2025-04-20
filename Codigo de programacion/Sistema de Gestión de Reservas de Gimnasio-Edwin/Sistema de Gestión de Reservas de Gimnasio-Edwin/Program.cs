using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace SistemaGimnasio
{
    // ===================== ENTIDADES =====================
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }

    public class Clase
    {
        public int IdClase { get; set; }
        public string NombreClase { get; set; }
        public string Descripcion { get; set; }
        public int Capacidad { get; set; }
    }

    public class Horario
    {
        public int IdHorario { get; set; }
        public int IdClase { get; set; }
        public string DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }

    public class Reserva
    {
        public int IdReserva { get; set; }
        public int IdUsuario { get; set; }
        public int IdHorario { get; set; }
        public DateTime FechaReserva { get; set; } = DateTime.Now;
    }

    public class Pago
    {
        public int IdPago { get; set; }
        public int IdUsuario { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; } = DateTime.Now;
        public string MetodoPago { get; set; }
    }

    // ===================== CONEXIÓN A BASE DE DATOS =====================
    public class Conexion
    {
        private readonly string cadena = "Server=localhost\\SQLEXPRESS;Database=GymReservaDB;Trusted_Connection=True;Encrypt=False;";

        private SqlConnection conexion;

        public SqlConnection Abrir()
        {
            conexion = new SqlConnection(cadena);
            conexion.Open();
            return conexion;
        }

        public void Cerrar()
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }

    // ===================== DATOS SIMULADOS =====================
    public static class DatosSimulados
    {
        public static List<Clase> Clases = new List<Clase>();
        public static List<Horario> Horarios = new List<Horario>();
        public static List<Reserva> Reservas = new List<Reserva>();
        public static List<Pago> Pagos = new List<Pago>();
    }

    // ===================== INTERFAZ DE CONSOLA =====================
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTIÓN DE RESERVAS DE GIMNASIO ===");
                Console.WriteLine("1. Listar usuarios");
                Console.WriteLine("2. Registrar usuario");
                Console.WriteLine("3. Eliminar usuario (simulado)");
                Console.WriteLine("4. Listar clases");
                Console.WriteLine("5. Agregar clase");
                Console.WriteLine("6. Registrar horario");
                Console.WriteLine("7. Registrar reserva");
                Console.WriteLine("8. Registrar pago");
                Console.WriteLine("9. Ver pagos");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\n--- Usuarios (desde la base de datos) ---");
                        var conexion = new Conexion();
                        using (var con = conexion.Abrir())
                        {
                            var comando = new SqlCommand("SELECT IdUsuario, Nombre, Apellido, Email, Telefono FROM Usuarios", con);
                            var reader = comando.ExecuteReader();
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["IdUsuario"]} - {reader["Nombre"]} {reader["Apellido"]} | {reader["Email"]} | {reader["Telefono"]}");
                            }
                            reader.Close();
                        }
                        break;

                    case 2:
                        var nuevoUsuario = new Usuario();
                        Console.Write("Nombre: "); nuevoUsuario.Nombre = Console.ReadLine();
                        Console.Write("Apellido: "); nuevoUsuario.Apellido = Console.ReadLine();
                        Console.Write("Email: "); nuevoUsuario.Email = Console.ReadLine();
                        Console.Write("Teléfono: "); nuevoUsuario.Telefono = Console.ReadLine();

                        var conexionInsert = new Conexion();
                        using (var con = conexionInsert.Abrir())
                        {
                            var insertCommand = new SqlCommand("INSERT INTO Usuarios (Nombre, Apellido, Email, Telefono, FechaRegistro) VALUES (@Nombre, @Apellido, @Email, @Telefono, @FechaRegistro)", con);
                            insertCommand.Parameters.AddWithValue("@Nombre", nuevoUsuario.Nombre);
                            insertCommand.Parameters.AddWithValue("@Apellido", nuevoUsuario.Apellido);
                            insertCommand.Parameters.AddWithValue("@Email", nuevoUsuario.Email);
                            insertCommand.Parameters.AddWithValue("@Telefono", nuevoUsuario.Telefono);
                            insertCommand.Parameters.AddWithValue("@FechaRegistro", nuevoUsuario.FechaRegistro);

                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Usuario registrado en la base de datos.");
                        }
                        break;

                    case 3:
                        Console.Write("ID de usuario a eliminar (solo simulado): ");
                        int idEliminar = int.Parse(Console.ReadLine());
                        Console.WriteLine("Simulación de eliminación. (No implementado en BD aún)");
                        break;

                    case 4:
                        Console.WriteLine("\n--- Clases ---");
                        foreach (var c in DatosSimulados.Clases)
                            Console.WriteLine($"{c.IdClase} - {c.NombreClase} ({c.Capacidad} personas): {c.Descripcion}");
                        break;

                    case 5:
                        var nuevaClase = new Clase();
                        Console.Write("Nombre clase: "); nuevaClase.NombreClase = Console.ReadLine();
                        Console.Write("Descripción: "); nuevaClase.Descripcion = Console.ReadLine();
                        Console.Write("Capacidad: "); nuevaClase.Capacidad = int.Parse(Console.ReadLine());
                        nuevaClase.IdClase = DatosSimulados.Clases.Count + 1;
                        DatosSimulados.Clases.Add(nuevaClase);
                        Console.WriteLine("Clase agregada.");
                        break;

                    case 6:
                        var nuevoHorario = new Horario();
                        Console.Write("ID Clase: "); nuevoHorario.IdClase = int.Parse(Console.ReadLine());
                        Console.Write("Día de la semana: "); nuevoHorario.DiaSemana = Console.ReadLine();
                        Console.Write("Hora inicio (HH:mm): "); nuevoHorario.HoraInicio = TimeSpan.Parse(Console.ReadLine());
                        Console.Write("Hora fin (HH:mm): "); nuevoHorario.HoraFin = TimeSpan.Parse(Console.ReadLine());
                        nuevoHorario.IdHorario = DatosSimulados.Horarios.Count + 1;
                        DatosSimulados.Horarios.Add(nuevoHorario);
                        Console.WriteLine("Horario registrado.");
                        break;

                    case 7:
                        var nuevaReserva = new Reserva();
                        Console.Write("ID Usuario: "); nuevaReserva.IdUsuario = int.Parse(Console.ReadLine());
                        Console.Write("ID Horario: "); nuevaReserva.IdHorario = int.Parse(Console.ReadLine());
                        nuevaReserva.IdReserva = DatosSimulados.Reservas.Count + 1;
                        DatosSimulados.Reservas.Add(nuevaReserva);
                        Console.WriteLine("Reserva realizada.");
                        break;

                    case 8:
                        var nuevoPago = new Pago();
                        Console.Write("ID Usuario: "); nuevoPago.IdUsuario = int.Parse(Console.ReadLine());
                        Console.Write("Monto: "); nuevoPago.Monto = decimal.Parse(Console.ReadLine());
                        Console.Write("Método de pago: "); nuevoPago.MetodoPago = Console.ReadLine();
                        nuevoPago.IdPago = DatosSimulados.Pagos.Count + 1;
                        DatosSimulados.Pagos.Add(nuevoPago);
                        Console.WriteLine("Pago registrado.");
                        break;

                    case 9:
                        Console.WriteLine("\n--- Pagos ---");
                        foreach (var p in DatosSimulados.Pagos)
                            Console.WriteLine($"Pago #{p.IdPago} - Usuario {p.IdUsuario} - {p.Monto} - {p.MetodoPago} ({p.FechaPago})");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }
    }
}
