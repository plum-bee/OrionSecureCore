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
    public abstract class DatabaseConnectionBase
    {
        private readonly string _connectionString;
        private readonly SqlConnection _sqlConnection;
        private DataSet _dataSet;
        private SqlTransaction _transaction;

        public DatabaseConnectionBase()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
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

        public DataSet RetrieveAllData(string tableName)
        {
            OpenSqlConnection();

            _dataSet = new DataSet();
            string selectQuery = $"SELECT * FROM {tableName}";

            using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, _sqlConnection))
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

        using (SqlCommand command = new SqlCommand(sqlQuery, _sqlConnection, _transaction))
        {
            command.ExecuteNonQuery();
        }

        if (_transaction == null)
        {
            CloseSqlConnection();
        }
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

        public void BeginTransaction()
        {
            OpenSqlConnection();
            _transaction = _sqlConnection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _transaction?.Commit();
            CloseSqlConnection();
        }

        public void RollbackTransaction()
        {
            _transaction?.Rollback();
            CloseSqlConnection();
        }


    }
}
