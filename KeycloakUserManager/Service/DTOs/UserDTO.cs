using KeycloakUserManager.API.KeycloakObjects;
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

        public UserDTO()
        {

        }

        public UserDTO(KeycloakUser user)
        {
            this.UserID = user.username;
            this.UserName = user.username;

            this.Properties =  new Dictionary<string, object>()
            {
                { "UserPrincipalName", String.Empty },
                { "Name", user.username },
                { "Description", String.Empty },
                { "Email", user.email },
                { "DisplayName", string.Empty },
                { "CommonName", String.Empty },
                { "ObjectSID", user.id },
            };
        }
    }
}
