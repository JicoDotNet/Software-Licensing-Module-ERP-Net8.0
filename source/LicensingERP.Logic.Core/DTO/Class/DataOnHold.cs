using LicensingERP.Logic.BLL;
using LicensingERP.Logic.DTO.Custom;
using LicensingERP.Logic.DTO.Interface;
using LicensingERP.Logic.Enumeration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using LicensingERP.Logic.DTO.SP;

namespace LicensingERP.Logic.DTO.Class
{
    public class DataOnHold<T> : IDataOnHold, ISession, IActivity, IIdentity, IStatus
    {
        public DataOnHold(){}
        public DataOnHold(sCommonDto CommonObj) { _BllCommonLogic = CommonObj; }
        private sCommonDto _BllCommonLogic { get; set; }

        public string CaseType { get; set; }
        public eDataOnHoldCaseType eCaseType { get; set; }

        public string Purpose { get; set; }
        public eDataOnHoldPurpose ePurpose { get; set; }

        public string EffectedData { get; set; }
        public T tEffectedData { get; set; }

        public string EffectedDataDisplay { get; set; }
        public string OldDataDisplay { get; set; }

        public int EffectedRowId { get; set; }

        public int CreatedUserId { get; set; }
        public string CreatedUserFullName { get; set; }

        public int CreatedUserTypeId { get; set; }
        public bool? IsApproved { get; set; }

        public int ApproveRejectUserId { get; set; }
        public string ApproveRejectUserFullName { get; set; }

        public int ApproveRejectUserTypeId { get; set; }
        public string ApproveRejectRemarks { get; set; }
        public DateTime? ApproveRejectDate { get; set; }

        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }

        public void ToObject()
        {
            this.ePurpose = (eDataOnHoldPurpose)Enum.Parse(typeof(eDataOnHoldPurpose), this.Purpose);
            this.eCaseType = (eDataOnHoldCaseType)Enum.Parse(typeof(eDataOnHoldCaseType), this.CaseType);
            this.tEffectedData = JsonConvert.DeserializeObject<T>(this.EffectedData);
        }

        public override string ToString()
        {
            this.Purpose = this.ePurpose.ToString();
            this.CaseType = this.eCaseType.ToString();
            this.EffectedData = JsonConvert.SerializeObject(this.tEffectedData);
            this.EffectedDataDisplay = DataDisplay();
            this.OldDataDisplay = OldDisplay();
            return null;
        }

        public object GetT()
        {
            switch (this.eCaseType)
            {
                case eDataOnHoldCaseType.UserGroup:
                    UserType userType = JsonConvert.DeserializeObject<UserType>(this.EffectedData);
                    userType.Id = this.EffectedRowId;
                    return userType;
                    break;
                case eDataOnHoldCaseType.User:
                    UserPassword user = JsonConvert.DeserializeObject<UserPassword>(this.EffectedData);
                    user.Id = this.EffectedRowId;
                    return user;
                    break;
                case eDataOnHoldCaseType.LicenseType:
                    LicenceType licenceType = JsonConvert.DeserializeObject<LicenceType>(this.EffectedData);
                    licenceType.Id = this.EffectedRowId;
                    return licenceType;
                    break;
                case eDataOnHoldCaseType.Client:
                    Client client = JsonConvert.DeserializeObject<Client>(this.EffectedData);
                    client.Id = this.EffectedRowId;
                    return client;
                    break;
                case eDataOnHoldCaseType.ClientCategory:
                    ClientCategory clientCategory = JsonConvert.DeserializeObject<ClientCategory>(this.EffectedData);
                    clientCategory.Id = this.EffectedRowId;
                    return clientCategory;
                    break;
                case eDataOnHoldCaseType.Parameter:
                    Parameter parameter = JsonConvert.DeserializeObject<Parameter>(this.EffectedData);
                    parameter.Id = this.EffectedRowId;
                    return parameter;
                    break;
                case eDataOnHoldCaseType.Product:
                    Product product = JsonConvert.DeserializeObject<Product>(this.EffectedData);
                    product.Id = this.EffectedRowId;
                    return product;
                    break;
                case eDataOnHoldCaseType.ProductFeatures:
                    ProductFeatures productFeatures = JsonConvert.DeserializeObject<ProductFeatures>(this.EffectedData);
                    productFeatures.Id = this.EffectedRowId;
                    return productFeatures;
                    break;
                case eDataOnHoldCaseType.WFProcess:
                    WfProcess wfProcess = JsonConvert.DeserializeObject<WfProcess>(this.EffectedData);
                    wfProcess.Id = this.EffectedRowId;
                    return wfProcess;
                    break;
                case eDataOnHoldCaseType.LicenseParameterLink:
                    List<ParameterOfLicence> parameterOfLicences = JsonConvert.DeserializeObject<List<ParameterOfLicence>>(this.EffectedData);
                    return parameterOfLicences;
                    break;
                case eDataOnHoldCaseType.UserMenuPermission:
                    List<UserMenu> userMenus = JsonConvert.DeserializeObject<List<UserMenu>>(this.EffectedData);
                    return userMenus;
                    break;
                case eDataOnHoldCaseType.UserDashboardPermission:
                    List<UserDashboard> userdashboard = JsonConvert.DeserializeObject<List<UserDashboard>>(this.EffectedData);
                    return userdashboard;
                    break;
                case eDataOnHoldCaseType.WFAssign:
                    WfProcessAssign wfProcessAssign = JsonConvert.DeserializeObject<WfProcessAssign>(this.EffectedData);
                    return wfProcessAssign;
                    break;
            }

            return default(T);
        }

        private string DataDisplay()
        {
            DataOnHold<T> dataOnHold = this;
            switch (dataOnHold.eCaseType)
            {
                case eDataOnHoldCaseType.UserGroup:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                    {
                        // Where Joining Found, Get data By joining FROM DB, or return
                        // JsonConvert.SerializeObject(this.tEffectedData)
                        return JsonConvert.SerializeObject(this.tEffectedData);
                    }
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Update)
                        return JsonConvert.SerializeObject(this.tEffectedData);
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Deactivate)
                        return JsonConvert.SerializeObject(this.tEffectedData);
                    break;
                case eDataOnHoldCaseType.User:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                    {
                        User user = JsonConvert.DeserializeObject<User>(JsonConvert.SerializeObject(this.tEffectedData));
                        UserTypeLogic logic = new UserTypeLogic(_BllCommonLogic);
                        UserType usertype = new UserType();
                        usertype = logic.GetUserType(user.UserTypeId);
                        user.UserTypeName = usertype.UserTypeName;
                        return JsonConvert.SerializeObject(user);
                    }
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Update)
                        {
                            User user = JsonConvert.DeserializeObject<User>(JsonConvert.SerializeObject(this.tEffectedData));
                            UserTypeLogic logic = new UserTypeLogic(_BllCommonLogic);
                            UserType usertype = new UserType();
                            usertype = logic.GetUserType(user.UserTypeId);
                            user.UserTypeName = usertype.UserTypeName;
                            return JsonConvert.SerializeObject(user);
                        }                        
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Deactivate)
                    {
                        User user = JsonConvert.DeserializeObject<User>(JsonConvert.SerializeObject(this.tEffectedData));
                        UserTypeLogic logic = new UserTypeLogic(_BllCommonLogic);
                        UserType usertype = new UserType();
                        usertype = logic.GetUserType(user.UserTypeId);
                        user.UserTypeName = usertype.UserTypeName;
                        return JsonConvert.SerializeObject(user);
                    }
                    break;
                case eDataOnHoldCaseType.LicenseParameterLink:
                        if(dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                        {
                          List<ParameterOfLicence> parameterOfLicences = JsonConvert.DeserializeObject<List<ParameterOfLicence>>(JsonConvert.SerializeObject(this.tEffectedData));
                          LicenceTypeLogic licenceTypeLogic = new LicenceTypeLogic(_BllCommonLogic);
                          ParameterLogic parameterLogic = new ParameterLogic(_BllCommonLogic);
                            foreach (ParameterOfLicence parameter in parameterOfLicences)
                            {
                              LicenceType licenceType = licenceTypeLogic.GetLicenceType(parameter.LicenseTypeId);
                              Parameter param = parameterLogic.GetParameter(parameter.ParameterId);
                                if (parameter.LicenseTypeId == licenceType.Id && parameter.ParameterId == param.Id)
                                {
                                   parameter.TypeName = licenceType.TypeName;
                                   parameter.FieldName = param.FieldName;
                                }
                            }
                          return JsonConvert.SerializeObject(parameterOfLicences);
                        }
                    break;
                case eDataOnHoldCaseType.UserMenuPermission:
                    if(dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                    {
                        List<UserMenu> userMenus = JsonConvert.DeserializeObject<List<UserMenu>>(JsonConvert.SerializeObject(this.tEffectedData));
                        UserTypeLogic userTypeLogic = new UserTypeLogic(_BllCommonLogic);
                        //UserLogic userLogic = new UserLogic(_BllCommonLogic);
                        MenuLogic menuLogic = new MenuLogic(_BllCommonLogic);
                        foreach(UserMenu usermenu in userMenus)
                        {
                            //User user = userLogic.GetUser(usermenu.UserId);
                            UserType userType = userTypeLogic.GetUserType(usermenu.UserTypeId);
                            MenuList menuList = menuLogic.GetMenuList(usermenu.MenuId);
                            if(userType.Id == usermenu.UserTypeId && menuList.Id == usermenu.MenuId)
                            {
                               
                                usermenu.Menu = menuList.DisplayText;
                                usermenu.Usertype = userType.UserTypeName;
                            }
                        }
                        return JsonConvert.SerializeObject(userMenus);
                    }
                    break;

                case eDataOnHoldCaseType.UserDashboardPermission:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                    {
                        List<UserDashboard> userdashboard = JsonConvert.DeserializeObject<List<UserDashboard>>(JsonConvert.SerializeObject(this.tEffectedData));
                        DashboardAccessLogic dashboardAccessLogic = new DashboardAccessLogic(_BllCommonLogic);
                        UserTypeLogic userTypeLogic = new UserTypeLogic(_BllCommonLogic);
                        foreach(UserDashboard dashboarduser in userdashboard)
                        {
                            UserType userType = userTypeLogic.GetUserType(dashboarduser.UserTypeId);
                            DTO.Class.Dashboard dashboards = dashboardAccessLogic.DashboardList(dashboarduser.DashboardId);
                            if(dashboarduser.DashboardId == dashboards.Id && dashboarduser.UserTypeId == userType.Id)
                            {
                                dashboarduser.DashboardName = dashboards.Description;
                                dashboarduser.DashboardUserType = userType.UserTypeName;
                            }
                        }
                        return JsonConvert.SerializeObject(userdashboard);
                    }
                    break;
                case eDataOnHoldCaseType.LicenseType:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                        return JsonConvert.SerializeObject(this.tEffectedData);
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Update)
                        return JsonConvert.SerializeObject(this.tEffectedData);
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Deactivate)
                        return JsonConvert.SerializeObject(this.tEffectedData);
                    break;
                case eDataOnHoldCaseType.Client:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                    {
                        Client client = JsonConvert.DeserializeObject<Client>(JsonConvert.SerializeObject(this.tEffectedData));
                        ClientCategoryLogic clientCategoryLogic = new ClientCategoryLogic(_BllCommonLogic);
                        ClientCategory clientCategory = new ClientCategory();
                        clientCategory = clientCategoryLogic.GetClientCategory(client.CategoryId);
                        client.CategoryName = clientCategory.CategoryName;
                        return JsonConvert.SerializeObject(client);
                    }
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Update)
                    {
                        Client client = JsonConvert.DeserializeObject<Client>(JsonConvert.SerializeObject(this.tEffectedData));
                        ClientCategoryLogic clientCategoryLogic = new ClientCategoryLogic(_BllCommonLogic);
                        ClientCategory clientCategory = new ClientCategory();
                        clientCategory = clientCategoryLogic.GetClientCategory(client.CategoryId);
                        client.CategoryName = clientCategory.CategoryName;
                        return JsonConvert.SerializeObject(client);
                    }
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Deactivate)
                    {
                        Client client = JsonConvert.DeserializeObject<Client>(JsonConvert.SerializeObject(this.tEffectedData));
                        ClientCategoryLogic clientCategoryLogic = new ClientCategoryLogic(_BllCommonLogic);
                        ClientCategory clientCategory = new ClientCategory();
                        clientCategory = clientCategoryLogic.GetClientCategory(client.CategoryId);
                        client.CategoryName = clientCategory.CategoryName;
                        return JsonConvert.SerializeObject(client);
                    }
                    break;
                case eDataOnHoldCaseType.ClientCategory:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                        return JsonConvert.SerializeObject(this.tEffectedData);
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Update)
                        return JsonConvert.SerializeObject(this.tEffectedData);
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Deactivate)
                        return JsonConvert.SerializeObject(this.tEffectedData);
                    break;
                case eDataOnHoldCaseType.Parameter:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Update)
                    {
                        Parameter parameter = JsonConvert.DeserializeObject<Parameter>(JsonConvert.SerializeObject(this.tEffectedData));
                        parameter.DataType = BLL.Helper.EnumHelper<eDataType>.GetDisplayValue((eDataType)Convert.ToInt32(parameter.DataType));
                        return JsonConvert.SerializeObject(parameter);
                    }                        
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                    {
                        Parameter parameter = JsonConvert.DeserializeObject<Parameter>(JsonConvert.SerializeObject(this.tEffectedData));
                        parameter.DataType = BLL.Helper.EnumHelper<eDataType>.GetDisplayValue((eDataType)Convert.ToInt32(parameter.DataType));
                        return JsonConvert.SerializeObject(parameter);
                    }
                       
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Deactivate)
                    {
                        Parameter parameter = JsonConvert.DeserializeObject<Parameter>(JsonConvert.SerializeObject(this.tEffectedData));
                        parameter.DataType = BLL.Helper.EnumHelper<eDataType>.GetDisplayValue((eDataType)Convert.ToInt32(parameter.DataType));
                        return JsonConvert.SerializeObject(parameter);
                    }
                    break;
                case eDataOnHoldCaseType.Product:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                        return JsonConvert.SerializeObject(this.tEffectedData);
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Update)
                        return JsonConvert.SerializeObject(this.tEffectedData);
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Deactivate)
                        return JsonConvert.SerializeObject(this.tEffectedData);
                    break;
                case eDataOnHoldCaseType.ProductFeatures:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                    {
                        ProductFeatures productfeatures = JsonConvert.DeserializeObject<ProductFeatures>(JsonConvert.SerializeObject(this.tEffectedData));
                        ProductLogic productLogic = new ProductLogic(_BllCommonLogic);
                        Product product = productLogic.GetProductType(productfeatures.ProductId);
                        productfeatures.ProductName = product.ProductName;
                        return JsonConvert.SerializeObject(productfeatures);
                    }
                    break;
                case eDataOnHoldCaseType.WFProcess:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                    {
                        WfProcess wfprocess = JsonConvert.DeserializeObject<WfProcess>(JsonConvert.SerializeObject(this.tEffectedData));
                        LicenceTypeLogic licenceTypeLogic = new LicenceTypeLogic(_BllCommonLogic);
                        LicenceType licenceType = licenceTypeLogic.GetLicenceType(wfprocess.LicenceTypeId);
                        wfprocess.TypeName = licenceType.TypeName;
                        return JsonConvert.SerializeObject(wfprocess);
                    }
                    break;
                case eDataOnHoldCaseType.WFAssign:
                    if(dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                    {
                        WfProcessAssign wfProcessAssign = JsonConvert.DeserializeObject<WfProcessAssign>(JsonConvert.SerializeObject(this.tEffectedData));
                        //WfProcessLogic wfProcessLogic = new WfProcessLogic(_BllCommonLogic);
                        //UserTypeLogic logic = new UserTypeLogic(_BllCommonLogic);
                        UserType fromUsertype = new UserTypeLogic(_BllCommonLogic).GetUserType(wfProcessAssign.FormUserTypeId);
                        UserType touser = new UserTypeLogic(_BllCommonLogic).GetUserType(wfProcessAssign.ToUserTypeId);
                        WfProcess wfProcess = new WfProcessLogic(_BllCommonLogic).GetIdByWFProcess(wfProcessAssign.WFProcessId);
                        if(wfProcessAssign.StateId == 1)
                        {
                            wfProcessAssign.StateName = "Approved";
                        }
                        if(wfProcessAssign.StateId == 3)
                        {
                            wfProcessAssign.StateName = "RevertBack";
                        }
                        if(touser != null)
                        {
                            wfProcessAssign.WorkFlowName = wfProcess.ProcessName;
                            wfProcessAssign.FromUserTypeName = fromUsertype.UserTypeName;
                            wfProcessAssign.ToUserTypeName = touser.UserTypeName;
                        }
                        else
                        {
                            wfProcessAssign.WorkFlowName = wfProcess.ProcessName;
                            wfProcessAssign.FromUserTypeName = fromUsertype.UserTypeName;
                            //wfProcessAssign.ToUserTypeName = touser.UserTypeName;
                        }
                       
                        return JsonConvert.SerializeObject(wfProcessAssign);
                    }
                    break;
            }
            return null;
        }

        private string OldDisplay()
        {
            if (this.ePurpose != eDataOnHoldPurpose.Update)
                return null;
            switch (this.eCaseType)
            {
                case eDataOnHoldCaseType.UserGroup:

                    UserTypeLogic userTypelogic = new UserTypeLogic(_BllCommonLogic);
                    // Get a single Object (First or Default) From DB Of User Grp 
                    // Where UserGrpId == this.EffectedRowId,
                    // Use UserTypeLogic(***).()
                    return  JsonConvert.SerializeObject(userTypelogic.GetUserType(this.EffectedRowId));
                    break;
                case eDataOnHoldCaseType.User:
                    UserLogic userLogic = new UserLogic(_BllCommonLogic);
                    User user = new User();
                    user = userLogic.GetUser(this.EffectedRowId);
                    UserTypeLogic logic = new UserTypeLogic(_BllCommonLogic);
                    UserType usertype = new UserType();
                    usertype = logic.GetUserType(user.UserTypeId);
                    user.UserTypeName = usertype.UserTypeName;
                    return JsonConvert.SerializeObject(user);
                    break;
                case eDataOnHoldCaseType.LicenseType:
                    LicenceTypeLogic licenceTypeLogic = new LicenceTypeLogic(_BllCommonLogic);
                    return JsonConvert.SerializeObject(licenceTypeLogic.GetLicenceType(this.EffectedRowId));
                    break;
                case eDataOnHoldCaseType.Client:
                    ClientLogic clientLogic = new ClientLogic(_BllCommonLogic);
                    ClientCategoryLogic clientCategoryLogic = new ClientCategoryLogic(_BllCommonLogic);
                    Client client = new Client();
                    ClientCategory clientCategory = new ClientCategory();
                    client = clientLogic.GetClient(this.EffectedRowId);
                    clientCategory = clientCategoryLogic.GetClientCategory(client.CategoryId);
                    client.CategoryName = clientCategory.CategoryName;
                    return JsonConvert.SerializeObject(client);
                    break;
                case eDataOnHoldCaseType.ClientCategory:
                    ClientCategoryLogic clientcategorylogic = new ClientCategoryLogic(_BllCommonLogic);
                    return JsonConvert.SerializeObject(clientcategorylogic.GetClientCategory(this.EffectedRowId));
                    break;
                case eDataOnHoldCaseType.Parameter:
                    ParameterLogic parameterLogic = new ParameterLogic(_BllCommonLogic); 
                    Parameter parameter = parameterLogic.GetParameter(this.EffectedRowId);
                    parameter.DataType = BLL.Helper.EnumHelper<eDataType>.GetDisplayValue((eDataType)Convert.ToInt32(parameter.DataType));
                    return JsonConvert.SerializeObject(parameter);
                    break;
                case eDataOnHoldCaseType.Product:
                    ProductLogic productLogic = new ProductLogic(_BllCommonLogic);
                    return JsonConvert.SerializeObject(productLogic.GetProductType(this.EffectedRowId));
                    break;
                //case eDataOnHoldCaseType.ProductFeatures:
                //    ProductFeaturesLogic productFeaturesLogic = new ProductFeaturesLogic(_BllCommonLogic);  
                    
                //    break;
                //case eDataOnHoldCaseType.WFProcess:
                    
                //    break;
            }
            return null;
        }
    }
}
