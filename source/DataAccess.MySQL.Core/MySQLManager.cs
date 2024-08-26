using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.MySQL.Net
{
    public abstract class MySQLManager : IMySQLManager
    {
        public MySqlConnection SqlConnectionObject { get; private set; }
        public ConnectionState SqlConnectionState { get { return SqlConnectionObject.State; } }

        private MySQLManager()
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

        public MySQLManager(object ConnectionString)
        {
            if (string.IsNullOrEmpty(ConnectionString.ToString()))
            {
                throw new ArgumentNullException("ConnectionString", "Connection String Key Name can't be empty");
            }
            try
            {
                SqlConnectionObject = new MySqlConnection(ConnectionString.ToString());
                //GetConnection();
            }
            catch (Exception ex)
            {
                GC.Collect();
                SqlConnectionObject.Close();
                SqlConnectionObject.Dispose();
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

        public void GetConnection(MySqlConnection Connection)
        {
            try
            {
                if (Connection.State == ConnectionState.Open ||
                    Connection.State == ConnectionState.Broken ||
                    Connection.State == ConnectionState.Connecting)
                {
                    Connection.Close();
                    Connection.Open();
                }
                else if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                }
                else
                {
                    Connection.Close();
                    Connection.Open();
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

        public void CloseConnection(MySqlConnection Connection)
        {
            if (Connection != null)
            {
                Connection.Close();
                Connection.Dispose();
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

        ~MySQLManager()
        {
            //CloseConnection();
            GC.Collect();
        }
    }
}
