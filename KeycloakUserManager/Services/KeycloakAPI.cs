using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KeycloakUserManager.KeycloakObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KeycloakUserManager.Services
{
    public class KeycloakAPI
    {
        ConfigurationData _configData;
        private HttpClient _client;

        public KeycloakAPI(HttpClient client, ConfigurationData configData)
        {
            _client = client;
            _configData = configData;         
        }

        public async Task<string> GetAccessToken()
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, _configData.AccessTokenRequestUrl);
            requestMessage.Content = new FormUrlEncodedContent(_configData.AccessTokenRequestPostParams);
            HttpResponseMessage response = await _client.SendAsync(requestMessage).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get access token. Status code: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<JObject>(json);
            var x = jsonObject.Property("access_token").Value;
            return x.ToString();

        }

        public async Task<List<KeycloakUser>> GetUserByUsername(string username)
        {
            var accessToken = await GetAccessToken();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var queryParameters = new Dictionary<string, string> {{ "username", username }};
            var dictFormUrlEncoded = new FormUrlEncodedContent(queryParameters);
            var queryString = await dictFormUrlEncoded.ReadAsStringAsync();


            var url = $"{_configData.BaseUrl}users?{queryString}";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get users. Status code: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();
            return JArray.Parse(json).ToObject<List<KeycloakUser>>();
        }

        public async Task<List<KeycloakGroup>> GetGroups()
        {
            var accessToken = await GetAccessToken();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var url = $"{_configData.BaseUrl}groups?";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get users. Status code: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();
            return JArray.Parse(json).ToObject<List<KeycloakGroup>>();
        }

    }

}
