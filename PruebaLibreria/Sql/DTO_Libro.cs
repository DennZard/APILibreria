using PruebaLibreria.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaLibreria.Sql
{
    public class DTO_Libro : GetConnectionDAO
    {
        public DTO_Libro() { } 

        public List<Models.Libro> getLibros()
        {
            var listaLibros = new List<Models.Libro>();
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"call getLibros()";
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var t = new Models.Libro();
                    t.id = reader.GetFieldValue<int>(0);
                    t.nombre= reader.GetFieldValue<String>(1);
                    t.isbn = reader.GetFieldValue<String>(2);
                    t.tema = reader.GetFieldValue<String>(3);
                    t.formato = reader.GetFieldValue<String>(4);
                    t.autor = reader.GetFieldValue<String>(5);
                    t.edicion = reader.GetFieldValue<String>(6);
                    t.precio = reader.GetFieldValue<Double>(7);
                    t.imgName = reader.GetFieldValue<String>(1) + ".jpg";
                    listaLibros.Add(t);
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

            return listaLibros;
        }
        public Models.Response putLibro(Models.RequestLibro request)
        {
            var response = new Models.Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @" call putLibro('nombre',autor,tema,
                precio,edicion,formato,cantidad,'isbn')";
                sql = sql.Replace("nombre", request.nombre);
                sql = sql.Replace("autor", request.autor);
                sql = sql.Replace("tema", request.tema);
                sql = sql.Replace("precio", request.precio.ToString());
                sql = sql.Replace("edicion", request.edicion);
                sql = sql.Replace("formato", request.formato);
                sql = sql.Replace("cantidad", request.cantidad.ToString());
                sql = sql.Replace("isbn", request.isbn);

                UploadController uploadController;

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.ok = "Libro añadido correctamente";
                var libro = new Models.Libro();
                libro.nombre= request.nombre;
                libro.autor = request.autor;
                libro.tema = request.tema;
                libro.precio = request.precio;
                libro.edicion = request.edicion;
                libro.formato = request.formato;
                libro.cantidad = request.cantidad;
                libro.isbn = request.isbn;
                response.data = libro;
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

        public Models.Response postLibro(Models.Request request)
        {
            var response = new Models.Response();
            try
            {
                var cmd = connection.CreateCommand();
                //TODO
                var sql = @" call postLibro(id, 'nombre')";
                sql = sql.Replace("nombre", request.nombre);
                sql = sql.Replace("id", request.id.ToString());

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.ok = "Libro actualizado correctamente";
                var libro = new Models.Libro();
                libro.id = request.id;
                libro.nombre = request.nombre;
                response.data = libro;
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
        public Models.Response deleteLibro(Models.Request request)
        {
            var response = new Models.Response();
            try
            {
                var cmd = connection.CreateCommand();
                var sql = @" call deleteLibro(id)";
                sql = sql.Replace("id", request.id.ToString());

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.ok = "Libro eliminado con exito";
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
