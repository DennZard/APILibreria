using PruebaLibreria.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaLibreria
{
    public class DTO_Tema : GetConnectionDAO
    {
        public DTO_Tema() { }

        public List<Models.Tema> getTemas()
        {
            var listaTemas = new List<Models.Tema>();
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"call getTemas()";
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var t = new Models.Tema();
                    t.id = reader.GetFieldValue<int>(0);
                    t.nombre = reader.GetFieldValue<String>(1);

                    listaTemas.Add(t);

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

            return listaTemas;
        }
    
        public Models.Response putTema(Models.Request request)
        {
            var response = new Models.Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @" call putTema('nombre')";
                sql = sql.Replace("nombre", request.nombre);

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.ok = "Tema añadido correctamente";
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

        public Models.Response postTema(Models.Request request)
        {
            var response = new Models.Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @" call postTema(id, 'nombre')";
                sql = sql.Replace("nombre", request.nombre);
                sql = sql.Replace("id", request.id.ToString());

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.ok = "Tema actualizado correctamente";
                // Cargamos el tema en el response
                var tema = new Models.Tema();
                tema.id = request.id;
                tema.nombre = request.nombre;
                response.data = tema;
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

        public Models.Response deleteTema(Models.Request request)
        {
            var response = new Models.Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @" call deleteTema(id)";
                sql = sql.Replace("id", request.id.ToString());

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.ok = "Tema eliminado con exito";
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