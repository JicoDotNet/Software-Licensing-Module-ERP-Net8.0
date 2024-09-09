using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Interface
{

    /// <summary>
    /// tbl_usermenu
    /// </summary>
    public interface IUserMenu
    {
        int MenuId { get; set; }
        int UserId { get; set; }
        int UserTypeId { get; set; }
    }
}
