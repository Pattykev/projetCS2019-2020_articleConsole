using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;

namespace projetCS20192020
{
    class AccessBD
    {
        private static OdbcConnection conn = null;
        public static OdbcConnection getConnexion()
        {
            if (conn == null)
            {
                conn = new OdbcConnection("dsn=basearticle");
                conn.Open();

            }
            return conn;
        }
    }
}
