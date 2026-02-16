using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;


public class Program
{
    public static void Main(string[] args)
    {
        if (false)
        {
            string cs =
            "Server=localhost;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;";

            string sql = @"
            SELECT ProductId, ProductName, StockQty FROM Products;
        ";

            DataSet ds = new DataSet();

            using SqlConnection con = new SqlConnection(cs);

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

            adapter.Fill(ds);

            DataTable products = ds.Tables[0];
            var prod = from rw in products.AsEnumerable()
                       where rw.Field<int?>("StockQty") > 20
                       select rw;

            foreach (var r in prod)
            {
                Console.WriteLine(r["ProductName"]);
            }

            // INSERT
            var row = products.NewRow();
            row["ProductName"] = "HP_LAPTOP";
            row["StockQty"] = 120;
            products.Rows.Add(row);

            ds.AcceptChanges();
            adapter.Update(ds);

            Console.WriteLine("Single adapter CRUD done.");
        }

        //UsingReader();
        DisconnectedRead();
    }


    public static void UsingReader()
    {

        string cs =
        "Server=localhost;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;";

        using var con = new SqlConnection(cs);
        using var cmd = new SqlCommand("SELECT StudentId, FullName, City, Marks FROM Students WHERE IsActive = 1", con);

        con.Open();
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            string city = reader.GetString(2);
            int marks = reader.GetInt32(3);

            Console.WriteLine($"{id} | {name} | {city} | {marks}");
        }
    }

    public static void DisconnectedRead()
    {
        string cs =
        "Server=localhost;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;";

        DataTable students = new DataTable();

        using (var con = new SqlConnection(cs))
        using (var cmd = new SqlCommand("SELECT StudentId, FullName, City, Marks, IsActive FROM Students", con))
        using (var da = new SqlDataAdapter(cmd))
        {
            con.Open();
            da.Fill(students); // Data copied into memory
        }

        //  Connection is closed here, but data is available
        Console.WriteLine("Rows loaded: " + students.Rows.Count);
        foreach (DataRow row in students.Rows)
        {
            Console.WriteLine($"{row["StudentId"]} | {row["FullName"]} | {row["City"]} | {row["Marks"]}");
        }


        var rows = students.AsEnumerable(); // 
        // Example: list active students names
        var activeNames = rows
            .Where(r => r.Field<bool>("IsActive") == true)
            .Select(r => r.Field<string>("FullName"))
            .ToList();

        activeNames.ForEach(Console.WriteLine);

        //===================================================================================================================================

        DataTable enrollments = new DataTable();
        DataTable courses = new DataTable();

        using (var con = new SqlConnection(cs))
        {
            con.Open();

            using (var da1 = new SqlDataAdapter("SELECT StudentId, FullName, City, Marks, IsActive FROM Students", con))
                da1.Fill(students);

            using (var da2 = new SqlDataAdapter("SELECT StudentId, CourseId FROM Enrollments", con))
                da2.Fill(enrollments);

            using (var da3 = new SqlDataAdapter("SELECT CourseId, CourseName FROM Courses", con))
                da3.Fill(courses);
        }

        var report =
        from s in students.AsEnumerable()
        join e in enrollments.AsEnumerable()
            on s.Field<int>("StudentId") equals e.Field<int>("StudentId")
        join c in courses.AsEnumerable()
            on e.Field<int>("CourseId") equals c.Field<int>("CourseId")
        where s.Field<bool>("IsActive") == true
        select new
        {
            Student = s.Field<string>("FullName"),
            City = s.Field<string>("City"),
            Marks = s.Field<int>("Marks"),
            Course = c.Field<string>("CourseName")
        };

            foreach (var row in report)
                Console.WriteLine($"{row.Student} | {row.City} | {row.Marks} | {row.Course}");

        }
}
