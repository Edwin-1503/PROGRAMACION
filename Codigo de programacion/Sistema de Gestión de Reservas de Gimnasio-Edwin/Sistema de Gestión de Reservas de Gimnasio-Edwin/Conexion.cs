using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;

namespace Sistema_de_Gestión_de_Reservas_de_Gimnasio_Edwin
{
    internal class  Conexion
    {
        public static SqlConnection ObtenerConexion()

        {

            string cadena = "Server=DESKTOP-RH22C7P\\SQLEXPRESS;Database=GymReservaDB; Integrated Security=True;TrustServerCertificate=True;";

            
            return new SqlConnection(cadena);

        }

    }
}
