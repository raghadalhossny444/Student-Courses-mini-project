using MySql.Data.MySqlClient;

namespace studentCourses.Infrastructure
{
          public class SQLConnector
          {
                    private readonly string _connectionString;
                    public SQLConnector(string connectionString)
                    {
                              _connectionString = connectionString;
                    }

                    public MySqlConnection Connect()
                    {
                              var connection = new MySqlConnection(_connectionString);
                              connection.Open();
                              return connection;
                    }

                    public void Disconnect(MySqlConnection connection)
                    {
                              if (connection != null && connection.State != System.Data.ConnectionState.Closed)
                                        connection.Close();
                    }
          }
}
