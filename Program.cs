using System;
using Microsoft.Data.SqlClient;

namespace ConsoleApp1
{
    class InsertionDemo
    {
        static void ConnectAndInsert()
        {
            SqlConnection conn = null;
            try
            {
                //Creating Connection
                string conStr = @"Server=ASIM; database=AsimNCCLab; Integrated Security = SSPI; TrustServerCertificate = true";
                conn = new SqlConnection(conStr);
                //Opening COnnection
                conn.Open();
                Console.WriteLine("COnnection Established Succesfully");
                int id = 1;
                string name = "Asim";
                string stream = "Csit";
                string query = "INSERT INTO students VALUES(" + id + ",'" + name + "','" + stream + "')";
                SqlCommand sqlcmd = new SqlCommand(query, conn);
                //Executing the sql query
                int n = sqlcmd.ExecuteNonQuery();
                //Displaying a message
                Console.WriteLine("Record Inserted Successfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong. " + ex.Message);

            }
            finally
            {
                //Closing Connection
                conn.Close();
            }
        }
        static void Main(string[] args)
        {
            ConnectAndInsert();
        }
    }

}
