using SourceCode.Hosting.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycloakUserManager.Service.DTOs
{
    public class UserDTO : IUser
    {
        public string UserName { get; set; }
        public string UserID { get; set; }
        public IDictionary<string, object> Properties { get; set; }
    }
}
