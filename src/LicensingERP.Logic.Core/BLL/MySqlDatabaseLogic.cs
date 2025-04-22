using DataAccess.MySql;
using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.SP;

namespace LicensingERP.Logic.BLL
{
    public class MySqlDatabaseLogic : ConnectionString
    {
        public MySqlDatabaseLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public bool AbleToConnect
        {
            get
            {
                mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
                return mySqlDBAccess.IsRunningStatus;
            }
        }
    }
}
