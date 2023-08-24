using Microsoft.Data.SqlClient;

var connStr = "server=localhost\\sqlexpress;" +
    "database=SalesDb;" +
    "trusted_connection=true;" +
    "trustServerCertificate=true;";
var conn = new SqlConnection(connStr);

conn.Open();

if(conn.State != System.Data.ConnectionState.Open)
{
    throw new Exception("Connection didn't open");
}
Console.WriteLine("Success!");

// put our sql code here

var sql = "SELECT * FROM customers WHERE ID between 10 and 19;";
var cmd = new SqlCommand(sql, conn);
var reader = cmd.ExecuteReader();
while(reader.Read())
{
    var id = Convert.ToInt32(reader["ID"]);
    var name = Convert.ToString(reader["Name"]);
    var city = Convert.ToString(reader["City"]);
    Console.WriteLine($"ID={id}, name={name}, city={city}");
};


conn.Close();