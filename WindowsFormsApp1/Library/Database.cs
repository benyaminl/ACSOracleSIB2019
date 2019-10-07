using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.DataAccess.Client;
namespace WindowsFormsApp1.Library
{
    class Database
    {
        /// <summary>
        /// This's the Database Connection Object
        /// Only can be used using getConnection() method
        /// </summary>
        private static OracleConnection connection;

        /// <summary>
        /// The Private property of the DB, user, password and hostname
        /// </summary>
        private static string db, user, password, hostname;

        /// <summary>
        /// Function For Connect to DB, and return of the connection is
        /// Succesful or not
        /// @see https://blogs.msdn.microsoft.com/mazhou/2017/05/26/c-7-series-part-1-value-tuples/
        /// </summary>
        /// <param name="host">The HOST name</param>
        /// <param name="db">The DB Name</param>
        /// <param name="user">Username of the DB</param>
        /// <param name="pass">Password of the user</param>
        /// <returns>Tuple named return, status and msg </returns>
        public static (bool status, string msg) 
            connect(string host, string db, string user, string pass)
        {
            bool status = false;
            string msg = "";

            try {
                connection = new OracleConnection("Data Source=" +
                    "(DESCRIPTION=" +
                    "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                    "(HOST="+host+")(PORT=1521)))" +
                    "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME="+db+")));" +
                    "user id=" + user + ";password=" + pass);
                connection.Open();
                msg = "Berhasil Koneksi!";
                status = true;
            } catch(OracleException e) {
                msg = "Connection failed!\n" + e.Message;
            }

            return (status, msg);
        }

        public static (bool status, string msg)
            connect()
        {
            hostname = "localhost";
            user = "POS";
            password = "PO";
            db = "XE"; // Always XE kalau Express
            return connect(hostname, db, user, password);
        }

        /// <summary>
        /// Function yang hanya menerima login saja, bukan hostname dsbnya. 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static (bool status, string msg)
            connect(string user, string password)
        {
            hostname = "localhost";
            db = "XE"; // Always XE kalau Express
            return connect(hostname, db, user, password);
        }
    }
}
