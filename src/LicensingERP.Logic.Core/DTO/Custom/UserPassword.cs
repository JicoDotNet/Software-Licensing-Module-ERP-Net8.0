using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Interface;

namespace LicensingERP.Logic.DTO.Custom
{
    /// <summary>
    /// Use this class for Maker Checker of User
    /// </summary>
    public class UserWithPassword: User
    {
        public string Password { get; set; }
    }
}
