using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Interface
{
   public interface IMenuList
    {
        int Id { get; set; }
        int MenuGroupId { get; set; }
        string Icon { get; set; }
        string DisplayText { get; set; }
        string Controller { get; set; }
        string RouteId { get; set; }
        string ActionResult { get; set; }
        string QueryString { get; set; }
        bool IsReport { get; set; }
        bool HasRouteId { get; set; }
        string HttpType { get; set; }

        bool IsDisplayable { get; set; }
        bool IsForAdmin { get; set; }

        string Description { get; set; }
        bool IsForWorkflow { get; set; }
    }
}
