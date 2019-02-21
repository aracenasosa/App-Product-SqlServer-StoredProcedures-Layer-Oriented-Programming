using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Interfaz_Morderna_de_Productos.Datos
{
    class Conexion
    {

        static private string Cadena = "Server = DESKTOP-CHUO1AH; DataBase = Tienda; Integrated Security = true";
        private SqlConnection Conex = new SqlConnection(Cadena);


        public SqlConnection Connect()
        {

            if(Conex.State == ConnectionState.Closed)
            {
                Conex.Open();
            }

            return Conex;
        }

        public SqlConnection Disconnect()
        {

            if (Conex.State == ConnectionState.Open)
            {
                Conex.Close();
            }

            return Conex;
        }
    }
}
