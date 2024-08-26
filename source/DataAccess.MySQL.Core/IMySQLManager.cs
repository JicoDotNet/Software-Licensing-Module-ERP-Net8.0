using MySql.Data.MySqlClient;
using System;

namespace DataAccess.MySQL.Net
{
    public interface IMySQLManager: IDisposable
    {
        MySqlConnection SqlConnectionObject { get; }
        void CloseConnection(MySqlConnection Connection);
        void DisposeConnection();
        void CloseConnection();
    }
}
