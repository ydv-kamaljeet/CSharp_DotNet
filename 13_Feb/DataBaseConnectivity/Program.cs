using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string cs = "Server=localhost;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;";
        string sql = "INSERT INTO dbo.Employees (FullName, Department, Salary)VALUES ('Rahul Sharma', 'IT', 65000.00);";

        using (var con = new SqlConnection(cs))
        using (var cmd = new SqlCommand(sql, con))
        {
            con.Open();

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
            int rowsAffected = cmd.ExecuteNonQuery();
            Console.WriteLine(rows == 1 ? " Inserted" : " Not inserted");
        }
    }
}