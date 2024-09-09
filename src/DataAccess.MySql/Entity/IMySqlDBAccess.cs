using System.Data;

namespace DataAccess.MySql.Entity
{
    public interface IMySqlDBAccess
    {
        DataRow GetFirstOrDefaultData(string command, INameValuePairs NameValuePairObject);
        public DataTable GetData(string command);
        DataTable GetData(string command, INameValuePairs NameValuePairObject);
        DataSet GetDataSet(string command, INameValuePairs NameValuePairObject);
        int InsertUpdateDeleteReturnInt(string command, INameValuePairs NameValuePairObject);
        object InsertUpdateDeleteReturnObject(string Command,
            NameValuePairs NameValuePairObject,
            string outParameterName);
    }
}
