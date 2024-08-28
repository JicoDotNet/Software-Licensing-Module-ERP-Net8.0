using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.MySql
{
    public abstract class MySqlManager : IDisposable
    {
        protected MySqlConnection MySqlConnectionObject { get; private set; }

        protected MySqlManager(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString.ToString()))
            {
                throw new ArgumentNullException(nameof(connectionString), "Connection String Key Name can't be empty");
            }
            try
            {
                MySqlConnectionObject = new MySqlConnection(connectionString);
                MySqlConnectionObject.Close();
            }
            catch (Exception)
            {                
                if (MySqlConnectionObject != null)
                {
                    MySqlConnectionObject.Close();
                    MySqlConnectionObject.Dispose();
                }
                GC.Collect();
            }
        }

        protected void OpenConnection()
        {
            try
            {
                if (MySqlConnectionObject.State == ConnectionState.Open ||
                    MySqlConnectionObject.State == ConnectionState.Broken ||
                    MySqlConnectionObject.State == ConnectionState.Connecting)
                {
                    MySqlConnectionObject.Close();
                    MySqlConnectionObject.Open();
                }
                else if (MySqlConnectionObject.State == ConnectionState.Closed)
                {
                    MySqlConnectionObject.Open();
                }
                else
                {
                    MySqlConnectionObject.Close();
                    MySqlConnectionObject.Open();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CloseConnection()
        {
            if (MySqlConnectionObject != null)
            {
                MySqlConnectionObject.Close();
            }
        }

        public void Dispose()
        {
            if (MySqlConnectionObject != null)
            {
                MySqlConnectionObject.Close();
                MySqlConnectionObject.Dispose();
            }
            MySqlConnectionObject = null;
            GC.Collect();
        }

        ~MySqlManager()
        {
            if (MySqlConnectionObject != null)
            {
                MySqlConnectionObject.Close();
                MySqlConnectionObject.Dispose();
            }
            MySqlConnectionObject = null;
            GC.Collect();
        }
    }
}
