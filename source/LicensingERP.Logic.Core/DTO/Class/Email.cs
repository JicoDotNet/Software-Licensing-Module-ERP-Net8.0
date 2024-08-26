using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Class
{
    public class Email
    {
        public string Domain { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FromEmail { get; set; }


        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Cc{ get; set; }
        public string Bcc{ get; set; }

    }
}
