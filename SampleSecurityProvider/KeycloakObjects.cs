using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycloakAPI
{
    public class ConfigurationData
    {
        public string BaseUrl { get; set; }
        public string AccessTokenRequestUrl { get; set; }

        public Dictionary<string,string> AccessTokenRequestPostParams { get; set; }

        public ConfigurationData()
        {
            var col = ConfigurationManager.GetSection("KeycloakAPI/AccessTokenPostParams") as NameValueCollection;
            this.AccessTokenRequestPostParams = col.AllKeys.ToDictionary(k => k, k => col[k]);

            col = ConfigurationManager.GetSection("KeycloakAPI/Urls") as NameValueCollection;
            var dic = col.AllKeys.ToDictionary(k => k, k => col[k]);
            this.BaseUrl = dic["baseUrl"];
            this.AccessTokenRequestUrl = dic["RequestURLAccessToken"];
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

    public class KeycloakUser
    {
        public string id { get; set; }
        public long createdTimestamp { get; set; }
        public string username { get; set; }
        public bool enabled { get; set; }
        public bool totp { get; set; }
        public bool emailVerified { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<object> disableableCredentialTypes { get; set; }
        public List<object> requiredActions { get; set; }
        public int notBefore { get; set; }
        public Access access { get; set; }
    }

    public class KeycloakGroup
    {
        public string id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public List<KeycloakGroup> subGroups { get; set; }
    }
}
