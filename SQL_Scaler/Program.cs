using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections.Concurrent;


namespace SQL_Scaler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program.Connection();
            Console.ReadLine();
        }
        static void Connection()
        {
            string cs = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(cs))
                {
                    
                    String query = "Select Max(Marks) from Student";
                    //String query = "SELECT * FROM Student WHERE Marks = (SELECT MAX(Marks) FROM Student);";

                    SqlCommand cmd = new SqlCommand(query, connection);


                    connection.Open();
                    int a = (int)cmd.ExecuteScalar();

                    Console.WriteLine(a);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
