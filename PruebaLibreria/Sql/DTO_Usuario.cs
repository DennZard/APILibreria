using PruebaLibreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PruebaLibreria.Sql
{
    public class DTO_Usuario : GetConnectionDAO
    {
        public DTO_Usuario() { }

        public Models.Response PutUsuario(Models.Request_UsuarioBanco request)
        {
            var response = new Models.Response();
            try
            {

                var crypt = cryptoPW(request.psw);

                var cmd = connection.CreateCommand();   
                var sql = @" call putUsuario('nombre', 'apellidos', 'cp','direccion', 'poblacion', 'dni', 'email','psw')";
                sql = sql.Replace("nombre", request.nombre);
                sql = sql.Replace("apellidos", request.apellidos);
                sql = sql.Replace("cp", request.cp);
                sql = sql.Replace("direccion", request.direccion);
                sql = sql.Replace("poblacion", request.poblacion);
                sql = sql.Replace("dni", request.dni);
                sql = sql.Replace("email", request.email);
                sql = sql.Replace("psw", crypt);

                cmd.CommandText = sql;

                connection.Open();
                cmd.ExecuteNonQuery();

                response.ok = "Usuario registrado correctamente";
               
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

        public Models.Response logIn(Models.RequestUsuario request)
        {
            var response = new Models.Response();
            try
            {
                var crypt = cryptoPW(request.psw);

                var cmd = connection.CreateCommand();
                var sql = @"call isUserRegister('@email', '@psw')";
                sql = sql.Replace("@email", request.email);
                sql = sql.Replace("@psw", crypt);
                cmd.CommandText = sql;

                connection.Open();
                var reader = cmd.ExecuteReader();
                var usuario = new Usuario();
                while (reader.Read())
                {
                    usuario.nombre = reader.GetFieldValue<string>(0);
                    usuario.apellidos = reader.GetFieldValue<string>(1);
                    usuario.cp = reader.GetFieldValue<string>(2);
                    usuario.direccion = reader.GetFieldValue<string>(3);
                    usuario.poblacion = reader.GetFieldValue<string>(4);
                    usuario.dni = reader.GetFieldValue<string>(5);
                    usuario.email = reader.GetFieldValue<string>(6);
                    usuario.id = reader.GetFieldValue<int>(8);
                }
                response.ok = "Usuario existe";
                response.data = usuario;


            } catch (Exception e)
            {
                response.error = e.Message;
            } finally
            {
                connection.Close();
            }
            return response;
        }
        private String cryptoPW(String str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
   
}