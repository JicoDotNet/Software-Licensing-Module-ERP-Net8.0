using DataAccess.MySql.Entity;
using System.Collections.Generic;

namespace DataAccess.MySql
{
    public class NameValuePair : INameValuePair
    {
        public NameValuePair(string iParmName, object iObjectValue)
        {
            getName = iParmName;
            getValue = iObjectValue;
        }

        public string getName { get; private set; }
        public object getValue { get; private set; }
    }
}
