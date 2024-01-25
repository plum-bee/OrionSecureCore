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
    public abstract class DatabaseConnection
    {
        private readonly string _connectionString;
        private readonly SqlConnection _sqlConnection;
        private DataSet _dataSet;

        public DatabaseConnection()
        {
            _connectionString = "Data Source=sqlserver.S2AM.sdslab.cat;Initial Catalog=SecureCoreG6;User Id=G6;Password=12345aAG62324.;";
            //_connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            _sqlConnection = new SqlConnection(_connectionString);
        }

        private void OpenSqlConnection()
        {
            if (_sqlConnection.State != ConnectionState.Open)
            {
                _sqlConnection.Open();
            }
        }

        private void CloseSqlConnection()
        {
            if (_sqlConnection != null && _sqlConnection.State == ConnectionState.Open)
            {
                _sqlConnection.Close();
            }
        }


        //TODO: Arreglar el SQL Injection
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

        public DataSet RetrieveDataUsingQuery(SqlCommand command)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            return dataSet;
        }

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

        public void ExecuteSqlNonQuery(string sqlQuery)
        {
            OpenSqlConnection();

            using (SqlCommand command = new SqlCommand(sqlQuery, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }

            CloseSqlConnection();
        }

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
                    throw ex;
                }
            }
            finally
            {
                CloseSqlConnection();
            }
        }

    }
}
