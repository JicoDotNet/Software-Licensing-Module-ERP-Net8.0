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
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", 0),
                
                new NameValuePair("p_FieldName",parameter.FieldName),
                new NameValuePair("p_DataType", parameter.DataType),
                new NameValuePair("p_IsRequired", parameter.IsRequired),
                new NameValuePair("p_Fieldlength", parameter.Fieldlength),
                new NameValuePair("p_ListData",parameter.ListData),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_IsActive", parameter.IsActive),
                //new NameValuePair("p_SessionId", CommonObj.SessionId),

                new NameValuePair("p_QueryType", "INSERT")

            };
           return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetParameters, nvp, "Out_Param"));
        }
        public int Update(Parameter parameter)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", parameter.Id),
                new NameValuePair("p_FieldName",parameter.FieldName),
                new NameValuePair("p_DataType", parameter.DataType),
                new NameValuePair("p_IsRequired", parameter.IsRequired),
                new NameValuePair("p_Fieldlength", parameter.Fieldlength),
                new NameValuePair("p_ListData",parameter.ListData),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_IsActive", parameter.IsActive),
                //new NameValuePair("p_SessionId", CommonObj.SessionId),

                new NameValuePair("p_QueryType", "UPDATE")

            };
            return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetParameters, nvp, "Out_Param"));
        }
        public List<Parameter> GetParameter()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs();

            //NameValuePairs.Add(new NameValuePair("p_CategoryId", 0));
            NameValuePairs.Add(new NameValuePair("p_QueryType", "ALL"));

            return mySqlDBAccess.GetData(StoreProcedure.GetParameter, NameValuePairs).ToList<Parameter>();
        }

        public int Deactivate(int ParameterId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", ParameterId),
                new NameValuePair("p_FieldName",null),
                new NameValuePair("p_DataType", null),
                new NameValuePair("p_IsRequired", null),
                new NameValuePair("p_Fieldlength", null),
                new NameValuePair("p_ListData",null),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_IsActive", null),
                new NameValuePair("p_QueryType", "DEACTIVATE")
            };
            return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetParameters, nvp, "Out_Param"));
        }

        public Parameter GetParameter(int ParameterId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs();

            //NameValuePairs.Add(new NameValuePair("p_CategoryId", 0));
            NameValuePairs.Add(new NameValuePair("p_QueryType", "ALL"));

            return mySqlDBAccess.GetData(StoreProcedure.GetParameter, NameValuePairs).ToList<Parameter>().Where(a => a.Id == ParameterId).FirstOrDefault();
        }

    }
}
