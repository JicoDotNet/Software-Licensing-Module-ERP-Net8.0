using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
    public class MasterLogic : ConnectionString
    {
        public MasterLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public Master Get()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs();
            nameValuePairs.Add(new nameValuePair("p_QueryType", "COUNT"));

            return mySqlDBAccess.GetData(StoreProcedure.GetMaster, nameValuePairs).ToList<Master>().FirstOrDefault() ;
        }
    }
}
