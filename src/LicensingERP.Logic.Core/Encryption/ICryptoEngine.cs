namespace LicensingERP.Logic.Encryption
{
    public interface ICryptoEngine
    {
        string Encrypt(string inputText);
        string Decrypt(string encryptedText);
    }
}
