using System;
using MySql.Data.MySqlClient;

namespace DataAccess.MySql
{
    public interface IMySqlManager: IDisposable
    {
        MySqlConnection SqlConnectionObject { get; }
        void CloseConnection(MySqlConnection connection);
        void DisposeConnection();
        void CloseConnection();
    }
}
