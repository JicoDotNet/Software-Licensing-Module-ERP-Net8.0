using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Interface
{
    /// <summary>
    ///  tbl_user`
    /// </summary>
    public interface IUser : IUserType
    {
        int UserTypeId { get; set; }
        string Email { get; set; }
        string Mobile { get; set; }
        string FullName { get; set; }
        string Designation { get; set; }
        string Address { get; set; }
    }
}
