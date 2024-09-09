namespace DataAccess.MySql.Entity
{
    public interface INameValuePair
    {
        string getName { get; }
        object getValue { get; }
    }
}
