using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.SQL
{
    class sql
    {
        //static void Main(string[] args)
        //{
        //    string ConnectionString = "Server=DESKTOP-5HHTAD8;DataBase=Test;User Id=sa;Password=12345";
        //    //string query = "Select * From Students";
        //    string query = "Insert INTO Students Values ('OMar', 95)";

        //    using (SqlConnection conn = new SqlConnection(ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        conn.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        //  cmd.ExecuteNonQuery();

        //        while (reader.Read())
        //        {
        //            Console.WriteLine($"ID IS {reader["Id"]}, Student Name IS {reader["FullName"]}, Student Grade IS {reader["Grade"]} ");

        //            //int id = Convert.ToInt32(reader["ID"]);
        //            //string name = Convert.ToString(reader["FullName"]);
        //            //double grade = Convert.ToDouble(reader["Grade"]);

        //            //Console.WriteLine(id + name + grade);
        //        }
        //        reader.Close();
        //        conn.Close();
        //    }
        //}
    }
}
