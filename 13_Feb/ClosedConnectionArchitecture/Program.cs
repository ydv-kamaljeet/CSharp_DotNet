using Microsoft.Data.SqlClient;
using System.Data;

class Program
{
    static void Main()
    {
        string cs =
        "Server=localhost;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;";

        string sql = @"
            SELECT EmployeeId, Department FROM Employees;
            SELECT ProductId, ProductName, StockQty FROM Products;
        ";

        DataSet ds = new DataSet();

        using SqlConnection con = new SqlConnection(cs);
        con.Open();

        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

        // Naming tables
        adapter.TableMappings.Add("Table", "Employees");
        adapter.TableMappings.Add("Table1", "Products");

        adapter.Fill(ds);

        // ===== MANUAL CRUD COMMANDS FOR PRODUCTS =====

        adapter.InsertCommand = new SqlCommand(
            @"INSERT INTO Products(ProductName, StockQty)
              VALUES(@ProductName, @StockQty)", con);

        adapter.InsertCommand.Parameters.Add("@ProductName", SqlDbType.NVarChar, 100, "ProductName");
        adapter.InsertCommand.Parameters.Add("@StockQty", SqlDbType.Int, 0, "StockQty");


        adapter.UpdateCommand = new SqlCommand(
            @"UPDATE Products
              SET ProductName=@ProductName, StockQty=@StockQty
              WHERE ProductId=@ProductId", con);

        adapter.UpdateCommand.Parameters.Add("@ProductName", SqlDbType.NVarChar, 100, "ProductName");
        adapter.UpdateCommand.Parameters.Add("@StockQty", SqlDbType.Int, 0, "StockQty");
        adapter.UpdateCommand.Parameters.Add("@ProductId", SqlDbType.Int, 0, "ProductId");


        adapter.DeleteCommand = new SqlCommand(
            @"DELETE FROM Products WHERE ProductId=@ProductId", con);

        adapter.DeleteCommand.Parameters.Add("@ProductId", SqlDbType.Int, 0, "ProductId");

        // ===== CRUD OPERATIONS =====
        DataTable products = ds.Tables["Products"];

        // INSERT
        var row = products.NewRow();
        row["ProductName"] = "Headphones";
        row["StockQty"] = 20;
        products.Rows.Add(row);

        // UPDATE
        if (products.Rows.Count > 0)
            products.Rows[0]["StockQty"] = 999;

        // DELETE
        if (products.Rows.Count > 1)
            products.Rows[1].Delete();

        // Update only Products table
        adapter.Update(ds, "Products");

        Console.WriteLine("Single adapter CRUD done.");
    }
}
