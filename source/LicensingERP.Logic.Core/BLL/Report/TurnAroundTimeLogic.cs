using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL.Report
{
    public class TurnAroundTimeLogic : ConnectionString
    {
        public TurnAroundTimeLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public List<RequestStatus> Calculate(string RequestNo)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_RequestNo", RequestNo)
            };

            return mySqlDBAccess.GetData(StoreProcedure.RpTurnAroundTime, nameValuePairs).ToList<RequestStatus>();
        }
    }
}
