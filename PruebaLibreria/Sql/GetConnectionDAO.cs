using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace PruebaLibreria.Sql
{
    public class GetConnectionDAO
    {
        private DAO accessMysql;
        protected MySqlConnection connection = null;

        protected GetConnectionDAO()
        {
            try
            {
                accessMysql = DAO.instance("libreria", "root", "");

                var cnnString = ConfigurationManager.AppSettings["CnnString"];
                var Connection = new MySql.Data.MySqlClient.MySqlConnection();
                Connection.ConnectionString = cnnString;
                connection = Connection;
                //connection = accessMysql.getConnection();
            }
            catch (Exception ex) 
            {
                throw new Exception("Error al crear conexión con getConnectionDAO");
            }
        }
    }
}