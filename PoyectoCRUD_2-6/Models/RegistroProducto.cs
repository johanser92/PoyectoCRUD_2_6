using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace PoyectoCRUD_2_6.Models
{
    public class RegistroProducto
    {

        private SqlConnection con;

        //Conexion a la DB
        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConexionDB"].ToString();
            con = new SqlConnection(constr);
        }

        public int Alta(Producto pro)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into Productos(Id, Descripcion, Tipo, Precio) values (@Id, @Descripcion, @Tipo, @Precio)", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            comando.Parameters.Add("@Tipo", SqlDbType.VarChar);
            comando.Parameters.Add("@Precio", SqlDbType.Float);
            comando.Parameters["@Id"].Value = pro.Id;
            comando.Parameters["@Descripcion"].Value = pro.Descripcion;
            comando.Parameters["@Tipo"].Value = pro.Tipo;
            comando.Parameters["@Precio"].Value = pro.Precio;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        //Muestrar todos los registro de la DB
        public List<Producto> RecuperarTodos()
        {

            Conectar();
            List<Producto> productos = new List<Producto>();

            SqlCommand com = new SqlCommand("select Id, Descripcion, Tipo, Precio from Productos", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Producto pro = new Producto
                {
                    Id = int.Parse(registros["Id"].ToString()),
                    Descripcion = registros["Descripcion"].ToString(),
                    Tipo = registros["Tipo"].ToString(),
                    Precio = float.Parse(registros["Precio"].ToString())
                };
                productos.Add(pro);
            }
            con.Close();
            return productos;
        }
        public Producto Recuperar(int Id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select Id,Descripcion, Tipo, Precio from Productos where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = Id;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Producto producto = new Producto();
            if (registros.Read())
            {
                producto.Id = int.Parse(registros["Id"].ToString());
                producto.Descripcion = registros["Descripcion"].ToString();
                producto.Descripcion = registros["Tipo"].ToString();
                producto.Precio = float.Parse(registros["Precio"].ToString());
            }
            con.Close();
            return producto;
        }
        public int Modificar(Producto pro)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update Productos set Descripcion=@Descripcion, Tipo=@Tipo,Precio=@Precio where Id=@Id", con);
            comando.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            comando.Parameters["@descripcion"].Value = pro.Descripcion;
            comando.Parameters.Add("@Tipo", SqlDbType.VarChar);
            comando.Parameters["@Tipo"].Value = pro.Tipo;
            comando.Parameters.Add("@Precio", SqlDbType.Float);
            comando.Parameters["@Precio"].Value = pro.Precio;
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = pro.Id;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int Borrar(int Id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from Productos where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = Id;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
    
}