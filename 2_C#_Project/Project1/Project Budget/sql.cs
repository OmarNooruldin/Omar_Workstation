using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Project
{
    class sql
    {
        //static void Main(string[] args)
        //{
        //    string ConnectionString = "Server=DESKTOP-5HHTAD8; DataBase=Money; User Id=sa; Password=12345;";
        //    string Query = "Select * From Budgets ";

        //    using (SqlConnection conn = new SqlConnection(ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand(Query, conn);
        //        conn.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Console.WriteLine($"ID = {reader["id"]} \n");
        //            Console.WriteLine($"Food = {reader["food"]} \n");
        //            Console.WriteLine($"Gas = {reader["gas"]} \n");
        //            Console.WriteLine($"Subscriptions = {reader["subscriptions"]} \n");
        //            Console.WriteLine($"Entertainment = {reader["entertainment"]} \n");
        //            Console.WriteLine($"Insurance = {reader["insurance"]} \n");
        //            Console.WriteLine($"Loan = {reader["loan"]} \n");
        //        }
        //        reader.Close();
        //        conn.Close();
        //    }
        //}
    }
}
