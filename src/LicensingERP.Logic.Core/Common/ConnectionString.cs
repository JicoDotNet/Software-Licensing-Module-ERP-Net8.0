using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using DataAccess.MySql;

namespace LicensingERP.Logic.Common
{
    public class ConnectionString
    {
        public ConnectionString(sCommonDto sCommonDtoObj)
        {
            CommonObj = sCommonDtoObj;
        }
        protected sCommonDto CommonObj { get; private set; }
        protected MySqlDbAccess mySqlDBAccess;
    }
}