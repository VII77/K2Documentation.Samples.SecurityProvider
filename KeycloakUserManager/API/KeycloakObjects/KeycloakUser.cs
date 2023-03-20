using KeycloakUserManager.Service.DTOs;
using Newtonsoft.Json;
using SourceCode.Hosting.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycloakUserManager.API.KeycloakObjects
{
    public class KeycloakUser
    {
        public string id { get; set; }
        public long createdTimestamp { get; set; }
        public string userame { get; set; }
        public bool enabled { get; set; }
        public bool totp { get; set; }
        public bool emailVerified { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public List<object> disableableCredentialTypes { get; set; }
        public List<object> requiredActions { get; set; }
        public int notBefore { get; set; }
        public Access access { get; set; }

        public UserDTO MapToUserDTO()
        {
            var dic = new Dictionary<string, object>()
            {
                { "UserPrincipalName", String.Empty },
                { "Name", this.userame },
                { "Description", String.Empty },
                { "Email", this.email },
                { "DisplayName", string.Empty },
                { "CommonName", String.Empty },
                { "ObjectSID", this.id },
            };

            var userDto = new UserDTO()
            {
                UserID = id,
                UserName = this.userame,
                Properties = dic

            };

            return userDto;
        }
    }

    public class Access
    {
        public bool manageGroupMembership { get; set; }
        public bool view { get; set; }
        public bool mapRoles { get; set; }
        public bool impersonate { get; set; }
        public bool manage { get; set; }
    }

}
