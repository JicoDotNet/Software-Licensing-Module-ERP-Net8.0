using LicensingERP.Logic.DTO.Interface;
using LicensingERP.Logic.Encryption;
using System;

namespace LicensingERP.Logic.DTO.Class
{
    public class Password : IPassword, ISession, IActivity, IIdentity, IStatus
    {
        public int UserId { get; set; }
        public string PasswordHash { get; set; }
        public DateTime ActivationDate { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordText { get; set; }
        public bool IsChangeable { get; set; }

        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }

        public void Encrypt(string DefaultEncryptionKey)
        {
            this.PasswordSalt = GenericLogic.StringGenerate();
            CryptoEngine cryptoEngine = new CryptoEngine(this.PasswordSalt);
            this.PasswordHash = cryptoEngine.Encrypt(this.PasswordText);
            this.PasswordSalt = new CryptoEngine(DefaultEncryptionKey).Encrypt(this.PasswordSalt);            
            this.PasswordText = null;
        }
        public void Decrypt(string DefaultEncryptionKey)
        {
            this.PasswordSalt = new CryptoEngine(DefaultEncryptionKey).Decrypt(this.PasswordSalt);
            CryptoEngine cryptoEngine = new CryptoEngine(this.PasswordSalt);
            this.PasswordText = cryptoEngine.Decrypt(this.PasswordHash);
            this.PasswordHash = null;
            this.PasswordSalt = null;
        }
    }
}
