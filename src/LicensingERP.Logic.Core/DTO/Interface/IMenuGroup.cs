using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Interface
{
    public interface IMenuGroup
    {
        int Id { get; set; }
        string Icon { get; set; }
        string DisplayText { get; set; }
    }
}
