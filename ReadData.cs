using Microsoft.Data.SqlClient;

namespace ConsoleApp1
{
    public class ReadingData
    {
        static void ConnectAndRead()
        {
            SqlConnection conn = null;
            try
            {
                // Creating Connection
                string conStr = @"Server=ASIM; database=AsimNCCLab; Integrated Security = SSPI; TrustServerCertificate = true";
                conn = new SqlConnection(conStr);
                // Opening Connection
                conn.Open();
                Console.WriteLine("Connection Established Successfully");

                string query = "SELECT id, name, stream FROM students";
                // SQL query with parameters
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    Console.WriteLine("id \t name\t\t stream");
                    // Looping through each record
                    while (sdr.Read())
                    {
                        Console.WriteLine(sdr["id"] + " \t " + sdr["name"] + " \t\t " +
                            sdr["stream"]);
                    }
                }

                Console.WriteLine("All Records are fetched Successfully");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Oops! Something went wrong. " + ex.Message);
            }
            finally
            {
                conn?.Close();
            }

        }
        static void Main(string[] args)
        {
            ConnectAndRead();
        }
    }
}
