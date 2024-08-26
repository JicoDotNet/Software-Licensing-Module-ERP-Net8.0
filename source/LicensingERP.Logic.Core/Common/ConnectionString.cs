using LicensingERP.Logic.DTO.Class;
using DataAccess.MySQL.Net;

namespace LicensingERP.Logic.Common
{
    public class ConnectionString
    {
        public ConnectionString(sCommonDto sCommonDtoObj)
        {
            CommonObj = sCommonDtoObj;
        }
        protected sCommonDto CommonObj { get; private set; }
        protected MySqlDBAccess mySqlDBAccess;
    }
}