using System.Collections.Generic;

namespace DataAccess.MySQL.Net
{
    public class nameValuePairs : List<nameValuePair>
    {

    }
    public class nameValuePair
    {
        string _name;
        object _value;

        public nameValuePair(string iParmName, object iObjectValue)
        {
            _name = iParmName;
            _value = iObjectValue;
        }

        public string getName
        {
            get { return _name; }
            set { _name = value; }
        }

        public object getValue
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
