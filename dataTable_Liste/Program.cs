using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataTable_Liste
{
    class Program
    {
		static void PrintListe(IEnumerable liste)
		{
			foreach (string item in liste)
			{
				Console.WriteLine(" {0}", item);
			}
		}

        static void Main(string[] args)
        {
			try
			{
				Connection.cn.Open();
				Console.WriteLine("Connection with Database...");
				

				int recordsAffected = Connection.da.Fill(Connection.dataTable);
				
				if (recordsAffected > 0)
				{
					Console.WriteLine("- Liste unserer {0} Mitarbeiter\n", recordsAffected);
					ArrayList alMitarbeiter = new ArrayList();

					for (int i = 0; i < Connection.dataTable.Rows.Count; i++)
					{
						for (int j = 0; j < Connection.dataTable.Columns.Count; j++)
						{
							alMitarbeiter.Add(Connection.dataTable.Rows[i][j].ToString());
						}
					}
					PrintListe(alMitarbeiter);
					Console.ReadKey();
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
				if (Connection.cn.State != ConnectionState.Closed)
				{
					Connection.cn.Close();
				}
			}
        }
    }
}
