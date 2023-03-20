using KeycloakUserManager;
using KeycloakUserManager.API;
using KeycloakUserManager.API.KeycloakObjects;
using KeycloakUserManager.Service;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var keycloakapi = new KeycloakAPI(client, new ConfigurationData());
            var service = new KeycloakService(keycloakapi);
            //var task = keycloakapi.GetUserByUsername("bob");
            var task1 = service.FindGroups("bob");
            task1.Wait();
            Console.WriteLine(task1.Result);

            var task2 = service.FindUsers("lalal");
            task2.Wait();
            Console.WriteLine(task2.Result);

            var task3 = service.GetGroup("testGroup11");
            task3.Wait();
            Console.WriteLine(task3.Result);

            var task4 = service.GetUser("alfred");
            task4.Wait();
            Console.WriteLine(task4.Result);
        }
    }
}
