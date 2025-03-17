using PruebaLibreria.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaLibreria
{
    public class DTO_Autor : GetConnectionDAO
    {
        public DTO_Autor() { }

        public List<Models.Autor> getAutores()
        {
            var listaAutores = new List<Models.Autor>();
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"call getAutores()";
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var autor = new Models.Autor();
                    autor.id = reader.GetFieldValue<int>(0);
                    autor.nombre = reader.GetFieldValue<String>(1);

                    listaAutores.Add(autor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return listaAutores;
        }
    
        public Models.Response putAutor(Models.Request request)
        {
            var response = new Models.Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @" call putAutor('nombre')";
                sql = sql.Replace("nombre", request.nombre);

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.ok = "Autor añadido correctamente";
                // Cargamos el autor en el response
                var autor = new Models.Autor();
                autor.nombre = request.nombre;
                response.data = autor;
            }
            catch(Exception ex) 
            {
                response.error = "Error interno al insertar: " + ex.Message;
            }
            finally
            {
                connection.Close() ;   
            }
            return response;
                
        }

        public Models.Response postAutor(Models.Request request)
        {
            var response = new Models.Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @" call postAutor(id, 'nombre')";
                sql = sql.Replace("id", request.id.ToString());
                sql = sql.Replace("nombre", request.nombre);

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.ok = "Autor actualizado correctamente";
                // Cargamos el autores en el response
                var autor = new Models.Autor();
                autor.id = request.id;
                autor.nombre = request.nombre;
                response.data = autor;
            }
            catch (Exception ex)
            {
                response.error = "Error interno al actualizar: " + ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return response;

        }

        public Models.Response deleteAutor(Models.Request request)
        {
            var response = new Models.Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @" call deleteAutor(id)";
                sql = sql.Replace("id", request.id.ToString());

                cmd.CommandText = sql;

                connection.Open();
                int num = cmd.ExecuteNonQuery();

                if (num == 0)
                {
                    response.error = "No se pudo eliminar el autor";
                }
                else
                {
                    response.ok = "Autor eliminado con exito";
                    // Cargamos el autores en el response
                    var autor = new Models.Autor();
                    autor.id = request.id;
                    response.data = autor;
                }
            }
            catch (Exception ex)
            {
                response.error = "Error interno al borrar: " + ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return response;

        }
    }
}