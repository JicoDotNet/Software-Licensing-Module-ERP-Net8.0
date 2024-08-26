using System.ComponentModel.DataAnnotations;

namespace LicensingERP.Logic.Enumeration
{
    public enum eDataType
    {
        [Display(Name = "Numeric")]
        Int = 1,

        [Display(Name = "Var-Char")]
        String = 2,

        //[Display(Name = "Long Text")]
        //String2 = 3,

        //[Display(Name = "Yes/No")]
        //Bool = 4,

        [Display(Name = "Date")]
        Date = 5,

        //[Display(Name = "List")]
        //List = 6
    }
}
