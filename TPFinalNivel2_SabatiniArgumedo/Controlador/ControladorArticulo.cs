using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Modelo;
using Conexion;
using System.Reflection;


namespace Controlador
{
    public class ControladorArticulo
    {

        //Metodo para obtener todos los Articulos:
        public List<Articulo> allArticulo()
        {

            List<Articulo> list = new List<Articulo>();
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;

            try
            {

                //Conectamos a la BD:
                connection = Conexion.Conexion.ConexionBD();

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT Id, Codigo, Nombre, Descripcion, ImagenUrl, Precio FROM ARTICULOS";
                command.Connection = connection;

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Articulo articulo = new Articulo();
                    articulo.Id = reader.GetInt32(0);
                    articulo.Code = reader.GetString(1);
                    articulo.Name = reader.GetString(2);
                    articulo.Description = reader.GetString(3);
                    articulo.ImgUrl = reader.GetString(4);
                    articulo.Price = Double.Parse(reader.GetSqlMoney(5).ToString()); //Importante investigar este tipo de conversiones entre Sql y C# .NET

                   

                    list.Add(articulo);

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


        //Metodo para obtener todos los articulos relacionados con Categoria y Marca:
        public List<Articulo> allArtCatMar()
        {
            List<Articulo> list = new List<Articulo>();
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;

            try
            {

                //Conectamos a la BD:
                connection = Conexion.Conexion.ConexionBD();

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.ImagenUrl, a.Precio, c.Id AS Id_Cat, c.Descripcion AS Categoria, m.Id AS Id_Marc, m.Descripcion AS Modelo FROM ARTICULOS AS a, CATEGORIAS AS c, MARCAS AS m WHERE c.Id = a.IdCategoria AND m.Id = a.IdMarca";
                command.Connection = connection;

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Articulo articulo = new Articulo();
                    articulo.Id = reader.GetInt32(0);
                    articulo.Code = reader.GetString(1);
                    articulo.Name = reader.GetString(2);
                    articulo.Description = reader.GetString(3);
                    articulo.ImgUrl = reader.GetString(4);
                    articulo.Price = Double.Parse(reader.GetSqlMoney(5).ToString()); //Importante investigar este tipo de conversiones entre Sql y C# .NET

                    articulo.Categoria = new Categoria();

                    articulo.Categoria.Id = reader.GetInt32(6);
                    articulo.Categoria.Description = reader.GetString(7);

                    articulo.Marca = new Marca();
                    
                    articulo.Marca.Id = reader.GetInt32(8);
                    articulo.Marca.Description = reader.GetString(9);

                    


                    list.Add(articulo);

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

        //Metodo para insertar un nuevo objeto Articulo en la BD:
        public void insertArticulo(Articulo articulo)
        {

            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();

            try
            {
                //Conectamos a la BD:
                connection = Conexion.Conexion.ConexionBD();

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = $"INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, ImagenUrl, Precio, IdMarca, IdCategoria) VALUES " +
                $"('{articulo.Code}', '{articulo.Name}', '{articulo.Description}', '{articulo.ImgUrl}', {articulo.Price}, {articulo.Marca.Id}, {articulo.Categoria.Id})";

                command.Connection = connection;

                connection.Open();

                //Ejecutamos el Script:
                command.ExecuteNonQuery();


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

        //Metodo para actualizar un nuevo objeto Articulo en la BD:
        public void updateArticulo(Articulo articulo)
        {

            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();

            try
            {
                //Conectamos a la BD:
                connection = Conexion.Conexion.ConexionBD();

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = $"UPDATE ARTICULOS SET Codigo = '{articulo.Code}', Nombre = '{articulo.Name}', Descripcion = '{articulo.Description}', ImagenUrl = '{articulo.ImgUrl}', Precio = {articulo.Price}, IdMarca = {articulo.Marca.Id}, IdCategoria = {articulo.Categoria.Id}  WHERE Id = {articulo.Id}";
                                      

                command.Connection = connection;

                connection.Open();

                //Ejecutamos el Script:
                command.ExecuteNonQuery();


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

        //Metodo de Eliminacion Fisico de registro Articulo en BD:
        public void deleteArticulo(int num)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();

            try
            {

               
                //Conectamos a la BD:
                connection = Conexion.Conexion.ConexionBD();

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = $"DELETE FROM ARTICULOS WHERE Id = {num}";

                command.Connection = connection;

                connection.Open();

                //Ejecutamos el Script:
                command.ExecuteNonQuery();
               

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

      

        //Metodo que permite obtener List<Articulo> de los Articulos filtro Avanzado:
        public List<Articulo> filtroAvanzado(string campo, string criterio, string filtro)
        {

            List<Articulo> list = new List<Articulo>();
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;

            try
            {


                string consulta = "SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.ImagenUrl, a.Precio, c.Id AS Id_Cat, c.Descripcion AS Categoria, m.Id AS Id_Marc, m.Descripcion AS Modelo FROM ARTICULOS AS a, CATEGORIAS AS c, MARCAS AS m WHERE c.Id = a.IdCategoria AND m.Id = a.IdMarca AND ";

                //Verificamos todas las combinaciones posibles del ComboBox para completar Script:
                if (campo == "Codigo")
                {
                    if (criterio == "Comienza con")
                    {
                        consulta += $"a.Codigo LIKE '{filtro}%'";
                    }
                    else if (criterio == "Termina con")
                    {
                        consulta += $"a.Codigo LIKE '%{filtro}'";
                    }
                    else
                    {
                        consulta += $"a.Codigo LIKE '%{filtro}%'";
                    }

                }
                else if (campo == "Nombre")
                {

                    if (criterio == "Comienza con")
                    {
                        consulta += $"a.Nombre LIKE '{filtro}%'";
                    }
                    else if (criterio == "Termina con")
                    {
                        consulta += $"a.Nombre LIKE '%{filtro}'";
                    }
                    else
                    {
                        consulta += $"a.Nombre LIKE '%{filtro}%'";
                    }

                }
                else if (campo == "Descripcion")
                {

                    if (criterio == "Comienza con")
                    {
                        consulta += $"a.Descripcion LIKE '{filtro}%'";
                    }
                    else if (criterio == "Termina con")
                    {
                        consulta += $"a.Descripcion LIKE '%{filtro}'";
                    }
                    else
                    {
                        consulta += $"a.Descripcion LIKE '%{filtro}%'";
                    }

                }

                Console.WriteLine(consulta);


                //Conectamos a la BD:
                connection = Conexion.Conexion.ConexionBD();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = consulta;
                command.Connection = connection;


                connection.Open();


                reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Articulo articulo = new Articulo();
                    articulo.Id = reader.GetInt32(0);
                    articulo.Code = reader.GetString(1);
                    articulo.Name = reader.GetString(2);
                    articulo.Description = reader.GetString(3);
                    articulo.ImgUrl = reader.GetString(4);
                    articulo.Price = Double.Parse(reader.GetSqlMoney(5).ToString()); //Importante investigar este tipo de conversiones entre Sql y C# .NET

                    articulo.Categoria = new Categoria();

                    articulo.Categoria.Id = reader.GetInt32(6);
                    articulo.Categoria.Description = reader.GetString(7);

                    articulo.Marca = new Marca();

                    articulo.Marca.Id = reader.GetInt32(8);
                    articulo.Marca.Description = reader.GetString(9);


                    list.Add(articulo);

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
