using SampleSecurityProvider;
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var keycloakAPI = new KeycloakApi("dasdf");
            var user  = keycloakAPI.GetUserById("asdf");
        }
    }
}
