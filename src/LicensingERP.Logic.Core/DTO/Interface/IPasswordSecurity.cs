using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Interface
{
    /// <summary>
    /// tbl_password_security_questions
    /// </summary>
    public interface IPasswordSecurity
    {
        int UserId { get; set; }
        int QuestionEnumNo { get; set; }
        string Question { get; set; }
        string Answer { get; set; }
    }
}
