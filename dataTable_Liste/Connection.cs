using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataTable_Liste
{
    class Connection
    {
        static string connectionString = @"Data Source=DESKTOP-0S31MOV\SQLKURS;" +
                                         "Initial Catalog=dbLagerVerwaltung;" +
                                         "Integrated Security=sspi;";

        public static SqlConnection cn = new SqlConnection(connectionString);

        static string sCommand = "SELECT Mit_ID as [Mit-Nr:], " +
                                 "Mit_Nname as Nachname, " +
                                 "Mit_Vname as Vorname, " +
                                 "Mit_Mobil as Mobil, " +
                                 "Mit_Mail as Mail " +
                                 "FROM tblMitarbeiter " +
                                 "ORDER BY Mit_Nname";

        public static SqlDataAdapter da = new SqlDataAdapter(sCommand, cn);

        public static DataTable dataTable = new DataTable();

    }
}
