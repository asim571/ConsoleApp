using Microsoft.Data.SqlClient;
namespace ConsoleApp1
{
   class UpdateData
    {
        static void UpdatingData()
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

                // Update query
                string query = "UPDATE students SET name = @name, stream = @stream WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);

                // Parameters
                cmd.Parameters.AddWithValue("@name", "ASIM");
                cmd.Parameters.AddWithValue("@stream", "CSIT");
                cmd.Parameters.AddWithValue("@id", 1); 

                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} rows updated successfully.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Oops! Something went wrong. " + ex.Message);
                // Log exception details for debugging
            }
            finally
            {
                // Closing connection
                conn?.Close();
            }
        }
        static void Main(string[] args)
        {
            UpdatingData();
        }

    }
}
