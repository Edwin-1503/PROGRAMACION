using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Reservas_de_Gimnasio1
{
    

    // Clases internas
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }

    
    
}


