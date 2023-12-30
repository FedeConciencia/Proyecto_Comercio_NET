using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ControladorMarca
    {

        //Metodo para obtener todas las Marcas:
        public List<Marca> allMarcas()
        {

            List<Marca> list = new List<Marca>();
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;

            try
            {

                //Conectamos a la BD:
                connection = Conexion.Conexion.ConexionBD();

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT Id, Descripcion FROM MARCAS";
                command.Connection = connection;

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Marca marca = new Marca();
                    marca.Id = (int)reader["Id"];
                    marca.Description = (string)reader["Descripcion"];


                    list.Add(marca);

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
