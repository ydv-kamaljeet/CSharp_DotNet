using Microsoft.Data.SqlClient;
using System.Data;
class Program
{
    static void Main()
    {
        string cs = "Server=localhost;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;";    //------------------------ Should not be comment out
        
        //string dept = Console.ReadLine() ?? ""; //Make its default value as empty string
        int id = int.Parse(Console.ReadLine());
        string sql = @"Delete Employees where EmployeeId = @id";
        //string sql = "INSERT INTO dbo.Employees (FullName, Department, Salary)VALUES ('Neha Sharma', 'HR', 65000.00);";
        // string sql = @"UPDATE Employees SET FullName = 'sabya', Department = 'IT', Salary =69000 where EmployeeId = @id";
        using (var con = new SqlConnection(cs))
        using (var cmd = new SqlCommand(sql, con))
        {
        //    // cmd.Parameters.AddWithValue("@dept",dept);
             cmd.Parameters.AddWithValue("@id",id);
             con.Open();


        //------------------- Read the Data from DB------------------------------
            // using (var reader = cmd.BeginExecuteNonQuery())
            // {
            //     while (reader.Read())
            //     {
            //         int id = reader.GetInt32(0);
            //         string name = reader.GetString(1);
            //         string dept = reader.GetString(2);
            //         decimal salary = reader.GetDecimal(3);

            //         Console.WriteLine($"{id} | {name} | {dept} | {salary}");
            //     }
            // }

        //------------------- Insert Data into DB --------------------------------------------------
            // int RowsAffected = cmd.ExecuteNonQuery();
            // Console.WriteLine(RowsAffected == 1 ? " Inserted" : " Not inserted");

            
        // ------------------ READ DATA USING PARAMETER --------------------------------------------
            // using var r = cmd.ExecuteReader();
            // while (r.Read())
            // {
            //     Console.WriteLine($"{r["EmployeeId"]} | {r["FullName"]} | {r["Salary"]}");
            // }

        // ---------------- UPDATE THE RECORD BASED ON EMPLOYEEID ----------------------------------

            // int RowsAffected = cmd.ExecuteNonQuery();
            // Console.WriteLine(RowsAffected == 1 ? " Updated" : " Not Updated");

        // ---------------- DELECT THE RECORD FROM DB ----------------------------------------------
            int RowsAffected = cmd.ExecuteNonQuery();
            Console.WriteLine(RowsAffected == 1 ? " Deleted" : " Not Deleted"); 



           con.Close();
       }

        
    }
}