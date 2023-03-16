using KeycloakUserManager.DTOs;
using Newtonsoft.Json;
using SourceCode.Hosting.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycloakUserManager.KeycloakObjects
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
        public List<object> disableableCredentialTypes { get; set; }
        public List<object> requiredActions { get; set; }
        public int notBefore { get; set; }
        public Access access { get; set; }

        public UserDTO MapToUserDTO()
        {
            var dic = new Dictionary<string, object>();

            foreach (var item in typeof(KeycloakUser).GetProperties())
            {
                dic.Add(item.Name, item.GetValue(this));
            }

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
