using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KeycloakUserManager.API.KeycloakObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KeycloakUserManager.API
{
    public class KeycloakAPI
    {
        private ConfigurationData _configData;
        private HttpClient _client;
        private string _accessToken;

        public KeycloakAPI(HttpClient client, ConfigurationData configData)
        {
            _client = client;
            _configData = configData;
            var GetTokenTask = this.GetAccessToken();
            GetTokenTask.Wait();
            _accessToken = GetTokenTask.Result;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

        }

        public async Task<string> GetAccessToken()
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, _configData.AccessTokenRequestUrl);
            requestMessage.Content = new FormUrlEncodedContent(_configData.AccessTokenRequestPostParams);
            var response = await _client.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get access token. Status code: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<JObject>(json);
            var x = jsonObject.Property("access_token").Value;
            return x.ToString();

        }

        public async Task<KeycloakUser> GetUserByUsername(string username, bool search)
        {
            Dictionary<string, string> queryParameters;

            if (search)
            {
                queryParameters = new Dictionary<string, string> { { "search", username } };

            }
            else
            {
                queryParameters = new Dictionary<string, string> { { "username", username } };
            }

            var dictFormUrlEncoded = new FormUrlEncodedContent(queryParameters);
            var queryString = await dictFormUrlEncoded.ReadAsStringAsync();

            var url = $"{_configData.BaseUrl}users?{queryString}";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get users. Status code: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();
            return JArray.Parse(json).ToObject<List<KeycloakUser>>().FirstOrDefault();
        }

        public async Task<KeycloakGroup> GetGroupByGroupName(string groupName, bool search)
        {
            Dictionary<string, string> queryParameters;

            if (search)
            {
                queryParameters = new Dictionary<string, string> { { "search", groupName } };

            }
            else
            {
                queryParameters = new Dictionary<string, string> { { "groupname", groupName } };
            }

            var dictFormUrlEncoded = new FormUrlEncodedContent(queryParameters);
            var queryString = await dictFormUrlEncoded.ReadAsStringAsync();

            var url = $"{_configData.BaseUrl}groups?{queryString}";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get users. Status code: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();
            return JArray.Parse(json).ToObject<List<KeycloakGroup>>().FirstOrDefault();
        }

        public async Task<List<KeycloakGroup>> GetGroupsByUsername(string username, bool search)
        {
            var user = await this.GetUserByUsername(username, search);

            if (user !=null)
            {
                var url = $"{_configData.BaseUrl}users/{user.id}/groups";
                var response = await _client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to get users. Status code: {response.StatusCode}");
                }

                var json = await response.Content.ReadAsStringAsync();
                return JArray.Parse(json).ToObject<List<KeycloakGroup>>();
            }

            return new List<KeycloakGroup>();

        }

        public async Task<List<KeycloakUser>> GetGroupMembers(string groupName, bool search)
        {
            if (groupName != null)
            {
                var group = await this.GetGroupByGroupName(groupName, search);

                if (group != null)
                {
                    var url = $"{_configData.BaseUrl}groups/{group.id}/members";
                    var response = await _client.GetAsync(url);

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"Failed to get users. Status code: {response.StatusCode}");
                    }

                    var json = await response.Content.ReadAsStringAsync();
                    return JArray.Parse(json).ToObject<List<KeycloakUser>>();
                }
            }

            return new List<KeycloakUser>();
        }
    }

}
