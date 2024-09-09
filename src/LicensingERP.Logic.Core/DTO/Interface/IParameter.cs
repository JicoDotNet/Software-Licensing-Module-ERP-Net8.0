using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Interface
{
    /// <summary>
    /// table name tbl_dynamic_form_field
    /// </summary>
    public interface IParameter
    {
        string FieldName { get; set; }
        string DataType { get; set; }
        bool IsRequired { get; set; }
        string Fieldlength { get; set; }
        string ListData { get; set; }
    }
}
