using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.MySql
{
    public abstract class MySqlManager : IMySqlManager
    {
        public MySqlConnection SqlConnectionObject { get; private set; }
        public ConnectionState SqlConnectionState { get { return SqlConnectionObject.State; } }

        private MySqlManager()
        {
            SqlConnectionObject = null;
        }

        //public MySQLManager(string ConnectionString)
        //{
        //    if (string.IsNullOrEmpty(ConnectionString))
        //    {
        //        throw new ArgumentNullException("ConnectionString", "Connection String can't be empty");
        //    }
        //    try
        //    {
        //        _conn = new MySqlConnection(ConnectionString);
        //        GetConnection();
        //    }
        //    catch (Exception ex)
        //    {
        //        GC.Collect();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        _conn.Close();
        //        _conn.Dispose();
        //    }
        //}

        protected MySqlManager(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString.ToString()))
            {
                throw new ArgumentNullException(nameof(connectionString), "Connection String Key Name can't be empty");
            }
            try
            {
                SqlConnectionObject = new MySqlConnection(connectionString);
                //GetConnection();
            }
            catch (Exception ex)
            {
                GC.Collect();
                if (SqlConnectionObject != null)
                {
                    SqlConnectionObject.Close();
                    SqlConnectionObject.Dispose();
                }
            }
        }

        private void GetConnection()
        {
            try
            {
                if (SqlConnectionObject.State == ConnectionState.Open ||
                    SqlConnectionObject.State == ConnectionState.Broken ||
                    SqlConnectionObject.State == ConnectionState.Connecting)
                {
                    SqlConnectionObject.Close();
                    SqlConnectionObject.Open();
                }
                else if (SqlConnectionObject.State == ConnectionState.Closed)
                {
                    SqlConnectionObject.Open();
                }
                else
                {
                    SqlConnectionObject.Close();
                    SqlConnectionObject.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetConnection(MySqlConnection connection)
        {
            try
            {
                if (connection.State == ConnectionState.Open ||
                    connection.State == ConnectionState.Broken ||
                    connection.State == ConnectionState.Connecting)
                {
                    connection.Close();
                    connection.Open();
                }
                else if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                else
                {
                    connection.Close();
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CloseConnection()
        {
            if (SqlConnectionObject != null)
            {
                SqlConnectionObject.Close();
                SqlConnectionObject.Dispose();
                SqlConnectionObject = null;
            }
        }

        public void CloseConnection(MySqlConnection connection)
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }            
        }

        public void DisposeConnection()
        {
            CloseConnection();
        }

        public void Dispose()
        {
            CloseConnection();
        }

        ~MySqlManager()
        {
            //CloseConnection();
            GC.Collect();
        }
    }
}
