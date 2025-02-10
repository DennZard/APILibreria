using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                connection = accessMysql.getConnection();
            }
            catch (Exception ex) 
            {
                throw new Exception("Error al crear conexión con getConnectionDAO");
            }
        }
    }
}