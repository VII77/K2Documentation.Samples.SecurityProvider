using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KeycloakAPI
{
    public class KeycloakApi
    {
        private string _baseUrl;
        private string _accessTokenRequestUrl;
        private Dictionary<string, string> _postParams;

        private HttpClient _client;
        private string _userName;

        public KeycloakApi(HttpClient client, ConfigurationData configData)
        {
            _client = client;
            _postParams = configData.AccessTokenRequestPostParams;
            _baseUrl = configData.BaseUrl;
            _accessTokenRequestUrl = configData.AccessTokenRequestUrl;
            
        }

        public async Task<string> GetAccessToken()
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, _accessTokenRequestUrl);
            requestMessage.Content = new FormUrlEncodedContent(_postParams);
            HttpResponseMessage response = _client.SendAsync(requestMessage).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get access token. Status code: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<JObject>(json);
            var x = jsonObject.Property("access_token").Value;
            return x.ToString();

        }

        public async Task<List<KeycloakUser>> GetUsers()
        {
            var accessToken = await GetAccessToken();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var url = $"{_baseUrl}users";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get users. Status code: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();
            return JArray.Parse(json).ToObject<List<KeycloakUser>>();
        }

    }

}
