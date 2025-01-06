using System;

namespace LicensingERP.Logic.DTO.Interface
{
    /// <summary>
    /// tbl_mc_data_on_hold
    /// </summary>
    public interface IMakerCheckerData
    {
        string CaseType { get; set; }
        string Purpose { get; set; }

        /// <summary>
        /// This is for execution into DB
        /// </summary>
        string EffectedData { get; set; }

        /// <summary>
        /// This is for Display in HTML
        /// </summary>
        string EffectedDataDisplay { get; set; }

        /// <summary>
        /// For Update data only
        /// </summary>
        string OldDataDisplay { get; set; }

        /// <summary>
        /// For Update & Delete data only
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
