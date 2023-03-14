using Newtonsoft.Json;
using SourceCode.Hosting.Server.Interfaces;
using System;
using System.Collections;
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

    public class KeycloakUser : IUser
    {
        [JsonProperty("UserID")]
        public string id { get; set; }
        [JsonIgnore]
        public long createdTimestamp { get; set; }

        [JsonProperty("username")]
        public string UserName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool enabled { get; set; }
        [JsonIgnore]
        public bool totp { get; set; }
        [JsonIgnore]
        public bool emailVerified { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<object> disableableCredentialTypes { get; set; }
        public List<object> requiredActions { get; set; }
        public int notBefore { get; set; }
        public Access access { get; set; }
        public IDictionary<string, object> Properties { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [JsonProperty("id")]
        public string UserID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class KeycloakGroup : IGroup
    {
        //public string id { get; set; }
        //public string name { get; set; }
        [JsonIgnore]
        public string path { get; set; }
        public List<KeycloakGroup> subGroups { get; set; }
        public IDictionary<string, object> Properties { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [JsonProperty("name")]
        public string GroupName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [JsonProperty("id")]
        public string GroupID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class GroupCollection : List<IGroup>, IGroupCollection
    {
        public new IGroup this[int index] => base[index];

        public new IEnumerator GetEnumerator()
        {
           return base.GetEnumerator();
        }
    }

    public class UserCollection : List<IUser>, IUserCollection
    {
        public new IUser this[int index] => base[index];

        public new IEnumerator GetEnumerator()
        {
            return base.GetEnumerator();
        }
    }
}
