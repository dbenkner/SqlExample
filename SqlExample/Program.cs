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
    var state = Convert.ToString(reader["state"]);
    Console.WriteLine($"ID={id}, name={name}, city={city}, State={state}");
};
conn.Close();

conn.Open();

if (conn.State != System.Data.ConnectionState.Open)
{
    throw new Exception("Connection didn't open");
}
Console.WriteLine("Success!");

sql = "SELECT product, count(product) As TotalSold, count(product) * price as TotalSales FROM Orderlines group by product, Price;";
cmd = new SqlCommand(sql, conn);
reader = cmd.ExecuteReader();

while (reader.Read())
{

    var product = Convert.ToString(reader["Product"]);
    var count = Convert.ToInt32(reader["TotalSold"]);
    var totalsold = Convert.ToDecimal(reader["TotalSales"]);
    Console.WriteLine($"Product={product}, TotalSold = {count}, TotalSales = {totalsold}");
}
conn.Close();

conn.Open();
if (conn.State != System.Data.ConnectionState.Open)
{
    throw new Exception("Connection didn't open");
}
Console.WriteLine("Scucess!");
sql = "SELECT c.name, o.description, o.date FROM customers c  JOIN orders o on c.ID = o.CustomerId;";
cmd = new SqlCommand(sql, conn);
reader = cmd.ExecuteReader();
while (reader.Read())
{
    var cname = Convert.ToString(reader["c.name"]);
    var descrip = Convert.ToString(reader["o.description"]);
    var date = Convert.ToDateTime(reader["o.date"]);
    Console.WriteLine($"Customer Name = {cname}, Order Description:{descrip}, Date = {date}");
}
conn.Close();
