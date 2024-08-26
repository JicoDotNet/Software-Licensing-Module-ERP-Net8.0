using System.ComponentModel.DataAnnotations;

namespace LicensingERP.Logic.Enumeration
{
    public class DropDownEnum
    {
        public ePasswordSecurityQuestions playerlist { get; set; }
    }

    public enum ePasswordSecurityQuestions
    {
        [Display(Name = "Which year did you graduate from High School?")]
        Question1 = 1,

        [Display(Name = "Which year your mother was born?")]
        Question2 = 2,

        [Display(Name = "How many bones have you broken?")]
        Question3 = 3,

        [Display(Name = "What are the first 4 digits of your debit card?")]
        Question4 = 4,

        [Display(Name = "What is the Postal Code of the area you born?")]
        Question5 = 5,

        [Display(Name = "What are the first 4 digits of your mother's/sister's mobile number?")]
        Question6 = 6,

        [Display(Name = "Which year were you got the first job?")]
        Question7 = 7,
    }
}
