using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.Enumeration
{
    public enum eDataOnHoldCaseType
    {
        /// <summary>
        /// Top master
        /// </summary>
        UserGroup = 11,


        User = 21,

        /// <summary>
        /// Top master
        /// </summary>
        LicenseType = 31,

        /// <summary>
        /// Top master
        /// </summary>
        ClientCategory = 41,


        Client = 51,

        /// <summary>
        /// Top master
        /// </summary>
        Product = 61,

        ProductFeatures = 71,

        /// <summary>
        /// Top master
        /// </summary>
        Parameter = 81,

        LicenseParameterLink = 91,

        //
        UserMenuPermission = 102,

        WFProcess = 101,
         WFAssign = 111,

        UserDashboardPermission = 103
        

    }    
}
