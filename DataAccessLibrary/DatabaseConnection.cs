using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLibrary
{
    /// <summary>
    /// Represents an abstract base class for database connections, encapsulating common functionality for managing connections and executing commands against a database.
    /// </summary>
    public abstract class DatabaseConnection
    {
        private readonly string _connectionString;
        private readonly SqlConnection _sqlConnection;
        private DataSet _dataSet;

        /// <summary>
        /// Initializes a new instance of the DatabaseConnection class, setting up the connection string and initializing the SQL connection.
        /// </summary>
        public DatabaseConnection()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            _sqlConnection = new SqlConnection(_connectionString);
        }

        /// <summary>
        /// Opens the SQL connection if it is not already open.
        /// </summary>
        private void OpenSqlConnection()
        {
            if (_sqlConnection.State != ConnectionState.Open)
            {
                _sqlConnection.Open();
            }
        }

        /// <summary>
        /// Closes the SQL connection if it is open.
        /// </summary>
        private void CloseSqlConnection()
        {
            if (_sqlConnection != null && _sqlConnection.State == ConnectionState.Open)
            {
                _sqlConnection.Close();
            }
        }

        /// <summary>
        /// Retrieves all data from a specified table.
        /// </summary>
        /// <param name="tableName">The name of the table from which to retrieve data.</param>
        /// <returns>A DataSet containing all rows from the specified table.</returns>
        /// <example>
        /// <code>
        /// var dataSet = databaseConnection.RetrieveAllDataFromTable("Employees");
        /// </code>
        /// </example>
        public DataSet RetrieveAllDataFromTable(string tableName)
        {
            OpenSqlConnection();

            _dataSet = new DataSet();
            var selectQuery = $"SELECT * FROM {tableName}";

            using (var adapter = new SqlDataAdapter(selectQuery, _sqlConnection))
            {
                adapter.Fill(_dataSet);
            }

            CloseSqlConnection();

            return _dataSet;
        }

        /// <summary>
        /// Retrieves data using a specified SQL query.
        /// </summary>
        /// <param name="sqlQuery">The SQL query to execute.</param>
        /// <returns>A DataSet containing the data retrieved by the query.</returns>
        /// <example>
        /// <code>
        /// var dataSet = databaseConnection.RetrieveDataUsingQuery("SELECT * FROM Employees WHERE DepartmentID = 1");
        /// </code>
        /// </example>
        public DataSet RetrieveDataUsingQuery(string sqlQuery)
        {
            OpenSqlConnection();

            _dataSet = new DataSet();

            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, _sqlConnection))
            {
                adapter.Fill(_dataSet);
            }

            CloseSqlConnection();

            return _dataSet;
        }
        /// <summary>
        /// Retrieves data using a specified SQL query and a table name to structure the DataSet.
        /// </summary>
        /// <param name="sqlQuery">The SQL query to execute for data retrieval.</param>
        /// <param name="tableName">The name to assign to the resulting table within the DataSet.</param>
        /// <returns>A DataSet containing the data retrieved, structured with the specified table name.</returns>
        public DataSet RetrieveDataUsingQuery(string sqlQuery, string tableName)
        {
            OpenSqlConnection();

            _dataSet = new DataSet();

            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, _sqlConnection))
            {
                adapter.Fill(_dataSet, tableName);
            }

            CloseSqlConnection();

            return _dataSet;
        }

        /// <summary>
        /// Retrieves data using a specified SQL command.
        /// </summary>
        /// <param name="command">The SqlCommand to execute for data retrieval.</param>
        /// <returns>A DataSet containing the data retrieved by executing the SqlCommand.</returns>
        public DataSet RetrieveDataUsingQuery(SqlCommand command)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            return dataSet;
        }

        /// <summary>
        /// Updates data in the database using a specified SQL query and a DataSet.
        /// </summary>
        /// <param name="sqlQuery">The SQL query to use for updating data.</param>
        /// <param name="dataSetToUpdate">The DataSet containing the data to be updated in the database.</param>
        public void UpdateData(string sqlQuery, DataSet dataSetToUpdate)
        {
            OpenSqlConnection();

            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, _sqlConnection))
            {
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(dataSetToUpdate);
            }

            CloseSqlConnection();
        }

        /// <summary>
        /// Executes a SQL non-query command (e.g., INSERT, UPDATE, DELETE).
        /// </summary>
        /// <param name="sqlQuery">The SQL query to execute.</param>
        public void ExecuteSqlNonQuery(string sqlQuery)
        {
            OpenSqlConnection();

            using (SqlCommand command = new SqlCommand(sqlQuery, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }

            CloseSqlConnection();
        }

        /// <summary>
        /// Generates a SQL query command using a table name and a dictionary of field values.
        /// </summary>
        /// <param name="tableName">The name of the table to query.</param>
        /// <param name="fieldValues">A dictionary containing field names and their corresponding values to include in the WHERE clause.</param>
        /// <returns>A SqlCommand object ready to be executed.</returns>
        public SqlCommand GenerateQuery(string tableName, Dictionary<string, string> fieldValues)
        {
            StringBuilder query = new StringBuilder($"SELECT * FROM {tableName} WHERE ");

            int parameterCount = 0;
            foreach (KeyValuePair<string, string> field in fieldValues)
            {
                if (parameterCount > 0)
                {
                    query.Append(" AND ");
                }

                query.Append($"{field.Key} = @{field.Key}");
                parameterCount++;
            }

            SqlCommand command = new SqlCommand(query.ToString(), _sqlConnection);
            foreach (KeyValuePair<string, string> field in fieldValues)
            {
                command.Parameters.AddWithValue($"@{field.Key}", field.Value);
            }

            return command;
        }

        /// <summary>
        /// Executes a SQL command within a transaction, rolling back the transaction in case of an error.
        /// </summary>
        /// <param name="command">The SqlCommand to execute within a transaction.</param>
        public void ExecuteTransaction(SqlCommand command)
        {
            OpenSqlConnection();

            SqlTransaction transaction = null;

            try
            {
                transaction = _sqlConnection.BeginTransaction();

                command.Connection = _sqlConnection;
                command.Transaction = transaction;

                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    transaction?.Rollback();
                }
                catch
                {

                    throw;
                }
            }
            finally
            {
                CloseSqlConnection();
            }
        }

    }
}
