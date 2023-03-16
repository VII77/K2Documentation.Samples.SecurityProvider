using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycloakUserManager.KeycloakObjects
{
    public class ConfigurationData
    {
        public string BaseUrl { get; set; }
        public string AccessTokenRequestUrl { get; set; }

        public Dictionary<string, string> AccessTokenRequestPostParams { get; set; }

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
}
