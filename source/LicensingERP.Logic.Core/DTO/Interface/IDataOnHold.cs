using System;

namespace LicensingERP.Logic.DTO.Interface
{
    /// <summary>
    /// tbl_mc_data_on_hold
    /// </summary>
    public interface IDataOnHold
    {
        string CaseType { get; set; }
        string Purpose { get; set; }
        string EffectedData { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string EffectedDataDisplay { get; set; }
        string OldDataDisplay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int EffectedRowId { get; set; }
        int CreatedUserId { get; set; }
        int CreatedUserTypeId { get; set; }
        bool? IsApproved { get; set; }
        int ApproveRejectUserId { get; set; }
        int ApproveRejectUserTypeId { get; set; }
        string ApproveRejectRemarks { get; set; }
        DateTime? ApproveRejectDate { get; set; }
    }
}
