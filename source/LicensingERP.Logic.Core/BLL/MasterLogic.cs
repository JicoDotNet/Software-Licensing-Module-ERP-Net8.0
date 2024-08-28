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
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs();
            NameValuePairs.Add(new NameValuePair("p_QueryType", "COUNT"));

            return mySqlDBAccess.GetData(StoreProcedure.GetMaster, NameValuePairs).ToList<Master>().FirstOrDefault() ;
        }
    }
}
