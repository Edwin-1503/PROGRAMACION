namespace GimnasioReservas.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        public Usuario() { }

        public Usuario(string nombre, string email)
        {
            Nombre = nombre;
            Email = email;
        }

        public override string ToString() => $"{Nombre} ({Email})";
    }
}
namespace GimnasioReservas.Models
{
    public class Clase
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Horario { get; set; }

        public Clase() { }

        public Clase(string nombre, string horario)
        {
            Nombre = nombre;
            Horario = horario;
        }

        public override string ToString() => $"{Nombre} - {Horario}";
    }
}
namespace GimnasioReservas.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ClaseId { get; set; }
    }
}
