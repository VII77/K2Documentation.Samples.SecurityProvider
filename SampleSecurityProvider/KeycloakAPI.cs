using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSecurityProvider
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;

    public class KeycloakUser
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class KeycloakApi
    {
        private const string BaseUrl = "https://localhost:8080/auth/admin/realms/test/users";

        private readonly HttpClient _client;

        public KeycloakApi(string accessToken)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<KeycloakUser> GetUserById(string userId)
        {
            var url = $"{BaseUrl}/{userId}";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get user. Status code: {response.StatusCode}");
            }

            var userJson = await response.Content.ReadAsStringAsync();
            var user = JObject.Parse(userJson);

            return new KeycloakUser
            {
                Id = user.Value<string>("id"),
                Username = user.Value<string>("username"),
                Email = user.Value<string>("email"),
                FirstName = user.Value<string>("firstName"),
                LastName = user.Value<string>("lastName"),
            };
        }
    }

}
