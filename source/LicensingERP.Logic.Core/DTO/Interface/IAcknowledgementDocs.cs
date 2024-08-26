using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Interface
{
    public interface IAcknowledgementDocs
    {
        int AcknowledgementId { get; set; }
        string FileName { get; set; }
        string MimeType { get; set; }
        byte[] FileData { get; set; }
        string Description { get; set; }
    }
}
