using LicensingERP.Logic.DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingERP.Models
{
    public class _Clients
    {
        public IReadOnlyList<Client> Clients { get; set; }
        public Client Client { get; set; }
        public IReadOnlyList<ClientCategory> ClientCategories { get; set; }
    }
}
