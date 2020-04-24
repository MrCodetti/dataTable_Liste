using System;
using System.Data;
using System.Data.SqlClient;


namespace bspSQLServer
{
    class DataAccess
    {
        //Connection to MS SQL
        static string connectionString = @"Data Source=DESKTOP-0S31MOV\SQLKURS;" +
            "Initial Catalog=dbAdministration;" +
            "Integrated Security=sspi;";

        static SqlConnection cn = new SqlConnection(connectionString);

        static string sCommand = "SELECT Bezeichnung, PLZ, Ort from tblBLZ WHERE Ort in ('Hamburg')";

        //data adapter ??
        static SqlDataAdapter da = new SqlDataAdapter(sCommand, cn);

        //table-->result set
        static DataTable dataTable = new DataTable();


        static void Main(string[] args)
        {
            try
            {
                cn.Open(); //open connection to SQL Server
                Console.WriteLine("Und nun sind wir mit der Datenbank verbunden... \n\n");
                Console.ReadKey();

                int recordsAffected = da.Fill(dataTable);

                if (recordsAffected > 0)
                {
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        Console.WriteLine("{0, -60}{1, -10}{2, -10}", dr[0], dr[1], dr[2]);
                    }
                    Console.ReadKey();
                }
            }
            catch (SqlException e)
            {
                string msg = "";
                for (int i = 0; i < e.Errors.Count; i++)
                {
                    msg += "Error # " + i + "Message: " + e.Errors[i].Message + "\n";
                }
                Console.WriteLine(msg);
                Console.ReadKey();
            }
            finally
            {
                if(cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }
    }
}
