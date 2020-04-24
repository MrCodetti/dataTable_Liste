using System;
using System.Data;
using System.Data.SqlClient;
using c = System.Console;
namespace KundenListe
{
    class DatenZugriff
    {
        static string conStrg = (@"Data Source=DESKTOP-0S31MOV\SQLKURS;" +
        "Initial Catalog=dbPersonal;Integrated Security=sspi");
        static SqlConnection cn = new SqlConnection(conStrg);

        static string sCommand = "SELECT tblPersonal.Zuname, tblPersonal.Vorname, tblAdresse.Strasse, " +
            "tblAdresse.Hausnummer, tblPLZ.Ort, tblPLZ.PLZ " +
            "FROM tblAdresse INNER JOIN tblPersonal " +
            "ON tblAdresse.PersID = tblPersonal.PersID " +
            "INNER JOIN tblPLZ ON tblAdresse.PlzID = tblPLZ.PlzID " +
            "WHERE Zuname = @ZName " +
            "ORDER BY PLZ";
        static void Main()
        {
            try
            {
                string strZName;
                c.Write("Bitte um den exakten Zuname des Kunden: ");
                strZName = Convert.ToString(c.ReadLine());
                SqlCommand cmd = new SqlCommand(sCommand, cn);
                cmd.Parameters.Add("@ZName", SqlDbType.NVarChar, 30).Value = strZName;
                cn.Open();
                SqlDataReader drKunde = cmd.ExecuteReader();
                c.Clear();
                c.WriteLine("Kunde: {0}\n", strZName);
                if (drKunde.HasRows)
                {
                    foreach (Object ob in drKunde)
                    {
                        c.WriteLine("{0,-15} {1,-15} {2} {3,-6} {4,-6} {5,-15}",
                                                    drKunde[0], drKunde[1], drKunde[2], drKunde[3], drKunde[4], drKunde[5]);

                    }
                    c.ReadKey();
                }
                else
                {
                    c.Write("Keine Einträge zu Ihrem Kunden {0} gefunden!", strZName);
                    c.ReadKey();
                }
            }
            catch (SqlException e)
            {
                string msg = "";
                for (int i = 0; i < e.Errors.Count; i++)
                {
                    msg += "Error #" + i + " Message: " + e.Errors[i].Message + "\n";
                }
                Console.WriteLine(msg);
                Console.ReadKey();
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }
    }
}