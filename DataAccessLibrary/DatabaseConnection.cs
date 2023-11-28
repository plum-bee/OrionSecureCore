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
        private SqlConnection _sqlConnection;
        private DataSet _dataSet;

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

        protected DataSet RetrieveAllData(string tableName)
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

        protected DataSet RetrieveDataUsingQuery(string sqlQuery)
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

        protected DataSet RetrieveDataUsingQuery(string sqlQuery, string tableName)
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

        protected void UpdateData(string sqlQuery, DataSet dataSetToUpdate)
        {
            OpenSqlConnection();

            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, _sqlConnection))
            {
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(dataSetToUpdate);
            }

            CloseSqlConnection();
        }

        protected void ExecuteSqlNonQuery(string sqlQuery)
        {
            OpenSqlConnection();

            using (SqlCommand command = new SqlCommand(sqlQuery, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }

            CloseSqlConnection();
        }
    }
}
