namespace LicensingERP.Logic.DTO.Interface
{
    public interface IUser : IUserIdentity
    {        
        string Mobile { get; set; }
        string FullName { get; set; }
        string Designation { get; set; }
        string Address { get; set; }
    }
}
