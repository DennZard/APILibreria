using PruebaLibreria.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaLibreria
{
    public class DTO_Formato : GetConnectionDAO
    {
        public DTO_Formato() { }

        public List<Models.Formato> getFormatos()
        {
            var listaFormatos = new List<Models.Formato>();
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"call getFormatos()";
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var formato = new Models.Formato();
                    formato.id = reader.GetFieldValue<int>(0);
                    formato.nombre = reader.GetFieldValue<String>(1);

                    listaFormatos.Add(formato);
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

            return listaFormatos;
        }
    
        public Models.Response putFormato(Models.Request request)
        {
            var response = new Models.Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @" call putFormato('nombre')";
                sql = sql.Replace("nombre", request.nombre);

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.ok = "Formato añadido correctamente";
                // Cargamos la Formato en el response
                var formato = new Models.Formato();
                formato.nombre = request.nombre;
                response.data = formato;
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

        public Models.Response postFormato(Models.Request request)
        {
            var response = new Models.Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @" call postFormato(id, 'nombre')";
                sql = sql.Replace("id", request.id.ToString());
                sql = sql.Replace("nombre", request.nombre);

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.ok = "Formato actualizado correctamente";
                // Cargamos el Formatos en el response
                var formato = new Models.Formato();
                formato.id = request.id;
                formato.nombre = request.nombre;
                response.data = formato;
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

        public Models.Response deleteFormato(Models.Request request)
        {
            var response = new Models.Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @" call deleteFormato(id)";
                sql = sql.Replace("id", request.id.ToString());

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.ok = "Formato eliminado con exito";
                // Cargamos el Formatos en el response
                var formato = new Models.Formato();
                formato.id = request.id;
                response.data = formato;
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