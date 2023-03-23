using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KeycloakUserManager.API.KeycloakObjects
{
    public class ConfigurationData
    {


        public string BaseUrl { get => _baseUrl ; }
        public string AccessTokenRequestUrl { get => _accessTokenRequestUrl; }
        public Dictionary<string, string> AccessTokenRequestPostParams { get => _accessTokenRequestPostParams; }


        private string _baseUrl;
        private string _accessTokenRequestUrl;
        private Dictionary<string, string> _accessTokenRequestPostParams;


        public ConfigurationData(Dictionary<string,string> urls, Dictionary<string,string> postParams)
        {
            this._baseUrl = urls["baseUrl"];
            this._accessTokenRequestUrl = urls["RequestAccessTokenUrl"];

            this._accessTokenRequestPostParams = postParams;

            //this.BaseUrl = "http://localhost:8080/admin/realms/Test/";
            //this.AccessTokenRequestUrl = "http://localhost:8080/realms/Test/protocol/openid-connect/token";
            //this.AccessTokenRequestPostParams = new Dictionary<string, string>() {
            //{ "username", "ulrich"},
            //{ "password", "notebook1!"},
            //{ "client_id", "test"},
            //{ "client_secret", "WDt2lwJj1ZY7OLOP7V8w9UvKjLbn1Q7n" },
            //{ "grant_type", "password" },
            //{"scope", "openid" }
            //};

            //Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            //var col = ConfigurationManager.GetSection("KeycloakAPI/AccessTokenPostParams") as NameValueCollection;
            //this.AccessTokenRequestPostParams = col.AllKeys.ToDictionary(k => k, k => col[k]);

            //col = ConfigurationManager.GetSection("KeycloakAPI/Urls") as NameValueCollection;
            //var dic = col.AllKeys.ToDictionary(k => k, k => col[k]);
            //this.BaseUrl = dic["baseUrl"];
            //this.AccessTokenRequestUrl = dic["RequestURLAccessToken"];
        }
    }
}
