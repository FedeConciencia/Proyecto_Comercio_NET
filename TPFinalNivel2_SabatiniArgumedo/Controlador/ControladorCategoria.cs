using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ControladorCategoria
    {
        //Metodo para obtener todos las Categorias:
        public List<Categoria> allCategorias()
        {

            List<Categoria> list = new List<Categoria>();
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;

            try
            {

                //Conectamos a la BD:
                connection = Conexion.Conexion.ConexionBD();

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT Id, Descripcion FROM CATEGORIAS";
                command.Connection = connection;

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Categoria categoria = new Categoria();
                    categoria.Id = (int)reader["Id"];
                    categoria.Description = (string)reader["Descripcion"];


                    list.Add(categoria);

                }


                return list;


            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                connection.Close();


            }


        }

    }
}
