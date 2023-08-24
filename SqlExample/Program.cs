using Microsoft.Data.SqlClient;
using SqlExample;

var connStr = "server=localhost\\sqlexpress;" + // server part hostaddressorIP\instance can have more than one instance per machine always have semi colon
    "database=SalesDb;" + // Database you want to connect to.
    "trusted_connection=true;" + // uid = userID; pwd=myPasswrod; - normally would use the userID and pw unless sql is being run locally on the machine 
    "trustServerCertificate=true;"; // Security Certificate 
var conn = new SqlConnection(connStr);

conn.Open();

if(conn.State != System.Data.ConnectionState.Open)
{
    throw new Exception("Connection didn't open");
}
Console.WriteLine("Success!");

// put our sql code here

var sql = "SELECT * FROM customers Order By Name"; // sql satement
var cmd = new SqlCommand(sql, conn); // communicates with sql server to run statement/command
var reader = cmd.ExecuteReader(); // only done if it is a select statment returns an instance of sql reader
var customers = new List<Customer>();
while(reader.Read())
{
    var cust = new Customer();
    cust.Id = Convert.ToInt32(reader["ID"]); // data in columns
    cust.Name = Convert.ToString(reader["Name"]); // nchar
    cust.City = Convert.ToString(reader["City"]); // 
    cust.State = Convert.ToString(reader["state"]); // 
    cust.Sales = Convert.ToDecimal(reader["sales"]);
    cust.Active = Convert.ToBoolean(reader["Active"]);
    customers.Add(cust); //
}
reader.Close();

// var totalSales  = cmd.ExecuteScalar();   decimal? Sales = reader["Sales"].Equals(DBNull.Value) ? null : Convert.ToDecimal(reader["Sales"]); //? allows decimal to be null
conn.Close();

var x = 0;
