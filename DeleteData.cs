using Microsoft.Data.SqlClient;
namespace ConsoleApp1
{
   class DeleteData
    {
        static void DeletingData()
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

                // Delete query
                string query = "DELETE FROM students WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);

                // Parameter
                cmd.Parameters.AddWithValue("@id", 1); 

                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} rows deleted successfully.");
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
            DeletingData();
        }

    }
}
