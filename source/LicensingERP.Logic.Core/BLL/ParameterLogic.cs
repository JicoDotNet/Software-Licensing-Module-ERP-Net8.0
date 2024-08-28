using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
   public class ParameterLogic : ConnectionString
    {
        public ParameterLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int Insert(Parameter parameter)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", 0),
                
                new nameValuePair("p_FieldName",parameter.FieldName),
                new nameValuePair("p_DataType", parameter.DataType),
                new nameValuePair("p_IsRequired", parameter.IsRequired),
                new nameValuePair("p_Fieldlength", parameter.Fieldlength),
                new nameValuePair("p_ListData",parameter.ListData),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_IsActive", parameter.IsActive),
                //new nameValuePair("p_SessionId", CommonObj.SessionId),

                new nameValuePair("p_QueryType", "INSERT")

            };
           return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetParameters, nvp, "Out_Param"));
        }
        public int Update(Parameter parameter)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", parameter.Id),
                new nameValuePair("p_FieldName",parameter.FieldName),
                new nameValuePair("p_DataType", parameter.DataType),
                new nameValuePair("p_IsRequired", parameter.IsRequired),
                new nameValuePair("p_Fieldlength", parameter.Fieldlength),
                new nameValuePair("p_ListData",parameter.ListData),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_IsActive", parameter.IsActive),
                //new nameValuePair("p_SessionId", CommonObj.SessionId),

                new nameValuePair("p_QueryType", "UPDATE")

            };
            return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetParameters, nvp, "Out_Param"));
        }
        public List<Parameter> GetParameter()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs();

            //nameValuePairs.Add(new nameValuePair("p_CategoryId", 0));
            nameValuePairs.Add(new nameValuePair("p_QueryType", "ALL"));

            return mySqlDBAccess.GetData(StoreProcedure.GetParameter, nameValuePairs).ToList<Parameter>();
        }

        public int Deactivate(int ParameterId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", ParameterId),
                new nameValuePair("p_FieldName",null),
                new nameValuePair("p_DataType", null),
                new nameValuePair("p_IsRequired", null),
                new nameValuePair("p_Fieldlength", null),
                new nameValuePair("p_ListData",null),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_IsActive", null),
                new nameValuePair("p_QueryType", "DEACTIVATE")
            };
            return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetParameters, nvp, "Out_Param"));
        }

        public Parameter GetParameter(int ParameterId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs();

            //nameValuePairs.Add(new nameValuePair("p_CategoryId", 0));
            nameValuePairs.Add(new nameValuePair("p_QueryType", "ALL"));

            return mySqlDBAccess.GetData(StoreProcedure.GetParameter, nameValuePairs).ToList<Parameter>().Where(a => a.Id == ParameterId).FirstOrDefault();
        }

    }
}
