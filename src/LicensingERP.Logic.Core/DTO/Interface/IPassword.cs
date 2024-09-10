using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPassword
    {
        int UserId { get; set; }
        string PasswordHash { get; set; }
        DateTime ActivationDate { get; set; }
        string PasswordSalt { get; set; }
        string PasswordText { get; set; }
        bool IsChangeable { get; set; }

        void Encrypt(string DefaultEncryptionKey);
        void Decrypt(string DefaultEncryptionKey);
    }
}
