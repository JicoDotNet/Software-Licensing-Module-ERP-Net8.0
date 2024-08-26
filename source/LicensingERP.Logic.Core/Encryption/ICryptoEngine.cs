namespace LicensingERP.Logic.Encryption
{
    public interface ICryptoEngine
    {
        string Encrypt(string input);
        string Decrypt(string input);
    }
}
