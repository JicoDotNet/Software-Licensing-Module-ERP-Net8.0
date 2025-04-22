namespace DataAccess.MySql
{
    public interface IMySqlManager
    {
        bool IsRunningStatus { get; }
        void CloseConnection();
    }
}
