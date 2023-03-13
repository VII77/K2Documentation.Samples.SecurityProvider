﻿using KeycloakAPI;
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
            var keycloakapi = new KeycloakApi(client, new ConfigurationData());
            var task = keycloakapi.GetUsers();
            task.Wait();
            Console.WriteLine(task.Result);
        }
    }
}
