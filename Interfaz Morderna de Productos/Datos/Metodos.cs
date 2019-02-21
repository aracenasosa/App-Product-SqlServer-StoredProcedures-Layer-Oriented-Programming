using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Interfaz_Morderna_de_Productos.Datos
{
    class Metodos
    {

        private Conexion Conexion = new Conexion();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader Leer;


       private int IdProduct;
       private int IdCategorie;
       private int IdMarca;
       private string Description;
       private double Price;

        public int IdProduct1
        {

            get => IdProduct;
            set => IdProduct = value;
        }
        public int IdCategorie1
        {
            get => IdCategorie;
            set => IdCategorie = value;
        }
        public int IdMarca1
        {
            get => IdMarca;
            set => IdMarca = value;
        }
        public string Description1
        {
            get => Description;
            set => Description = value;
        }
        public double Price1
        {
            get => Price;
            set => Price = value;
        }

        public DataTable Categories()
        {

            DataTable Table = new DataTable();
            Comando.Connection = Conexion.Connect();
            Comando.CommandText = "ListarCategorias";
            Comando.CommandType = CommandType.StoredProcedure;
            Leer = Comando.ExecuteReader();
            Table.Load(Leer);
            Conexion.Disconnect();
            Leer.Close();

            return Table;
        }

        public DataTable Brands()
        {

            DataTable Table = new DataTable();
            Comando.Connection = Conexion.Connect();
            Comando.CommandText = "ListarMarcas";
            Comando.CommandType = CommandType.StoredProcedure;
            Leer = Comando.ExecuteReader();
            Table.Load(Leer);
            Conexion.Disconnect();
            Leer.Close();

            return Table;
        }

        public void Insert()
        {

            
            Comando.Connection = Conexion.Connect();
            Comando.CommandText = "InsertarProducto";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Cag", IdCategorie1);
            Comando.Parameters.AddWithValue("@Marc", IdMarca1);
            Comando.Parameters.AddWithValue("@Descri", Description1);
            Comando.Parameters.AddWithValue("@Precio", Price1);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Disconnect();

        }

        public DataTable List()
        {

            DataTable Table = new DataTable();
            Comando.Connection = Conexion.Connect();
            Comando.CommandText = "ListarProduct";
            Comando.CommandType = CommandType.StoredProcedure;
            Leer = Comando.ExecuteReader();
            Table.Load(Leer);
            Conexion.Disconnect();
            Leer.Close();

            return Table;
        }

        public void Update()
        {

            Comando.Connection = Conexion.Connect();
            Comando.CommandText = "Update Producto set IdCag = " + IdCategorie1 + ", IdMarca = " + IdMarca1 + ", Descripcion = '" + Description1 + "', Precio = " + Price1 + 
                " Where IdProducto = " + IdProduct1;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.Disconnect();
        }

        public void Delete()
        {

            Comando.Connection = Conexion.Connect();
            Comando.CommandText = "Delete from Producto Where IdProducto = " + IdProduct1;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.Disconnect();
        }
    }
}
