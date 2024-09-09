using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Custom
{
    /// <summary>
    /// Use this class for Maker Checker of User
    /// </summary>
    public class UserPassword: User
    {
        public string Password { get; set; }
    }
}
