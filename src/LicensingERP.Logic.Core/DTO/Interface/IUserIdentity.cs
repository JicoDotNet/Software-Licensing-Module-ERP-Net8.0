namespace LicensingERP.Logic.DTO.Interface
{
    public interface IUserIdentity : ILoginUserName
    {
        int UserId { get; set; }
        string Email { get; set; }
        int UserTypeId { get; set; }
    }
}
