using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace PruebaLibreria.Sql
{
    public class DAO
    {
        private static string conString = "Server=localhost;Database=@bbdd;Uid=@user;Pwd=@password;";
        private static MySqlConnection connection = null;
        private static DAO accessMysql;

        private static String bbdd { get; set; } = null;
        private static String user {  get; set; } = null;
        private static String password { get; set; } = null;

        // Singleton
        public static DAO instance(String Bbdd, String user, String password)
        {
            try
            {
                if (accessMysql != null)
                {
                    connection.Close();
                    createInstance(Bbdd, user, password);
                    // Cambiamos la conexión
                }
                else
                {
                    createInstance(Bbdd, user, password);
                    // new connection
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al iniciar conexíón" + ex.Message);
            }

            return accessMysql;

        }

        public static void createInstance(String bbdd, String user, String password)
        {
            accessMysql = new DAO(bbdd, user, password);
            DAO.user = user;
            DAO.password = password;
            DAO.bbdd = bbdd;
        }

        private DAO(String bbdd, String user, String password)
        {
            try
            {
                var url = DAO.conString.Replace("@bbdd", bbdd);
                url = url.Replace("@user", user);
                url = url.Replace("@password", password);

                connection = new MySql.Data.MySqlClient.MySqlConnection();
                connection.ConnectionString = url;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la conexión " + ex.Message);
            }

        }

        public MySqlConnection getConnection()
        {
            return connection;
        }

        public Boolean check()
        {
            return (connection != null);
        }


    }
}