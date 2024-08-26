using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Interface
{
    /// <summary>
    /// tbl_usertype
    /// </summary>
    public interface IUserType
    {
        string UserTypeName { get; set; }
        string UserTypeDetails { get; set; }
    }
}
