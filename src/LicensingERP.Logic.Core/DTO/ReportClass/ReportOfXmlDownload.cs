using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.ReportClass
{
    public class ReportOfXmlDownload : ReportOfRequest
    {
        public string User { get; set; }
    }
}
