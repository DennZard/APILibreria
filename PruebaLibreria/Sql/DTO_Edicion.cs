using PruebaLibreria.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaLibreria
{
    public class DTO_Edicion : GetConnectionDAO
    {
        public DTO_Edicion() { }

        public List<Models.Edicion> getEdiciones()
        {
            var listaEdiciones = new List<Models.Edicion>();
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"call getEdiciones()";
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var edicion = new Models.Edicion();
                    edicion.id = reader.GetFieldValue<int>(0);
                    edicion.nombre = reader.GetFieldValue<String>(1);

                    listaEdiciones.Add(edicion);
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

            return listaEdiciones;
        }
    
        public Models.Response putEdicion(Models.Request request)
        {
            var response = new Models.Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @" call putEdicion('nombre')";
                sql = sql.Replace("nombre", request.nombre);

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.ok = "Edicion añadida correctamente";
                // Cargamos la edicion en el response
                var edicion = new Models.Edicion();
                edicion.nombre = request.nombre;
                response.data = edicion;
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

        public Models.Response postEdicion(Models.Request request)
        {
            var response = new Models.Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @" call postEdicion(id, 'nombre')";
                sql = sql.Replace("id", request.id.ToString());
                sql = sql.Replace("nombre", request.nombre);

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.ok = "Edicion actualizada correctamente";
                // Cargamos el Ediciones en el response
                var edicion = new Models.Edicion();
                edicion.id = request.id;
                edicion.nombre = request.nombre;
                response.data = edicion;
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

        public Models.Response deleteEdicion(Models.Request request)
        {
            var response = new Models.Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @" call deleteEdicion(id)";
                sql = sql.Replace("id", request.id.ToString());

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.ok = "Edicion eliminada con exito";
                // Cargamos el Ediciones en el response
                var edicion = new Models.Edicion();
                edicion.id = request.id;
                response.data = edicion;
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